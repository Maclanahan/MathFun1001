using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000 {
    public partial class Graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            drawGraph();
        }

        protected void drawGraph() 
        {
            int[] X = { -5, -3, 0, 3, 5 };
            int[] Y = { 5, 3, 0, 3, 5 };

            LineGraph.Legends.Add("Where does this show?");
            LineGraph.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            LineGraph.Series[0].Points.DataBindXY(X, "X", Y, "Y");
        }
    }
}