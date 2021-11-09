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
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = AuthManager.GeQuestionCommonList();
                this.gv_list.DataSource = list;
                if (list.Count > 0)
                {
                    var PagedList = this.GetPagedDataTable(list);
                    this.gv_list.DataSource = PagedList;
                    this.gv_list.DataBind();

                    this.ucPager.TotalSize = list.Count;
                    this.ucPager.Bind();
                }
                else
                {
                    this.gv_list.Visible = false;
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

        private List<Question_Common> GetPagedDataTable(List<Question_Common> list)
        {
            int startindex = (this.GetcurrentPage() - 1) * 10;
            return list.Skip(startindex).Take(10).ToList();
        }

        protected void btnSer_Click(object sender, EventArgs e)
        {
            this.ltlMsg.Visible = false;   //請保留(防止重複按下,提示訊息未清空)
            this.ucPager.Visible = true;

            if (txbSer.Text.Length > 0)
            {
                Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");           //正則表達式排除特殊字元
                string header= txbSer.Text;
                var list = AuthManager.GetQuestion_cmByHeader(header);

                if (!rx.IsMatch(txbSer.Text))
                {
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>問卷標題為特殊字元,請重新輸入</span>";
                    this.txbSer.Text = "";
                }
                else if (list.Count > 0)
                {
                    this.gv_list.Visible = true;
                    this.gv_list.DataSource = AuthManager.GetQuestion_cmByHeader(header);
                    this.gv_list.DataBind();
                    this.txbSer.Text = "";
                }
                else
                {
                    this.gv_list.Visible = false;
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>請輸入完整的問卷標題</span>";
                    this.txbSer.Text = "";
                    return;
                }
            }
        }
    }
}