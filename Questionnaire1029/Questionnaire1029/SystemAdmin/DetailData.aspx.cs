using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class DetailData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = AuthManager.GetAnswerList();
                this.gv_Data.DataSource = list;
                if (list.Count > 0)
                {
                    var PagedList = this.GetPagedDataTable(list);
                    this.gv_Data.DataSource = PagedList;
                    this.gv_Data.DataBind();

                    this.ucPager.TotalSize = list.Count;
                    this.ucPager.Bind();
                }
                else
                {
                    this.gv_Data.Visible = false;
                    this.plcNoData.Visible = true;
                }
            }
        }

        private int GetcurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }

        private List<Answer> GetPagedDataTable(List<Answer> list)
        {
            int startindex = (this.GetcurrentPage() - 1) * 10;
            return list.Skip(startindex).Take(10).ToList();
        }


    }
}