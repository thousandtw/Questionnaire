using Bogus;
using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class DetailQa : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["T_id"] == null)
            {
                Response.Redirect("DetailSurvey.aspx");
            }
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();
            }
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltlMsg.Text = string.Join("<br/>", msgList);
                return;
            }
            AddNewRecordRowToGrid();
        }

        private void AddDefaultFirstRecord()
        {
            //創建表單  
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "Answer";
            dt.Columns.Add(new DataColumn("qt", typeof(string)));
            dt.Columns.Add(new DataColumn("ans", typeof(string)));
            dt.Columns.Add(new DataColumn("type", typeof(string)));
            dt.Columns.Add(new DataColumn("must", typeof(string)));
            dt.Columns.Add(new DataColumn("Qd", typeof(int)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //將表單存到ViewState
            ViewState["Answer"] = dt;
            //綁定ViewState 
            gv_Qa.DataSource = dt;
            gv_Qa.DataBind();
        }

        private void AddNewRecordRowToGrid()
        {
            // 檢查ViewState
            if (ViewState["Answer"] != null)
            {
                //從ViewState取表單   
                DataTable dtCurrentTable = (DataTable)ViewState["Answer"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    string must;
                    if (CkbMust.Checked)
                    {
                        must = "是";
                    }
                    else
                    {
                        must = "否";
                    }

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //將每一行加到表單中  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["qt"] = txtQT.Text;
                        drCurrentRow["ans"] = txbAns.Text;
                        drCurrentRow["type"] = ddl_QT.Text;
                        drCurrentRow["must"] = must;
                        drCurrentRow["Qd"] = 0;
                    }
                    //刪初始空行  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }

                    //將新增的行加到表單中   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //新增每一行,將表單存到ViewState
                    ViewState["Answer"] = dtCurrentTable;
                    //綁上Gridview的新Row
                    gv_Qa.DataSource = dtCurrentTable;
                    gv_Qa.DataBind();
                }
            }
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
            foreach (GridViewRow row in gv_Qa.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[0].FindControl("Ckbchoose") as CheckBox);
                    if (cbox.Checked)
                    {
                        var Qid = int.Parse(DateTime.Now.ToString("MMddHHmmss"));
                        int Tid = int.Parse(Session["T_id"].ToString());
                        var QTS = row.Cells[2].Text;
                        var ANSRS = row.Cells[3].Text;
                        var ANSRsum = row.Cells[3].Text.Split(',').Count();
                        var Qtype = row.Cells[4].Text;
                        var QmustKeyin = row.Cells[5].Text;

                        Question question = new Question
                        {
                            Q_id=Qid,
                            T_id=Tid,
                            QT=QTS,
                            ANSR=ANSRS,
                            ANSR_sum=ANSRsum,
                            Q_type=Qtype,
                            Q_mustKeyin=QmustKeyin
                        };
                         AuthManager.CreateQT(question);
                    }
                }
            }
            Response.Redirect("DetailData.aspx");
        }

        protected void btnCel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetailSurvey.aspx");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv_Qa.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[0].FindControl("Ckbchoose") as CheckBox);
                    if (cbox.Checked)
                    {
                        row.Cells.Clear();
                    }
                }
            }
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z-/u3002/uff1b/uff0c/uff1a/u201c/u201d/uff08/uff09/u3001/uff1f/u300a/u300b]");

            if (string.IsNullOrWhiteSpace(this.txtQT.Text) || string.IsNullOrEmpty(this.txtQT.Text))
                msglist.Add("<span style='color:red'>請輸入問題</span>");

            else if (string.IsNullOrWhiteSpace(this.txbAns.Text) || string.IsNullOrEmpty(this.txbAns.Text))
                msglist.Add("<span style='color:red'>請輸入回答</span>");

            else if (!rx.IsMatch(txtQT.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>問題不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbAns.Text))
                msglist.Add("<span style='color:red'>回答不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
    }
}