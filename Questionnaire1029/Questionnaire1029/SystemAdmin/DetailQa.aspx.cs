using Bogus;
using Questionnaire.Auth;
using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                var qtcm = AuthManager.GetQuestionCmList();

                for (int i = 0; i < qtcm.Count; i++)
                {
                    string title = qtcm[i].QC_title.ToString();
                    string id = qtcm[i].QC_id.ToString();
                    ddl_Type.Items.Add(new ListItem(title, id));
                }
                AddDefaultFirstRecord();

                //創建表單2  
                DataTable dt = new DataTable();
                DataRow dr;
                dt.TableName = "Answer2";
                dt.Columns.Add(new DataColumn("qt", typeof(string)));
                dt.Columns.Add(new DataColumn("ans", typeof(string)));
                dt.Columns.Add(new DataColumn("type", typeof(string)));
                dt.Columns.Add(new DataColumn("must", typeof(string)));
                dt.Columns.Add(new DataColumn("Qd", typeof(int)));
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                //將表單存到ViewState
                ViewState["Answer2"] = dt;
            }
        }

        protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)  //依照常用問題選擇填入
        {
            if (ddl_Type.SelectedIndex != 0)
            {
                var id = int.Parse(ddl_Type.SelectedValue);
                var qtcm = AuthManager.GetQuestionCMbyID(id);
                txtQT.Text = qtcm.QC_title;
                txbAns.Text = qtcm.ANSR_1;

                if (qtcm.QC_type == "複選方塊")
                {
                    ddl_QT.SelectedValue = "1";
                }
                else if (qtcm.QC_type == "單選方塊")
                {
                    ddl_QT.SelectedValue = "2";
                }
                else
                {
                    ddl_QT.SelectedValue = "3";
                }

                if (qtcm.QC_mustKeyin == "是")
                {
                    CkbMust.Checked = true;
                }
                else
                {
                    CkbMust.Checked = false;
                }
            }
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            this.ltlMsg.Text = "";
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
                        string value;
                        if (ddl_QT.SelectedValue == "1")
                        {
                            value = "複選方塊";
                            drCurrentRow["type"] = value;
                        }
                        else if (ddl_QT.SelectedValue == "2")
                        {
                            value = "單選方塊";
                            drCurrentRow["type"] = value;
                        }
                        else if (ddl_QT.SelectedValue == "3")
                        {
                            value = "文字方塊";
                            drCurrentRow["type"] = value;
                        }
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
            int count = 0;
            foreach (GridViewRow row in gv_Qa.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[0].FindControl("Ckbchoose") as CheckBox);
                    if (cbox.Checked)
                    {
                        var Qid = int.Parse(DateTime.Now.ToString("sssffff"));
                        int Tid = int.Parse(Session["T_id"].ToString());
                        var QTS = row.Cells[2].Text;
                        var ANSRS = row.Cells[3].Text;
                        var ANSRsum = row.Cells[3].Text.Split(';').Count();
                        var Qtype = row.Cells[4].Text;
                        var QmustKeyin = row.Cells[5].Text;

                        Question question = new Question
                        {
                            Q_id = Qid,
                            T_id = Tid,
                            QT = QTS,
                            ANSR = ANSRS,
                            ANSR_sum = ANSRsum,
                            Q_type = Qtype,
                            Q_mustKeyin = QmustKeyin
                        };
                        AuthManager.CreateQT(question);
                        count += 1;
                    }
                }
            }
            if (count == 0)
            {
                this.ltlMsg.Text = "<span style='color:red'>請勾選問題後,再送出</span>";
                return;
            }
            else
            {
                Response.Redirect("DetailData.aspx");
            }
        }

        protected void btnCel_Click(object sender, EventArgs e)
        {
            var tid = int.Parse(Session["T_id"].ToString());
            AuthManager.DeleteTheme(tid);
            Response.Redirect("DetailSurvey.aspx");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int count = 0;
            int sum = 1;
            int s = 0;
            foreach (GridViewRow row in gv_Qa.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbox = (row.Cells[0].FindControl("Ckbchoose") as CheckBox);

                    if (cbox.Checked)
                    {
                        DataTable dtCurrentTable = (DataTable)ViewState["Answer"];
                        int idx = row.RowIndex;

                        if (idx == 0)                                  //如果從索引1開始刪除第一個勾選資料
                        {
                            
                            dtCurrentTable.Rows[idx].Delete();
                            dtCurrentTable.AcceptChanges();
                            ViewState["Answer2"] = dtCurrentTable;     //因為後面綁定初始值ViewState["Answer"]恢復初始值,先將刪除後資料放入新的ViewState存放

                            //綁上Gridview的新Row
                            gv_Qa.DataSource = dtCurrentTable;
                            gv_Qa.DataBind();
                            s += 1;
                            AddDefaultFirstRecord();                   //重新綁定初始資料格

                            DataTable dtCurrentTable2 = (DataTable)ViewState["Answer2"];
                            ViewState["Answer"] = dtCurrentTable2;    //將刪除後資料放入原ViewState["Answer"]
                            gv_Qa.DataSource = dtCurrentTable2;
                            gv_Qa.DataBind();

                            if (dtCurrentTable2.Rows.Count < 1)
                            {
                                AddDefaultFirstRecord();                   //重新綁定初始資料格
                            }
                        }
                        else if (s > 0)                               //刪除多筆,調整索引值
                        {
                            dtCurrentTable.Rows[idx-sum].Delete();
                            dtCurrentTable.AcceptChanges();

                            ViewState["Answer2"] = dtCurrentTable;
                            //綁上Gridview的新Row
                            gv_Qa.DataSource = dtCurrentTable;
                            gv_Qa.DataBind();

                            AddDefaultFirstRecord();                  

                            DataTable dtCurrentTable2 = (DataTable)ViewState["Answer2"];
                            ViewState["Answer"] = dtCurrentTable2;
                            gv_Qa.DataSource = dtCurrentTable2;
                            gv_Qa.DataBind();
                            sum += 1;
                        }

                        if (idx > 0 && s == 0)                         //如果從索引1以外的開始刪除第一個勾選資料
                        {
                            if (count == 0)                            //計算是否刪除多個
                            {
                                dtCurrentTable.Rows[idx].Delete();
                                dtCurrentTable.AcceptChanges();
                                ViewState["Answer"] = dtCurrentTable;
                                //綁上Gridview的新Row
                                gv_Qa.DataSource = dtCurrentTable;
                                gv_Qa.DataBind();
                                count += 1;
                            }
                            else                                       //刪除多筆,調整索引值
                            {
                                dtCurrentTable.Rows[idx - sum].Delete();
                                dtCurrentTable.AcceptChanges();
                                ViewState["Answer"] = dtCurrentTable;
                                //綁上Gridview的新Row
                                gv_Qa.DataSource = dtCurrentTable;
                                gv_Qa.DataBind();
                                sum += 1;
                            }
                        }
                    }
                }
            }
        }

        protected void gv_Qa_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "LkB")
            {
                //拿到linkButton所在的GridViewRow
                GridViewRow gvrow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int index = gvrow.RowIndex;

                //string Qdid = gv_Qa.Rows[index].Cells[1].Text.Trim();
                string qt = gv_Qa.Rows[index].Cells[2].Text.Trim();
                string ans = gv_Qa.Rows[index].Cells[3].Text.Trim();
                string type = gv_Qa.Rows[index].Cells[4].Text.Trim();
                string must = gv_Qa.Rows[index].Cells[5].Text.Trim();

                txtQT.Text = qt;
                txbAns.Text = ans;

                if (type == "複選方塊")
                {
                    ddl_QT.SelectedValue = "1";
                }
                else if (type == "單選方塊")
                {
                    ddl_QT.SelectedValue = "2";
                }
                else
                {
                    ddl_QT.SelectedValue = "3";
                }

                if (must == "是")
                {
                    CkbMust.Checked = true;
                }
                else
                {
                    CkbMust.Checked = false;
                }

                if (index == 0)                                                     //如果從索引1開始刪除第一個勾選資料
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Answer"];
                    dtCurrentTable.Rows[index].Delete();
                    dtCurrentTable.AcceptChanges();
                    ViewState["Answer2"] = dtCurrentTable;                          //提前先將刪除後資料放入新的ViewState存放
                    //綁上Gridview的新Row
                    gv_Qa.DataSource = dtCurrentTable;
                    gv_Qa.DataBind();
                    AddDefaultFirstRecord();                                        //重新綁定初始資料格
                    DataTable dtCurrentTable2 = (DataTable)ViewState["Answer2"];
                    ViewState["Answer"] = dtCurrentTable2;                          //將刪除後資料放入原ViewState["Answer"]
                    gv_Qa.DataSource = dtCurrentTable2;
                    gv_Qa.DataBind();
                    if (dtCurrentTable2.Rows.Count < 1)                             
                    {
                        AddDefaultFirstRecord();                                    //重新綁定初始資料格
                    }
                }
                else
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Answer"];
                    dtCurrentTable.Rows[index].Delete();
                    dtCurrentTable.AcceptChanges();
                    ViewState["Answer"] = dtCurrentTable;
                    //綁上Gridview的新Row
                    gv_Qa.DataSource = dtCurrentTable;
                    gv_Qa.DataBind();
                }
            }
        }

        protected void gv_Qa_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //從第一列檢索 LinkBut​​ton 控件

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LkB1");

                //使用行的索引設置 LinkBut​​ton 的 CommandArgument屬性

                LinkButton1.CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z-/u3002/uff1b/uff0c/uff1a/u201c/u201d/uff08/uff09/u3001/uff1f/u300a/u300b]");

            if (string.IsNullOrWhiteSpace(this.txtQT.Text) || string.IsNullOrEmpty(this.txtQT.Text))
                msglist.Add("<span style='color:red'>請輸入問題</span>");

            else if (string.IsNullOrWhiteSpace(this.txbAns.Text) || string.IsNullOrEmpty(this.txbAns.Text))
                msglist.Add("<span style='color:red'>請輸入[無]</span>");

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