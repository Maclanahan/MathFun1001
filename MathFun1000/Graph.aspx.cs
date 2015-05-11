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
        //Graphs newGraph = new Graphs();
        Graphs newGraph = new Graphs("y=x+1");
        String[] options;

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e) 
        {
            
            int[] xAxis = newGraph.GetX();
            double[] yAxis = newGraph.GetY();
            //GenerateCode();
            DrawGraph(xAxis, yAxis);
            UpdateLabels();
            RadioButtonList1.Attributes.Add("onclick", "CheckAns('RadioButtonList1');");
        }

        
        protected void DrawGraph(int[] newGraphX, double[] newGraphY) 
        {
            LineGraph.Legends.Add("");
            LineGraph.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            LineGraph.Series[0].Points.DataBindXY(newGraphX, "X", newGraphY, "Y");
        }

        protected void UpdateLabels() 
        {
            bool first = true;
            int i = 0;
            options = newGraph.getEquationOptions();

            for (i = 0; i < 5; i++) 
            {
                RadioButtonList1.Items[i].Value = options[i];
            }
            
        }

        protected void UpdateUser() 
        {
            RadioButtonList1.Items[1].Text = "$$Correct!!$$";
        }
        
        private void GenerateCode()
        {
            options = newGraph.getEquationOptions();

            string script = "<script>";
            script += "var ans = " + newGraph.getAns() + ";\n";
                        
            //script += "<asp:RadioButtonList ID=\"RadioButtonList1\" runat=\"server\" RepeatColumns=\"1\" RepeatLayout=\"Table\">\n";
                
              //  script += "<asp:ListItem Value=\"0\" Text=\"" + options[0] +"\"></asp:ListItem>\n";                
              //  script += "<asp:ListItem Value=\"1\" Text=\"" + options[1] +"\"></asp:ListItem>\n";
              //  script += "<asp:ListItem Value=\"2\" Text=\"" + options[2] + "\"></asp:ListItem>\n";
              //  script += "<asp:ListItem Value=\"3\" Text=\"" + options[3] + "\"></asp:ListItem>\n";
              //  script += "<asp:ListItem Value=\"4\" Text=\"" + options[4] +"\"></asp:ListItem>\n";

           //script += "</asp:RadioButtonList>\n";

            script += "<input type=\"button\" value=\"Check Answer\" onclick=\"UpdateUser()\" />";

            script += "</script>\n";            
            
        rbList.InnerHtml = script;

        }

        //Description
        protected void GoToNextProblem_Click(object sender, EventArgs e)
        {
            String problemNum = Request.QueryString["problem"];
            int num = Convert.ToInt32(problemNum) + 1;
            Console.Out.WriteLine(num);
            Response.Redirect("MathProgram.aspx?problem=" + num.ToString());
        }

        protected void CheckAnswer(object sender, EventArgs e) 
        {
            int ChoosenButton = -1;
            ChoosenButton = RadioButtonList1.SelectedIndex;

            if (ChoosenButton == newGraph.ans) {
                options[1] = "$$\\color{green}{CORRECT!!}$$";
            }
            else {
                options[1] = "$$\\color{red}{INCORRECT!\\: Please\\: try\\: again!}$$";
            }
        }
    }
}