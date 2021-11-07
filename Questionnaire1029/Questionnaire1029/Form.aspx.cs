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


namespace Questionnaire1029
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idtxt = this.Request.QueryString["ID"];

            int id = int.Parse(idtxt);
            if (id > 0)
            {
                var ID = AuthManager.GetThemeByID(id);
                var list = AuthManager.GetQuestionList(id);                      //取出資料庫內的清單
                DataTable dataTable = AuthManager.ConvertToDataTable(list);      //轉dataTable

                object[][] LoadData = new object[dataTable.Rows.Count][];        //宣告二維陣列
                string[] vs;
                string QT;
                string ANSR;
                string QTYPE;
                int s = 0;
                int y = 0;
                int z = 0;

                for (int i = 0; i < dataTable.Rows.Count; i++)             //將dataTable放入二維陣列
                {
                    LoadData[i] = new object[dataTable.Columns.Count];

                    for (int j = 0; j < dataTable.Columns.Count; j++)

                    {
                        LoadData[i][j] = dataTable.Rows[i][j].ToString();
                    }

                    var qt = LoadData[i][2];                              //表單中的問題
                    var ansr = LoadData[i][3];                            //表單中的選項
                    var qtype = LoadData[i][5];                           //表單中的種類
                    QT = Convert.ToString(qt);
                    ANSR = Convert.ToString(ansr);
                    QTYPE = Convert.ToString(qtype);

                    if (QTYPE == "複選方塊")                              //如果種類為複選方塊
                    {
                        vs = ANSR.Split(',');                             //切割選項
                        Label label_1 = new Label();                      //宣告Label
                        label_1.ID = $"lbl1{s}";
                        label_1.Text = QT;                                //將問題放入label_1並換行
                        Panel1.Controls.Add(label_1);                     //將label_1放入Panel_1

                        s += 1;

                        for (int x = 0; x < vs.Length; x++)
                        {
                            CheckBox checkBox = new CheckBox();           //宣告CheckBox
                            checkBox.ID = $"ckb{x}";
                            checkBox.Text = vs[x].ToString();             //將選項放入CheckBox
                            Panel1.Controls.Add(checkBox);                //將checkBox放入panel_1
                        }
                    }
                    else if (QTYPE == "單選方塊")                         //如果種類為單選方塊
                    {

                        vs = ANSR.Split(',');
                        Label label_2 = new Label();


                        label_2.ID = $"lbl2{y}";
                        label_2.Text = QT;
                        Panel2.Controls.Add(label_2);
                        y += 1;

                        for (int x = 0; x < vs.Length; x++)
                        {
                            RadioButton radioButton = new RadioButton();
                            radioButton.ID = $"rdb{x}";
                            radioButton.GroupName = "RBT";
                            radioButton.Text = vs[x].ToString();
                            Panel2.Controls.Add(radioButton);
                        }
                    }
                    else                                                  //如果種類為文字方塊
                    {

                        vs = ANSR.Split(',');
                        Label label_3 = new Label();
                        label_3.ID = $"lbl3{z}";
                        label_3.Text = QT;
                        Panel3.Controls.Add(label_3);
                        z += 1;

                        for (int x = 0; x < vs.Length; x++)
                        {
                            TextBox textBox = new TextBox();
                            textBox.ID = $"txb{x}";
                            Panel3.Controls.Add(textBox);
                        }
                    }
                }
                Session["lbl1"] = s;
                Session["lbl2"] = y;
                Session["lbl3"] = z;
                this.lblState.Text = "投票中";
                this.lblTime.Text = $"{ID.T_start.ToString()} ~ {ID.T_end.ToString()}";
                this.lblHeader.Text = ID.T_title;
                this.lblMemo.Text = ID.T_memo;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string idtxt = this.Request.QueryString["ID"];
            int id = int.Parse(idtxt);
            var name = txbName.Text;
            var phome = txbMobilePhone.Text;
            var email = txbEmail.Text;
            var age = txbAge.Text;

            this.ltMsg.Text = "";
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            //------以下開始取複選方塊------

            StringBuilder checkbox_sb = new StringBuilder();

            var lblA = Session["lbl1"].ToString();

            if (lblA != "0")
            {
                var lbl1count = int.Parse(Session["lbl1"].ToString());
                string qt = "";
                for (int s = 0; s < lbl1count; s++)
                {
                    var lbl1 = Panel1.FindControl($"lbl1{s}") as Label;
                    checkbox_sb.Append(lbl1.Text.Trim() + ", ");
                    qt = lbl1.Text;
                    var Qtn = AuthManager.GetQuestionByID_QT(id, qt);
                    var mustKeyin = Qtn.Q_mustKeyin;                                  //取出是否必填
                    var count = Qtn.ANSR_sum;
                    int sum = 0;
                    if (mustKeyin == "是")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if ((Panel1.FindControl($"ckb{i}") as CheckBox).Checked)
                            {
                                var cbx1 = Panel1.FindControl($"ckb{i}") as CheckBox;
                                checkbox_sb.Append(cbx1.Text.Trim() + ", ");
                                sum += 1;
                            }
                        }
                        if (sum == 0)
                        {
                            this.ltMsg.Text = $"<span style='color:red'>{qt}問題為必填,請勾選</span>";
                            return;
                        }
                        checkbox_sb = checkbox_sb.Remove(checkbox_sb.Length - 2, 2);
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if ((Panel1.FindControl($"ckb{i}") as CheckBox).Checked)
                            {
                                var cbx1 = Panel1.FindControl($"ckb{i}") as CheckBox;
                                checkbox_sb.Append(cbx1.Text.Trim() + ", ");
                            }
                        }
                    }
                }
                //checkbox_sb = checkbox_sb.Remove(checkbox_sb.Length - 2, 2);
            }

            //------以下開始取單選方塊------

            StringBuilder radiobutton_sb = new StringBuilder();

            var lblB = Session["lbl2"].ToString();

            if (lblB != "0")
            {
                var lbl1count2 = int.Parse(Session["lbl2"].ToString());
                string qt2 = "";
                for (int s = 0; s < lbl1count2; s++)
                {
                    var lbl2 = Panel2.FindControl($"lbl2{s}") as Label;
                    radiobutton_sb.Append(lbl2.Text.Trim() + ", ");
                    qt2 = lbl2.Text;
                    var Qtn2 = AuthManager.GetQuestionByID_QT(id, qt2);                         //取出是否必填
                    var mustKeyin2 = Qtn2.Q_mustKeyin;
                    var count2 = Qtn2.ANSR_sum;
                    int sum2 = 0;
                    if (mustKeyin2 == "是")
                    {
                        for (int i = 0; i < count2; i++)
                        {
                            if ((Panel2.FindControl($"rdb{i}") as RadioButton).Checked)
                            {
                                var rdb2 = Panel2.FindControl($"rdb{i}") as RadioButton;
                                radiobutton_sb.Append(rdb2.Text.Trim() + ", ");
                                sum2 += 1;
                            }
                        }
                        if (sum2 == 0)
                        {
                            this.ltMsg.Text = $"<span style='color:red'>{qt2}問題為必填,請勾選</span>";
                            return;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count2; i++)
                        {
                            if ((Panel2.FindControl($"rdb{i}") as RadioButton).Checked)
                            {
                                var rdb2 = Panel2.FindControl($"rdb{i}") as RadioButton;
                                radiobutton_sb.Append(rdb2.Text.Trim() + ", ");
                            }
                        }
                    }
                }
                radiobutton_sb = radiobutton_sb.Remove(radiobutton_sb.Length - 2, 2);
            }
                

            //------以下開始取文字方塊------

            StringBuilder textbox_sb = new StringBuilder();

            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");

            var lblC = Session["lbl3"].ToString();

            if (lblC != "0")
            {
                var lbl1count3 = int.Parse(Session["lbl3"].ToString());
                string qt3 = "";
                for (int s = 0; s < lbl1count3; s++)
                {
                    var lbl3 = Panel3.FindControl($"lbl3{s}") as Label;
                    textbox_sb.Append(lbl3.Text.Trim() + ", ");
                    qt3 = lbl3.Text;
                    var Qtn3 = AuthManager.GetQuestionByID_QT(id, qt3);                         //取出是否必填
                    var mustKeyin3 = Qtn3.Q_mustKeyin;
                    var count3 = Qtn3.ANSR_sum;
                    int sum3 = 0;


                    if (mustKeyin3 == "是")
                    {
                        for (int i = 0; i < count3; i++)
                        {
                            if (!rx.IsMatch((Panel3.FindControl($"txb{i}") as TextBox).Text))
                            {
                                this.ltMsg.Text = $"<span style='color:red'>答案不能為特殊字元,請重新輸入</span>";
                                return;
                            }
                            if ((Panel3.FindControl($"txb{i}") as TextBox).Text != "")
                            {
                                var txb3 = Panel3.FindControl($"txb{i}") as TextBox;
                                textbox_sb.Append(txb3.Text.Trim() + ", ");
                                sum3 += 1;
                            }
                        }
                        if (sum3 == 0)
                        {
                            this.ltMsg.Text = $"<span style='color:red'>{qt3}問題為必填,請輸入</span>";
                            return;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count3; i++)
                        {
                            if ((Panel3.FindControl($"txb{i}") as TextBox).Text != "")
                            {
                                var txb3 = Panel3.FindControl($"txb{i}") as TextBox;
                                textbox_sb.Append(txb3.Text.Trim() + ", ");
                            }
                        }
                    }
                }

                textbox_sb = textbox_sb.Remove(textbox_sb.Length - 2, 2);
            }
           


            DataTable objectValue = new DataTable();
            objectValue.Columns.Add("問卷名稱");
            objectValue.Columns.Add("姓名");
            objectValue.Columns.Add("手機");
            objectValue.Columns.Add("電子信箱");
            objectValue.Columns.Add("年齡");
            objectValue.Columns.Add("複選方塊");
            objectValue.Columns.Add("單選方塊");
            objectValue.Columns.Add("文字方塊");
            objectValue.Rows.Add(id, name, phome, email, age, checkbox_sb, radiobutton_sb, textbox_sb);

            Session.Add("Answer", objectValue);

            Response.Redirect("ConfirmPage.aspx");
        }

        protected void btnCel_Click(object sender, EventArgs e)
        {
            var Account = this.Session["User"].ToString();
            var level = UserInfoManager.GetUserInfobyAccount_ORM(Account);

            if (level.User_level == 0)
            {
                Response.Redirect("~/SystemAdmin/AdminList.aspx");
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msglist = new List<string>();
            Regex rx = new Regex(@"[\d\u4E00-\u9FA5A-Za-z]");

            if (string.IsNullOrWhiteSpace(this.txbName.Text) || string.IsNullOrEmpty(this.txbName.Text))
                msglist.Add("<span style='color:red'>姓名為必填</span>");

            else if (string.IsNullOrWhiteSpace(this.txbMobilePhone.Text) || string.IsNullOrEmpty(this.txbMobilePhone.Text))
                msglist.Add("<span style='color:red'>電話為必填</span>");
            else if (this.txbMobilePhone.Text.Length != 10)
                msglist.Add("<span style='color:red'>電話長度應為10碼</span>");

            else if (string.IsNullOrWhiteSpace(this.txbEmail.Text) || string.IsNullOrEmpty(this.txbEmail.Text))
                msglist.Add("<span style='color:red'>信箱為必填</span>");

            else if (string.IsNullOrWhiteSpace(this.txbAge.Text) || string.IsNullOrEmpty(this.txbAge.Text))
                msglist.Add("<span style='color:red'>年齡為必填</span>");
            else if (this.txbAge.Text.Length > 3)
                msglist.Add("<span style='color:red'>年齡輸入有誤</span>");

            else if (!rx.IsMatch(txbName.Text))                                                  //正則表達式排除特殊字元
                msglist.Add("<span style='color:red'>姓名不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbMobilePhone.Text))
                msglist.Add("<span style='color:red'>電話不能為特殊字元,請重新輸入</span>");

            else if (!rx.IsMatch(txbAge.Text))
                msglist.Add("<span style='color:red'>年齡不能為特殊字元,請重新輸入</span>");

            errorMsgList = msglist;

            if (msglist.Count == 0)
                return true;
            else
                return false;
        }
    }
}