using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class DetailSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetailSurvey.aspx");
        }

        protected void btnSed_Click(object sender, EventArgs e)
        {
            var title = this.txtName.Text;
            var memo = this.txtContent.Text;
            if (string.IsNullOrWhiteSpace(this.txbStr.Text) || string.IsNullOrEmpty(this.txbStr.Text))
            {
                this.ltMsg.Text = "<span style='color:red'>請輸入時間</span>";
                return;
            }
            DateTime str = DateTime.Parse(txbStr.Text);
            DateTime end = DateTime.Parse(this.txbEnd.Text);
            int use = 0;
            var Theme = AuthManager.GetTheme();
            var id = Theme.T_id + 1;

            if (CkbUse.Checked)
            {
                use = 1;
            }
            else
            {
                use = 0;
            }

            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }


            Theme theme = new Theme
            {
                T_id = id,
                T_title = title,
                T_state = use,
                T_memo = memo,
                T_start = str,
                T_end = end,
            };
            AuthManager.CreateTheme(theme);
            Response.Redirect("DetailQa.aspx");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z-/u3002/uff1b/uff0c/uff1a/u201c/u201d/uff08/uff09/u3001/uff1f/u300a/u300b]");

            if (string.IsNullOrWhiteSpace(this.txtName.Text) || string.IsNullOrEmpty(this.txtName.Text))
                msglist.Add("<span style='color:red'>請輸入問卷名稱</span>");

            else if (string.IsNullOrWhiteSpace(this.txtContent.Text) || string.IsNullOrEmpty(this.txtContent.Text))
                msglist.Add("<span style='color:red'>請輸入描述內容</span>");

            else if (!rx.IsMatch(txtName.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>問卷名稱不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txtContent.Text))
                msglist.Add("<span style='color:red'>描述內容不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
    }
}