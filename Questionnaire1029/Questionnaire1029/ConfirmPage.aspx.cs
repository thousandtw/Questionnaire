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
            string Answers = Answer.Rows[0]["回答"].ToString();

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

            string[] sArray = Answers.Split(',');

            for (int i = 0; i < sArray.Length; i++)
            {
                ltbVote.Items.Add(sArray[i].ToString());
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DataTable Answer = (DataTable)Session["Answer"];

            string id = Answer.Rows[0]["問卷名稱"].ToString();
            string name = Answer.Rows[0]["姓名"].ToString();
            string phone = Answer.Rows[0]["手機"].ToString();
            string email = Answer.Rows[0]["電子信箱"].ToString();
            string age = Answer.Rows[0]["年齡"].ToString();
            string Answers = Answer.Rows[0]["回答"].ToString();

            Answer answer = new Answer()
            {
                A_id = int.Parse(DateTime.Now.ToString("mmss")),
                T_id = int.Parse(id),
                A_name = name,
                A_phone = phone,
                A_email = email,
                A_age = age,
                QC_ansrd1 = Answers
            };
            AuthManager.CreateAnswer(answer);
            Response.Redirect("List.aspx");
        }
    }
}