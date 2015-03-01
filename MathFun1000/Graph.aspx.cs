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

        }
        protected void drawGraph() 
        {
            int[] x = { 1, 2, 3, 4, 5 };
            int[] y = { 1, 2, 3, 4, 5 };
            LineGraph = new System.Web.UI.DataVisualization.Charting.Chart();
            
        }

    }
}