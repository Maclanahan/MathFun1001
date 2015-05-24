/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: MathProgram.aspx.cs
*
* Brief Description: MathProgram is the main webpage for our site
* it controls the overall flow of the program as well as interactions
* with other classes.
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
    public partial class MathProgramJavascript : System.Web.UI.Page
    {
        public Problem problem = new Problem();
        public IProblemType steps = new Tutorial();

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            querryDatabase();

            SetUpButtons();

            SetUpMenu();

            convertToJavaScript();

            executeJavaScript();
        }

        private void querryDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";
            Console.WriteLine(Request.QueryString["problem"]);
            if (Request.QueryString.HasKeys())
                queryStr = "SELECT step.Info, step.Example, rule.rule_name, rule.rule_Link FROM `step`"
                    + " INNER JOIN problem ON step.Problem_ID = problem.Problem_ID"
                    + " LEFT JOIN rule ON step.rules = rule.rule_ID"
                    + " WHERE step.Problem_ID = ?problem" //+ Request.QueryString["problem"] 
                    + " AND problem.Chapter_ID = ?chapter" //+ Request.QueryString["chapter"]
                    + " ORDER BY step.Step_ID ASC;";
                
            else
                Response.Redirect("Books.aspx");
            try
            {
                using (cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("?problem", Request.QueryString["problem"]);
                    cmd.Parameters.AddWithValue("?chapter", Request.QueryString["chapter"]);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var info = new List<string>();
                        var example = new List<string>();
                        var rule = new List<string>();
                        var link = new List<string>();

                        while (reader.Read())
                        {
                            info.Add(reader.GetString(0));
                            example.Add(reader.GetString(1));
                            rule.Add(reader.GetString(2));
                            link.Add(reader.GetString(3));
                        }

                        if (info.Count > 0)
                            steps = new Tutorial(info.ToArray(), example.ToArray(), rule.ToArray(), link.ToArray(), 0, info.Count);
                        else
                        {
                            conn.Close();
                            Response.Redirect("Problems.aspx?chapter=" + Request.QueryString["chapter"], false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }

                    conn.Close();
                }
            } catch (Exception e)
            {
                conn.Close();
                //need to log the exception
                Console.WriteLine(e.Message);
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private void executeJavaScript()
        {
            //string script = "<script>";

            //script +=
        }

        private void convertToJavaScript()
        {
            string script = "<script>";
            script += "var step = [];\n";
            script += "var example = [];\n";
            script += "var rule = [];\n";
            script += "var link = [];\n";

            for (int i = 0; i < steps.GetNumberOfSteps(); i++)
            {
                script += "step[" + i + "] = \"" + steps.GetStepAt(i) + "\";\n";
                script += "example[" + i + "] = \"" + steps.GetExampleAt(i) + "\";\n";
                script += "rule[" + i + "] = \"" + steps.GetRuleAt(i) + "\";\n";
                script += "link[" + i + "] = \"" + steps.GetLinkAt(i) + "\";\n";
            }

            script += "</script>\n";
            arrayData.InnerHtml = script;
        }

        private void SetUpMenu()
        {
            var books = new Button { CssClass = "menuButton", Text = "Books" };
            books.Click += Book_Click;
            menuContainer.Controls.Add(books);

            var chapters = new Button { CssClass = "menuButton", Text = "Chapters" };
            chapters.Click += Chapter_Click;
            menuContainer.Controls.Add(chapters);


            var problems = new Button { CssClass = "menuButton", Text = "Problems" };
            problems.Click += Problem_Click;
            menuContainer.Controls.Add(problems);
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

        //Set up basic buttons for the problem
        private void SetUpButtons()
        {
            var buttonForward = new Button { CssClass = "StepForwardButton", Text = "Next Problem >>" };
            buttonForward.Click += StepForwardButton_Click;
            buttons.Controls.Add(buttonForward);

            var buttonBack = new Button { CssClass = "button", Text = "<< Prev Problem" };
            buttonBack.Click += StepBackwardButton_Click;
            buttons.Controls.Add(buttonBack);

        }

        //Event handler for next button
        protected void StepForwardButton_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";

            if (Request.QueryString.HasKeys())
                queryStr = "SELECT Problem_ID FROM `problem`"
                    + " WHERE Problem_ID > ?problem" //+ Request.QueryString["problem"]
                    + " AND Chapter_ID = ?chapter" //+ Request.QueryString["chapter"]
                    + " ORDER BY Problem_ID ASC;";

            else
                Response.Redirect("Books.aspx");

            string problem = "";

            try{
                using (cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("?problem", Request.QueryString["problem"]);
                    cmd.Parameters.AddWithValue("?chapter", Request.QueryString["chapter"]);

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            problem = reader.GetString(0);
                        }

                        if (problem != "")
                        {
                            conn.Close();
                            Response.Redirect("MathProgram.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + problem, false);
                            Context.ApplicationInstance.CompleteRequest();
                        }

                        else
                        {
                            conn.Close();
                            Response.Redirect("Problems.aspx?chapter=" + Request.QueryString["chapter"], false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }

                }
            } catch(Exception except)
            {
                //need to log the exception
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void StepBackwardButton_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";

            if (Request.QueryString.HasKeys())
                queryStr = "SELECT Problem_ID FROM `problem`"
                    + " WHERE Problem_ID < ?problem"// + Request.QueryString["problem"]
                    + " AND Chapter_ID = ?chapter"// + Request.QueryString["chapter"]
                    + " ORDER BY Problem_ID ASC;";

            else
                Response.Redirect("Books.aspx");

            string problem = "";

            try
            {
                using (cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("?problem", Request.QueryString["problem"]);
                    cmd.Parameters.AddWithValue("?chapter", Request.QueryString["chapter"]);

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            problem = reader.GetString(0);
                        }

                        if (problem != "")
                        {
                            conn.Close();
                            Response.Redirect("MathProgram.aspx?book=" + Request.QueryString["book"] + "&chapter=" + Request.QueryString["chapter"] + "&problem=" + problem, false);
                            Context.ApplicationInstance.CompleteRequest();
                        }

                        else
                        {
                            conn.Close();
                            Response.Redirect("Problems.aspx?chapter=" + Request.QueryString["chapter"], false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }

                }
            }
            catch (Exception except)
            {
                //need to log the exception
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}