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
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["User"] == null)
                {
                    HttpContext.Current.Response.Redirect("/Login.aspx");
                }

                var list = AuthManager.GeThemeList_ByState();
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

        private List<Theme> GetPagedDataTable(List<Theme> list)
        {
            int startindex = (this.GetcurrentPage() - 1) * 10;
            return list.Skip(startindex).Take(10).ToList();
        }

        protected void btnCrt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/Detail.aspx");
        }

        protected void btnSer_Click(object sender, EventArgs e)
        {
            this.ltlMsg.Visible = false;   //請保留(防止重複按下,提示訊息未清空)
            this.ucPager.Visible = true;

            if (txbHeader.Text.Length > 0 && txbStr.Text.Length > 0 && txbEnd.Text.Length > 0)
            {
                this.txbHeader.Text = "";
                this.txbStr.Text = "";
                this.txbEnd.Text = "";
                this.gv_list.Visible = false;
                this.ucPager.Visible = false;
                this.ltlMsg.Visible = true;
                this.ltlMsg.Text = "<span style='color:red'>問卷標題或問卷時間,請選擇其中一項搜尋</span>";
            }
            else if (txbHeader.Text.Length > 0)
            {
                this.txbStr.Text = "";
                this.txbEnd.Text = "";
                Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");           //正則表達式排除特殊字元
                var list = AuthManager.GetThemesByHeader(txbHeader.Text);

                if (!rx.IsMatch(txbHeader.Text))
                {
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>問卷標題為特殊字元,請重新輸入</span>";
                    this.txbHeader.Text = "";
                }
                else if (list.Count > 0)
                {
                    this.gv_list.Visible = true;
                    this.gv_list.DataSource = AuthManager.GetThemesByHeader(txbHeader.Text);
                    this.gv_list.DataBind();
                    this.txbHeader.Text = "";
                }
                else
                {
                    this.gv_list.Visible = false;
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>請輸入完整的問卷標題</span>";
                    this.txbHeader.Text = "";
                    return;
                }
            }
            else if (txbStr.Text.Length > 0 || txbEnd.Text.Length > 0)
            {
                this.txbHeader.Text = "";
                if (string.IsNullOrWhiteSpace(this.txbStr.Text) || string.IsNullOrEmpty(this.txbEnd.Text)) // 檢查有無輸入日期
                {
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>搜尋日期有錯誤,請重新選取日期</span>";
                    this.txbStr.Text = "";
                    this.txbEnd.Text = "";
                }

                string start = this.txbStr.Text;
                string end = this.txbEnd.Text;
                try                                // 檢查是否符合DateTime格式(例外輸入狀況:年份五位數)
                {
                    DateTime.Parse(start);
                    DateTime.Parse(end);
                }
                catch (Exception)
                {
                    this.gv_list.Visible = false;
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>搜尋日期有錯誤,請重新選取日期</span>";
                    this.txbStr.Text = "";
                    this.txbEnd.Text = "";
                    return;
                }
                DateTime startTime = Convert.ToDateTime(start);
                DateTime endTime = Convert.ToDateTime(end);
                var list = AuthManager.GetThemeByDate(startTime, endTime);

                if (list.Count > 0)  // 檢查有無資料
                {
                    this.gv_list.Visible = true;
                    this.gv_list.DataSource = AuthManager.GetThemeByDate(startTime, endTime);
                    this.gv_list.DataBind();
                    this.txbStr.Text = "";
                    this.txbEnd.Text = "";
                }
                else
                {
                    this.gv_list.Visible = false;
                    this.ltlMsg.Visible = true;
                    this.ltlMsg.Text = "<span style='color:red'>搜尋日期有錯誤,請重新選取日期</span>";
                    this.txbStr.Text = "";
                    this.txbEnd.Text = "";
                }
            }
            else
            {
                this.gv_list.Visible = false;
                this.ltlMsg.Visible = true;
                this.ucPager.Visible = false;
                this.ltlMsg.Text = "<span style='color:red'>問卷標題或問卷時間,請選擇其中一項搜尋</span>";
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv_list.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                    Label lbID = (Label)row.FindControl("lbID");
                    if (cbox.Checked)
                    {
                        int id = int.Parse(lbID.Text);
                        AuthManager.DeleteTheme(id);
                        AuthManager.DeleteQuestion(id);
                        AuthManager.DeleteAnswer(id);
                    }
                }
            }
            Response.Redirect("/SystemAdmin/AdminList.aspx");
        }
    }
}