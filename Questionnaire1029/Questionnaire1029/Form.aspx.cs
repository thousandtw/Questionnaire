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
                    var ID = AuthManager.GetThemeByID(id);
                    if (ID.T_state == 1)
                    {
                        this.lblState.Text = "投票中";
                        this.lblTime.Text = $"{ID.T_start.ToString()} ~ {ID.T_end.ToString()}";
                        this.lblHeader.Text = ID.T_title;
                        this.lblMemo.Text = ID.T_memo;
                    }

                    var GID = AuthManager.GetQuestionByID(id);
                    string A = GID.ANSR;
                    string[] sArray = A.Split(',');

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

            StringBuilder sbAnswer = new StringBuilder();

            for (int i = 0; i < CblVote.Items.Count; i++)
            {
                if (CblVote.Items[i].Selected)
                {
                    sbAnswer.Append(CblVote.Items[i].Value.Trim() + ", ");
                }
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
            Response.Redirect("List.aspx");
        }
    }
}