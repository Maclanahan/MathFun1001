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
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;

namespace MathFun1000 
{
    public partial class Graph : System.Web.UI.Page
    {
        Graphs newGraph;

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e) 
        {
            //querryDatabase();
            SetUpButtons();
            newGraph = new Graphs("y=x+1");
            int[] xAxis = newGraph.GetX();
            double[] yAxis = newGraph.GetY();
            DrawGraph(xAxis, yAxis);            
            RadioButtonList1.Attributes.Add("onclick", "CheckAns('" + newGraph.getAnsPos() + "');");
        }

        
        protected void DrawGraph(int[] newGraphX, double[] newGraphY) 
        {
            LineGraph.Legends.Add("");
            LineGraph.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            LineGraph.Series[0].Points.DataBindXY(newGraphX, "X", newGraphY, "Y");
        }

        private void querryDatabase() {
            MySqlConnection conn;
            MySqlCommand cmd;
            String queryStr = "";
            

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySqlConnection(connString);
            
            System.Diagnostics.Debug.WriteLine("ProblemNumber: " + Request.QueryString["problem"]);
            System.Diagnostics.Debug.WriteLine("ChapterNumber: " + Request.QueryString["chapter"]);
            System.Diagnostics.Debug.WriteLine("BookId: " + Request.QueryString["book"]);
            
            if (Request.QueryString.HasKeys())
            {
                queryStr = "SELECT Option1, Option2, Option3, Option4, Answer"
                           + "FROM 'graphproblem'"
                           + "WHERE BookId =" + Request.QueryString["book"]
                           + "AND ChapterNumber =" + Request.QueryString["chapter"]
                           + "AND ProblemNumber =" + Request.QueryString["problem"];
            }
            else
                Response.Redirect("Books.aspx");
            try {
                using (cmd = new MySqlCommand(queryStr, conn)) {
                    conn.Open();
                    cmd.Prepare();

                    using (MySqlDataReader reader = cmd.ExecuteReader()) {

                        reader.Read();
                        string[] options = new string[4];
                        string Answer;

                        for (int i = 1; i < 5; i++) 
                            options[i] = reader.GetString(i);                      
                        
                        Answer = reader.GetString(5);                       

                        newGraph = new Graphs(Answer);
                        UpdateLabels(options, Answer);
                    }
                    conn.Close();
                }

            }
            catch (Exception e) {
                conn.Close();
                //need to log the exception
                Console.WriteLine(e.Message);
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void UpdateLabels(String[] options, String answer) {
            int i = 0;
            int anspos = newGraph.getAnsPos();

            RadioButtonList1.Items[anspos].Value = "$$\\color{white}{" + answer + "}$$";
            for (i = 0; i < 5; i++) {
                if (i == anspos)
                    i++;
                RadioButtonList1.Items[i].Value = "$$\\color{white}{" + options[i] + "}$$";

            }
        }

        //Set up basic buttons for the problem
        private void SetUpButtons()
        {
            var buttonForward = new Button { CssClass = "StepForwardButton", Text = "Next Problem >>" };
            buttonForward.Click += stepForward_Click;
            buttons.Controls.Add(buttonForward);

            var buttonBack = new Button { CssClass = "button", Text = "<< Prev Problem" };
            buttonBack.Click += stepBack_Click;
            buttons.Controls.Add(buttonBack);

        }

        //Event handler for next button
        protected void stepForward_Click(object sender, EventArgs e)
        {
            string query = "SELECT Problem_ID FROM `problem`"
                    + " WHERE Problem_ID > ?problem" //+ Request.QueryString["problem"]
                    + " AND Chapter_ID = ?chapter" //+ Request.QueryString["chapter"]
                    + " ORDER BY Problem_ID ASC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", Request.QueryString["chapter"]));
            param.Add(new SQLParameters("?problem", Request.QueryString["problem"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
                        {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                        {
                    Response.Redirect("MathProgram.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + data[0]["Problem_ID"], false);
                            Context.ApplicationInstance.CompleteRequest();
                        }

                        else
                        {
                            Response.Redirect("Problems.aspx?chapter=" + Request.QueryString["chapter"], false);
                            Context.ApplicationInstance.CompleteRequest();
                        }

                }

            else
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void stepBack_Click(object sender, EventArgs e) {
            string query = "SELECT Problem_ID FROM `problem`"
                    + " WHERE Problem_ID < ?problem" //+ Request.QueryString["problem"]
                    + " AND Chapter_ID = ?chapter" //+ Request.QueryString["chapter"]
                    + " ORDER BY Problem_ID DESC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", Request.QueryString["chapter"]));
            param.Add(new SQLParameters("?problem", Request.QueryString["problem"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment()) {
                DataRow[] data = handler.Data;

                if (data.Length > 0) {
                    Response.Redirect("MathProgram.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + data[0]["Problem_ID"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                else {
                    Response.Redirect("Problems.aspx?chapter=" + Request.QueryString["chapter"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}