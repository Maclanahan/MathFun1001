using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000 {
    public partial class Graph : System.Web.UI.Page
    {
        Graphs newGraphX = new Graphs();
        Graphs newGraphY = new Graphs();
        protected void Page_Load(object sender, EventArgs e) 
        {
            
            int[] xAxis = newGraphX.getX();
            int[] yAxis = newGraphY.getY();            
            drawGraph(xAxis, yAxis);
        }

        protected void drawGraph(int[] newGraphX, int[] newGraphY) 
        {
            int[] X = { -2, -1, 0, 1, 2 };
            int[] Y = { 4, 1, 0, 1, 4 };

            LineGraph.Legends.Add("Where does this show?");
            LineGraph.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            LineGraph.Series[0].Points.DataBindXY(newGraphX, "X", newGraphY, "Y");
            //LineGraph.ChartAreas[0].RecalculateAxesScale();
        }
    }
}