﻿using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idtxt = this.Request.QueryString["ID"];

                int id = int.Parse(idtxt);
                if (id > 0)
                {
                    var GID = AuthManager.GetQuestionByID(id);
                    string A = GID.ANSR;
                    string[] sArray = A.Split(',');
                    var ID = AuthManager.GetThemeByID(id);

                    this.lblState.Text = "投票中";
                    this.lblTime.Text = $"{ID.T_start.ToString()} ~ {ID.T_end.ToString()}";
                    this.lblHeader.Text = ID.T_title;
                    this.lblMemo.Text = ID.T_memo;
                    this.lblQT.Text = GID.QT;


                    for (int i = 0; i < sArray.Length; i++)
                    {
                        CblVote.Items.Add(sArray[i].ToString());
                    }
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string idtxt = this.Request.QueryString["ID"];
            int id = int.Parse(idtxt);
            var name = txbName.Text;
            var phome = txbMobilePhone.Text;
            var email = txbEmail.Text;
            var age = txbAge.Text;

            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            StringBuilder sbAnswer = new StringBuilder();

            for (int i = 0; i < CblVote.Items.Count; i++)
            {
                if (CblVote.Items[i].Selected)
                {
                    sbAnswer.Append(CblVote.Items[i].Value.Trim() + ", ");     //將已選取資料整理放入變數
                }
            }
            if (sbAnswer.Length == 0)
            {
                this.ltMsg.Text = "<span style='color:red'>請勾選</span>";
                return;
            }
            sbAnswer = sbAnswer.Remove(sbAnswer.Length - 2, 2);

            DataTable objectValue = new DataTable();
            objectValue.Columns.Add("問卷名稱");
            objectValue.Columns.Add("姓名");
            objectValue.Columns.Add("手機");
            objectValue.Columns.Add("電子信箱");
            objectValue.Columns.Add("年齡");
            objectValue.Columns.Add("回答");
            objectValue.Rows.Add(id, name, phome, email, age, sbAnswer);

            Session.Add("Answer", objectValue);

            Response.Redirect("ConfirmPage.aspx");
        }

        protected void btnCel_Click(object sender, EventArgs e)
        {
            var Account = this.Session["User"].ToString();
            var level = UserInfoManager.GetUserInfobyAccount_ORM(Account);

            if (level.User_level == 0)
            {
                Response.Redirect("~/SystemAdmin/AdminList.aspx");
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");

            if (string.IsNullOrWhiteSpace(this.txbName.Text) || string.IsNullOrEmpty(this.txbName.Text))
                msglist.Add("<span style='color:red'>姓名為必填</span>");

            else if (string.IsNullOrWhiteSpace(this.txbMobilePhone.Text) || string.IsNullOrEmpty(this.txbMobilePhone.Text))
                msglist.Add("<span style='color:red'>電話為必填</span>");
            else if (this.txbMobilePhone.Text.Length != 10)
                msglist.Add("<span style='color:red'>電話長度應為10碼</span>");

            else if (string.IsNullOrWhiteSpace(this.txbEmail.Text) || string.IsNullOrEmpty(this.txbEmail.Text))
                msglist.Add("<span style='color:red'>信箱為必填</span>");

            else if (string.IsNullOrWhiteSpace(this.txbAge.Text) || string.IsNullOrEmpty(this.txbAge.Text))
                msglist.Add("<span style='color:red'>年齡為必填</span>");
            else if (this.txbAge.Text.Length > 3)
                msglist.Add("<span style='color:red'>年齡輸入有誤</span>");

            else if (!rx.IsMatch(txbName.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>姓名不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbMobilePhone.Text))
                msglist.Add("<span style='color:red'>電話不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbAge.Text))
                msglist.Add("<span style='color:red'>年齡不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
    }
}