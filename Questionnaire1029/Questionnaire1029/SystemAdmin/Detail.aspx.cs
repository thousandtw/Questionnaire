using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IFRAME1.Attributes.Add("src", "DetailSurvey.aspx");
        }

        protected void btnSurvey_Click(object sender, EventArgs e)
        {
            IFRAME1.Attributes.Add("src", "DetailSurvey.aspx");
        }

        protected void btnQa_Click(object sender, EventArgs e)
        {
            IFRAME1.Attributes.Add("src", "DetailQa.aspx");
        }

        protected void btnData_Click(object sender, EventArgs e)
        {
            IFRAME1.Attributes.Add("src", "DetailData.aspx");
        }

        protected void btnCount_Click(object sender, EventArgs e)
        {
            IFRAME1.Attributes.Add("src", "DetailCount.aspx");
        }
    }
}