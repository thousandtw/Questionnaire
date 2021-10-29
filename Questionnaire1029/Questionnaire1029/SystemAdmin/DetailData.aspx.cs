using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
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

        public DataTable ConvertToDataTable<T>(IList<T> data)         //List轉DataTable
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void EstablishCSV(DataTable dt, string fileName)    //匯出DataTable並下載為 CSV 檔
        {
            HttpContext.Current.Response.Clear();
            System.IO.StreamWriter sw = new System.IO.StreamWriter(Response.OutputStream, System.Text.Encoding.UTF8);//防止亂碼
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)//表頭
            {
                sw.Write("\"" + dt.Columns[i] + "\"");
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dt.Rows)//行內資料
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                        sw.Write("\"" + dr[i].ToString() + "\"");
                    else
                        sw.Write("\"\"");
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            HttpContext.Current.Response.Write(sw);
            HttpContext.Current.Response.End();
        }

        protected void btnSend_Click(object sender, EventArgs e)   
        {
            var list = AuthManager.GetAnswerList();
            DataTable table = ConvertToDataTable(list);
            string sFilename = "Questionnaire" + DateTime.Now.ToString("MMddHHmm") + ".CSV";//匯出的檔案名
            EstablishCSV(table, sFilename);
        }
    }
}