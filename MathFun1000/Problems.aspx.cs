/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Problems.aspx.cs
*
* Brief Description: Problems webpage, after the Chapter
* is selected you select a Problem from that Chapter.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;

namespace MathFun1000
{
    public partial class Problems : System.Web.UI.Page
    {
        private int ProblemNum = 1;

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            querryDatabase();
        }

        private void querryDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;

            //System.Diagnostics.Debug.WriteLine(Request.QueryString["WebAppConnString"]);

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";
            if (Request.QueryString.HasKeys())
                queryStr = "SELECT c.Chapter_Title, c.Chapter_Intro, p.Type_ID, p.Problem_ID FROM problem" 
                            +" AS p INNER JOIN chapter AS c WHERE c.Chapter_ID = ?chapter AND p.Chapter_ID = ?chapter;";
            else
                Response.Redirect("Books.aspx");


            try
            {
                using (cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();

                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("?chapter", Request.QueryString["chapter"]);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SetTitle(reader.GetString(0));
                            SetDescription(reader.GetString(1));
                            SetButton(reader.GetString(3), reader.GetString(2)); // SetButton Takes in 2 Parm's 1 Is the Problem ID other is Problem Type.
                        }
                    }

                    conn.Close();
                }
            } catch (Exception e)
            {
                //need to log the exception
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        //Parms - Problem Type is so that Graph and Multi Can be created.
        //in the DB 1 is set to default, so not to change daniels over all build idea, 2 is Graph, and 3 is Multi.
        private void SetButton(string p , string problem_type)
        {
            var button = new Button { ID = p, Text = "Problem " + ProblemNum, Width = 210 };
            if(problem_type.Equals("1"))//Default Problem Dynamic Command Creation
            {
                button.Command += new CommandEventHandler(DynamicCommand);
            }
            else if (problem_type.Equals("2"))//Graph Dynamiac COmmand Creation
            {
                button.Command += new CommandEventHandler(DynamicCommandGraph);
            }
            else if (problem_type.Equals("3"))//Multi Dynamic Command Creation
            {
                button.Command += new CommandEventHandler(DynamicCommandMulti);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("ERROR: Problems.aspx.cs -> Method: SetButton");
            }
            
            button.CommandArgument = p;
            ButtonHolder.Controls.Add(button);
            ButtonHolder.Controls.Add(new LiteralControl("<br />"));


            ProblemNum++;
        }

        private void DynamicCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("MathProgram.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + e.CommandArgument, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void DynamicCommandMulti(object sender, CommandEventArgs e)
        {
            Response.Redirect("Multi.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + e.CommandArgument, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void DynamicCommandGraph(object sender, CommandEventArgs e)
        {
            Response.Redirect("Graph.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + e.CommandArgument, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void SetDescription(string p)
        {
            Intro.InnerText = p;
        }

        private void SetTitle(string p)
        {
            ChapterTitle.InnerText = p;
        }

        //Start - These buttons are made for test purpuses, they will be dynamically created in final product
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "1", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "2", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void Button3_Click(object sender, EventArgs e) 
        {
            Response.Redirect("Graph.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Multi.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        //End
    }
}