using Questionnaire.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class DataConfirmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Aid = int.Parse(this.Request.QueryString["ID"]);
            var answer = AuthManager.GetAnswerByID(Aid);
            var Tid = answer.T_id;
            var theme = AuthManager.GetThemeByID(Tid);
            var question = AuthManager.GetQuestionByID(Tid);
            var questionList = AuthManager.GetQuestionList(Tid);
           
            this.txbName.Text = answer.A_name;
            this.txbEmail.Text = answer.A_email;
            this.txbMobilePhone.Text = answer.A_phone;
            this.txbAge.Text = answer.A_age;
            this.ltlTime.Text = answer.CreateDate.ToString();
            this.txbSurvey.Text = theme.T_title;
            for(int i = 0; i < questionList.Count(); i++)
            {
                txbQt.Text += questionList[i].QT.Trim() + "\r\n ";
                txbOptions.Text += questionList[i].ANSR.Trim() + "\r\n ";
            }
            this.txbAnswer.Text = answer.QC_ansrd1+ "\r\n "+answer.QC_ansrd2+ "\r\n "+answer.QC_ansrd3;

            this.txbName.Enabled=false;
            this.txbEmail.Enabled = false;
            this.txbMobilePhone.Enabled = false;
            this.txbAge.Enabled = false;
            this.txbSurvey.Enabled = false;
            this.txbQt.Enabled = false;
            this.txbOptions.Enabled = false;
            this.txbAnswer.Enabled = false;
        }
    }
}