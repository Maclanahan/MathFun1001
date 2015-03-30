/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Graph.aspx.cs
*
* Brief Description: Graph webpage
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000 
{
    public partial class Graph : System.Web.UI.Page
    {
        Graphs newGraphX = new Graphs();
        Graphs newGraphY = new Graphs();

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e) 
        {
            
            int[] xAxis = newGraphX.GetX();
            int[] yAxis = newGraphY.GetY();            
            DrawGraph(xAxis, yAxis);
        }

        //Description
        protected void DrawGraph(int[] newGraphX, int[] newGraphY) 
        {
            LineGraph.Legends.Add("");
            LineGraph.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            LineGraph.Series[0].Points.DataBindXY(newGraphX, "X", newGraphY, "Y");;
        }

        //Description
        protected void GoToNextProblem_Click(object sender, EventArgs e)
        {
            String problemNum = Request.QueryString["problem"];
            int num = Convert.ToInt32(problemNum) + 1;
            Console.Out.WriteLine(num);
            Response.Redirect("MathProgram.aspx?problem=" + num.ToString());
        }
    }
}