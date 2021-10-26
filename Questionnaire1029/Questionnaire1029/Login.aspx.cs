using Questionnaire.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txbAccount.Text;
            string inp_PWD = this.txbPassword.Text;

            string errormsg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out errormsg))
            {
                this.ltlMsg.Text = $"<span style='color:red'>{errormsg}</span>";
                return;
            }

            var level = UserInfoManager.GetUserInfobyAccount_ORM(inp_Account);
            if (level.User_level == 0)
            {
                Session["User"] = this.txbAccount.Text;
                Response.Redirect("~/SystemAdmin/AdminList.aspx");
            }
            else
            {
                Session["User"] = this.txbAccount.Text;
                Response.Redirect("List.aspx");
            }

        }
    }
}