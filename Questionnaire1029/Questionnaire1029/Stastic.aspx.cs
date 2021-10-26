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
                    string[] xValues = new string[50];
                    int[] yValues = new int[50];
                    List<string> MsgList = new List<string>();

                    var qc = AuthManager.GetAnswerListByID(id);
                    for (int i = 0; i < qc.Count(); i++)
                    {
                        string[] vs = qc[i].QC_ansrd1.Split(',');
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

                    for (int i = 0; i < sum.Count(); i++)
                    {
                        xValues[i] = sum[i].Key.ToString();
                        yValues[i] = sum[i].count;
                    }

                    //ChartAreas,Series,Legends 基本設定------------------------------------------------

                    Chart Chart1 = new Chart();
                    Chart1.ChartAreas.Add("ChartArea1"); //圖表區域集合
                    Chart1.Legends.Add("Legends1"); //圖例集合說明
                    Chart1.Series.Add("Series1"); //數據序列集合

                    //設定 Chart-------------------------------------------------------------------------

                    Chart1.Width = 770;
                    Chart1.Height = 400;
                    Title title = new Title();
                    //title.Text = "圓餅圖";
                    title.Alignment = ContentAlignment.MiddleCenter;
                    title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
                    Chart1.Titles.Add(title);

                    //設定 ChartArea1--------------------------------------------------------------------
                    //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.ChartAreas[0].AxisX.Interval = 1;

                    //設定 表格-------------------------------------------------------------------------

                    Chart1.Legends["Legends1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內
                    Chart1.Legends["Legends1"].Docking = Docking.Right; //自訂顯示位置
                    Chart1.Legends["Legends1"].BackColor = Color.FromArgb(235, 235, 235);//斜線背景//背景色
                    Chart1.Legends["Legends1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
                    Chart1.Legends["Legends1"].BorderWidth = 1;
                    Chart1.Legends["Legends1"].BorderColor = Color.FromArgb(200, 200, 200);

                    //設定 圓餅圖-----------------------------------------------------------------------

                    Chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;
                    Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
                    Chart1.Series["Series1"].LegendText = "#VALX: [ #PERCENT{P1} ]";      //X軸 + 百分比
                    Chart1.Series["Series1"].Label = "#VALX\n#PERCENT{P1}";               //X軸 + 百分比
                    Chart1.Series["Series1"].LabelForeColor = Color.FromArgb(0, 90, 255); //字體顏色

                    //字體設定

                    Chart1.Series["Series1"].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
                    Chart1.Series["Series1"].Points.FindMaxByValue().LabelForeColor = Color.Red;
                    Chart1.Series["Series1"].Points.FindMaxByValue().Color = Color.Red;
                    Chart1.Series["Series1"].Points.FindMaxByValue()["Exploded"] = "true";
                    Chart1.Series["Series1"].BorderColor = Color.FromArgb(255, 101, 101, 101);
                    Chart1.Series["Series1"]["DoughnutRadius"] = "80";
                    Chart1.Series["Series1"]["PieLabelStyle"] = "Disabled"; //數值顯示在圓餅外


                    //設定圓餅效果，除 Default 外其他效果3D不適用
                    Chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";

                    Random rnd = new Random(); //亂數產生區塊顏色

                    foreach (DataPoint point in Chart1.Series["Series1"].Points)
                    {
                        //pie 顏色
                        point.Color = Color.FromArgb(150, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

                    }
                    Controls.Add(Chart1);
                }
            }
        }
    }
}