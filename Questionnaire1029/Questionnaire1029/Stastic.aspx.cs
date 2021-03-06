using NHibernate.Mapping;
using Questionnaire.Auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Questionnaire1029
{
    public partial class Stastic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idtxt = this.Request.QueryString["ID"];
                int id = int.Parse(idtxt);
                if (id > 0)
                {
                    var theme = AuthManager.GetThemeByID(id);
                    this.lblHeader.Text = theme.T_title;
                    string[] xValues = new string[100];
                    int[] yValues = new int[100];

                    string[] xValues2 = new string[100];
                    int[] yValues2 = new int[100];

                    string[] xValues3 = new string[100];
                    int[] yValues3 = new int[100];

                    List<string> MsgList = new List<string>();
                    List<string> MsgList2 = new List<string>();
                    List<string> MsgList3 = new List<string>();

                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;

                    var qc = AuthManager.GetAnswerListByID(id);
                    

                    //設定 Chart-------------------------------------------------------------------------
                    for (int s = 0; s < qc.Count(); s++)
                    {
                        if (string.IsNullOrWhiteSpace(qc[s].QC_ansrd1) || string.IsNullOrEmpty(qc[s].QC_ansrd1))
                        {
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < qc.Count(); i++)
                            {
                                string[] vs = qc[i].QC_ansrd1.Split(';');

                                for (int j = 0; j < vs.Count(); j++)
                                {
                                    MsgList.Add(vs[j].Trim());
                                }

                            }
                            var q =
                                       from p in MsgList
                                       group p by p.ToString() into g
                                       select new
                                       {
                                           g.Key,
                                           count = g.Count()
                                       };

                            var sum = q.ToList();

                            for (int y = 0; y < sum.Count(); y++)
                            {
                                xValues[y] = sum[y].Key.ToString();
                                yValues[y] = sum[y].count;
                            }
                            var char1 = StatisticsManager.statistics(xValues, yValues);

                            string ansr = sum[0].Key.ToString();
                            var qts = AuthManager.GetQuestionByID_ANSR(id, ansr);
                            string QT = qts.QT;
                            Label label1 = new Label();
                            label1.Text = QT;
                            label1.ID = $"lbl1{count1}";
                            count1 += 1;
                            Panel1.Controls.Add(label1);
                            Panel1.Controls.Add(char1);
                            break;
                        }
                    }
                    //設定 Chart2-------------------------------------------------------------------------

                    for (int s = 0; s < qc.Count(); s++)
                    {
                        if (string.IsNullOrWhiteSpace(qc[s].QC_ansrd2) || string.IsNullOrEmpty(qc[s].QC_ansrd2))
                        {
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < qc.Count(); i++)
                            {
                                string[] va = qc[i].QC_ansrd2.Split(';');

                                for (int j = 0; j < va.Count(); j++)
                                {
                                    MsgList2.Add(va[j].Trim());
                                }

                            }
                            var q2 =
                                     from p in MsgList2
                                     group p by p.ToString() into g
                                     select new
                                     {
                                         g.Key,
                                         count = g.Count()
                                     };

                            var sum2 = q2.ToList();

                            for (int y = 0; y < sum2.Count(); y++)
                            {
                                xValues2[y] = sum2[y].Key.ToString();
                                yValues2[y] = sum2[y].count;
                            }
                            var char2 = StatisticsManager.statistics(xValues2, yValues2);

                            string ansr2 = sum2[0].Key.ToString();
                            var qts2 = AuthManager.GetQuestionByID_ANSR(id, ansr2);
                            string QT2 = qts2.QT;
                            Label label2 = new Label();
                            label2.Text = QT2;
                            label2.ID = $"lbl2{count2}";
                            count2 += 1;
                            Panel2.Controls.Add(label2);
                            Panel2.Controls.Add(char2);
                            break;
                        }
                    }
                    //設定 Chart3-------------------------------------------------------------------------

                    for (int s = 0; s < qc.Count(); s++)
                    {
                        if (string.IsNullOrWhiteSpace(qc[s].QC_ansrd3) || string.IsNullOrEmpty(qc[s].QC_ansrd3))
                        {
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < qc.Count(); i++)
                            {
                                string[] vx = qc[i].QC_ansrd3.Split(';');

                                for (int j = 0; j < vx.Count(); j++)
                                {
                                    MsgList3.Add(vx[j].Trim());
                                }

                            }
                            var q3 =
                                      from p in MsgList3
                                      group p by p.ToString() into g
                                      select new
                                      {
                                          g.Key,
                                          count = g.Count()
                                      };

                            var sum3 = q3.ToList();

                            for (int y = 0; y < sum3.Count(); y++)
                            {
                                xValues3[y] = sum3[y].Key.ToString();
                                yValues3[y] = sum3[y].count;
                            }
                            var char3 = StatisticsManager.statistics(xValues3, yValues3);

                            Label label3 = new Label();
                            label3.Text = "其他";
                            label3.ID = $"lbl3{count3}";
                            count3 += 1;
                            Panel3.Controls.Add(label3);
                            Panel3.Controls.Add(char3);
                            break;
                        }
                    }
                }
            }
        }
    }
}