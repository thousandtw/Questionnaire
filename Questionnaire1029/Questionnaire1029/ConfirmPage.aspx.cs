using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029
{
    public partial class ConfirmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["Answer"] == null)
            {
                HttpContext.Current.Response.Redirect("List.aspx");
            }
            DataTable Answer = (DataTable)Session["Answer"];

            string id = Answer.Rows[0]["問卷名稱"].ToString();
            string name = Answer.Rows[0]["姓名"].ToString();
            string phone = Answer.Rows[0]["手機"].ToString();
            string email = Answer.Rows[0]["電子信箱"].ToString();
            string age = Answer.Rows[0]["年齡"].ToString();


            int ids = int.Parse(id);
            var ID = AuthManager.GetThemeByID(ids);
            if (ID.T_state == 1)
            {
                this.lblVote.Text = "投票中";
                this.lblTime.Text = $"{ID.T_start.ToString()} ~ {ID.T_end.ToString()}";
                this.lblHeader.Text = ID.T_title;
            }

            lblaName.Text = name;
            lblMobilePhone.Text = phone;
            lblEmail.Text = email;
            lblAge.Text = age;

            string[] checkbox_sb = Answer.Rows[0]["複選方塊"].ToString().Split(',');
            for (int i = 0; i < checkbox_sb.Count(); i++)
            {
                Label label = new Label();
                label.Text = checkbox_sb[i].Trim();
                Panel1.Controls.Add(label);
            }
            string[] radiobutton_sb = Answer.Rows[0]["單選方塊"].ToString().Split(',');
            for (int i = 0; i < radiobutton_sb.Count(); i++)
            {
                Label label = new Label();
                label.Text = radiobutton_sb[i].Trim();
                Panel2.Controls.Add(label);
            }
            string[] textbox_sb = Answer.Rows[0]["文字方塊"].ToString().Split(',');
            for (int i = 0; i < textbox_sb.Count(); i++)
            {
                Label label = new Label();
                label.Text = textbox_sb[i].Trim();
                Panel3.Controls.Add(label);
            }

        }

        protected void Button1_Click(object sender, EventArgs e) { }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DataTable Answer = (DataTable)Session["Answer"];

            string id = Answer.Rows[0]["問卷名稱"].ToString();
            string name = Answer.Rows[0]["姓名"].ToString();
            string phone = Answer.Rows[0]["手機"].ToString();
            string email = Answer.Rows[0]["電子信箱"].ToString();
            string age = Answer.Rows[0]["年齡"].ToString();
            string checkbox_sb = Answer.Rows[0]["複選方塊"].ToString();
            string radiobutton_sb = Answer.Rows[0]["單選方塊"].ToString();
            string textbox_sb = Answer.Rows[0]["文字方塊"].ToString();
            int tid = int.Parse(id);

            string[] checkbox = checkbox_sb.Split(',');
            string[] radiobutton = radiobutton_sb.Split(',');
            string[] textbox = textbox_sb.Split(',');

            checkbox = checkbox.Where(val => val != "").ToArray();
            radiobutton = radiobutton.Where(val => val != "").ToArray();
            textbox = textbox.Where(val => val != "").ToArray();

            var qtList = AuthManager.GetQuestionList(tid);
            string ckb;
            string rad;
            string txb;

            for (int i = 0; i < qtList.Count; i++)                                      //移除問題,留答案
            {
                string vs = qtList[i].QT;
                string type = qtList[i].Q_type;
                string va = qtList[i].ANSR;

                if (type == "複選方塊")
                {
                   
                    checkbox = checkbox.Where(val => val != vs).ToArray();

                }

                if (type == "單選方塊")
                {
                    
                    radiobutton = radiobutton.Where(val => val != vs).ToArray();
                }
                if (type == "文字方塊")
                {
                    
                    textbox = textbox.Where(val => val != vs).ToArray();

                }
            }

            ckb = string.Join(",", checkbox);
            rad = string.Join(",", radiobutton);
            txb = string.Join(",", textbox);

            Answer answer = new Answer()
            {
                A_id = int.Parse(DateTime.Now.ToString("mmss")),
                T_id = int.Parse(id),
                A_name = name,
                A_phone = phone,
                A_email = email,
                A_age = age,
                QC_ansrd1 = ckb,
                QC_ansrd2 = rad,
                QC_ansrd3 = txb,
                CreateDate = DateTime.Now.ToLocalTime()
            };
            AuthManager.CreateAnswer(answer);
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
    }
}