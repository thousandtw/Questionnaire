using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class DetailQa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            var qt = this.txtQT.Text;
            var ans = this.txbAns.Text;
            var type = this.ddl_QT.Text;
            string must;
            if (CkbMust.Checked)
            {
                must = "是";
            }
            else
            {
                must = "否";
            }

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("qt", typeof(string));
            dt1.Columns.Add("ans", typeof(string));
            dt1.Columns.Add("type", typeof(string));
            dt1.Columns.Add("must", typeof(string));

            DataRow dr = dt1.NewRow();
            gv_Qa.DataSource = dt1;    //將畫面上要顯示的GridView資料來源綁定為DataTable
            gv_Qa.DataBind();
            dr["qt"] = qt;
            dr["ans"] = ans;
            dr["type"] = type;
            dr["must"] = must;
            dt1.Rows.Add(dr);

            gv_Qa.DataBind();
            //Response.Redirect("DetailQa.aspx");

        }

        protected void gv_Qa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)                    //GridView自動編號
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = id.ToString();
            }
        }

        protected void btnSed_Click(object sender, EventArgs e)
        {
            //var qt = this.txtQT.Text;
            //var ans = this.txbAns.Text;
            //var type = this.ddl_QT.Text;
            //int must = 0;
            //if (this.CkbMust.Checked)
            //{
            //    must = 1;
            //}
            //DataTable objectValue = new DataTable();
            //objectValue.Columns.Add("問題");
            //objectValue.Columns.Add("回答");
            //objectValue.Columns.Add("種類");
            //objectValue.Columns.Add("必填");
            //objectValue.Rows.Add(qt, ans, type, must);

            //Session.Add("QT", objectValue);
        }
    }
}