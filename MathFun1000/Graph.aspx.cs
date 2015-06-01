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
//using MySql.Data.Common;
using System.Data;

namespace MathFun1000 
{
    public partial class Graph : System.Web.UI.Page
    {
        Graphs newGraph = new Graphs();

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e) 
        {
            querryDatabase();
            //SetUpButtons();
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

        private void querryDatabase() 
        {
            MySqlConnection conn;
            MySqlCommand cmd;
            String queryStr = "";
            

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySqlConnection(connString);
            
            if (Request.QueryString.HasKeys())
            {
                queryStr = "SELECT Option1, Option2, Option3, Option4, Option5, Answer"
                           + " FROM graphproblem"
                           + " WHERE Book_ID =" + Request.QueryString["book"]
                           + " AND Chapter_ID =" + Request.QueryString["chapter"]
                           + " AND Problem_ID =" + Request.QueryString["problem"] + ";";
            }
            else
                Response.Redirect("Books.aspx");
            try {
                using (cmd = new MySqlCommand(queryStr, conn)) 
                {
                    conn.Open();
                    cmd.Prepare();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        reader.Read();
                        String[] options = new String[5];
                        String answer;

                        options[0] = reader.GetString(0).ToString();
                        options[1] = reader.GetString(1).ToString();
                        options[2] = reader.GetString(2).ToString();
                        options[3] = reader.GetString(3).ToString();
                        options[4] = reader.GetString(4).ToString();
                        answer = reader.GetString(5).ToString();

                        System.Diagnostics.Debug.WriteLine("Options[0]: " + options[0]);
                        System.Diagnostics.Debug.WriteLine("Answer: " + answer);
                        
                        newGraph = new Graphs(answer);
                        UpdateLabels(options, answer);
                    }
                    conn.Close();
                }

            }
            catch (Exception e) 
            {
                conn.Close();
                //need to log the exception
                Console.WriteLine(e.Message);
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void UpdateLabels(String[] options, String answer) 
        {
            int i = 0, a = 0;
            int anspos = newGraph.getAnsPos();
            
            for (i = 0; i < 6; i++) {
                if (i == anspos) 
                    RadioButtonList1.Items[i].Value = "$$\\color{white}{" + answer + "}$$";
                else
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
                    Response.Redirect("Graph.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + data[0]["Problem_ID"], false);
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

        protected void stepBack_Click(object sender, EventArgs e) 
        {
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
                    Response.Redirect("Graph.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + data[0]["Problem_ID"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                else {
                    Response.Redirect("Problems.aspx?chapter=" + Request.QueryString["chapter"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else {
                //Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void Book_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx", false);
        }

        protected void Chapter_Click(object sender, EventArgs e)
        {
            Response.Redirect("Chapters.aspx?book=" + Request.QueryString["book"], false);
        }

        protected void Problem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Problems.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"], false);
        }
    }
}