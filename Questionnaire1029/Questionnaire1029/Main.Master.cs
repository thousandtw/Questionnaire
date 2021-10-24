using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ScriptManager1_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ViewState["postBackTimes"] = -1;
            }
            else
            {
                if (!this.ScriptManager1.IsInAsyncPostBack)
                { this.ViewState["postBackTimes"] = Convert.ToInt16(this.ViewState["postBackTimes"]) - 1; }

            }

            string gobackjs = @"function MyBack()
                            {history.go(" + Convert.ToString(this.ViewState["postBackTimes"]) + @");}";

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "back", gobackjs, true);
        }
    }
}