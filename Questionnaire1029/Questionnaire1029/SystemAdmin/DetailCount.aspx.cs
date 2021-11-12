using Questionnaire.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire1029.SystemAdmin
{
    public partial class DetailCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] xValues = new string[100];
                int[] yValues = new int[100];
                string[] xValues2 = new string[100];
                int[] yValues2 = new int[100];
                List<string> myLists = new List<string>();
                List<string> myLists2 = new List<string>();
                var answer = AuthManager.GetAnswerList();

                //    ////統計複選方塊-------------------------------------------------------------------------
                for (int i = 0; i < answer.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(answer[i].QC_ansrd1) || !string.IsNullOrEmpty(answer[i].QC_ansrd1))
                    {

                        string[] vs = answer[i].QC_ansrd1.Split(',');
                        for (int j = 0; j < vs.Count(); j++)
                        {
                            myLists.Add(vs[j].Trim());
                        }

                        var q =
                                from p in myLists
                                group p by p.ToString() into g
                                select new
                                {
                                    g.Key,
                                    count = g.Count()
                                };
                        var sum = q.ToList();

                        for (int j = 0; j < sum.Count(); j++)
                        {
                            xValues[j] = sum[j].Key;
                            yValues[j] = sum[j].count;
                        }
                    }
                }
                var char1 = StatisticsManager.statistics(xValues, yValues);
                Label label1 = new Label();
                label1.Text = "複選方塊";
                Panel1.Controls.Add(label1);
                Panel1.Controls.Add(char1);

                //統計單選方塊-------------------------------------------------------------------------

                for (int k = 0; k < answer.Count; k++)
                {
                    if (!string.IsNullOrWhiteSpace(answer[k].QC_ansrd2) || !string.IsNullOrEmpty(answer[k].QC_ansrd2))
                    {
                        string[] vs = answer[k].QC_ansrd2.Split(',');
                        for (int j = 0; j < vs.Count(); j++)
                        {
                            myLists2.Add(vs[j].Trim());
                        }

                        var q2 =
                                        from p in myLists2
                                        group p by p.ToString() into g
                                        select new
                                        {
                                            g.Key,
                                            count = g.Count()
                                        };
                        var sum2 = q2.ToList();

                        for (int j = 0; j < sum2.Count(); j++)
                        {
                            xValues2[j] = sum2[j].Key;
                            yValues2[j] = sum2[j].count;
                        }
                    }
                }
                var char2 = StatisticsManager.statistics(xValues2, yValues2);
                Label label2 = new Label();
                label2.Text = "單選方塊";
                Panel2.Controls.Add(label2);
                Panel2.Controls.Add(char2);
            }
        }
    }
}