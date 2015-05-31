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
            string query = "SELECT c.Chapter_Title, c.Chapter_Intro, p.Type_ID, p.Problem_ID FROM problem" 
                            +" AS p INNER JOIN chapter AS c WHERE c.Chapter_ID = ?chapter AND p.Chapter_ID = ?chapter;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", Request.QueryString["chapter"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                    {
                    for (int i = 0; i < data.Length; i++)
                        {
                        SetTitle(data[i]["Chapter_Title"].ToString());
                        SetDescription(data[i]["Chapter_Intro"].ToString());
                        SetButton(data[i]["Problem_ID"].ToString(), data[i]["Type_ID"].ToString());
                    }
                        }

                else
                {
                    //Response.Redirect("ERROR.aspx", false);
                    //Context.ApplicationInstance.CompleteRequest();
                    }

                }

            else
            {
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
            Response.Redirect("Graph.aspx?problem=" + "1", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Multi.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void NextChapter_Click(object sender, EventArgs e)
        {
            string query = "SELECT Chapter_ID FROM `chapter`"
                    + " WHERE Chapter_ID > ?chapter" //+ Request.QueryString["problem"]
                    + " AND Book_ID = ?book" //+ Request.QueryString["chapter"]
                    + " ORDER BY Chapter_ID DESC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter",Request.QueryString["chapter"]));
            param.Add(new SQLParameters("?book", Request.QueryString["book"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if(handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                {
                    Response.Redirect("Problems.aspx?book=" + Request.QueryString["book"] +"&chapter=" + data[0]["Chapter_ID"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                else
                {
                    Response.Redirect("Chapters.aspx?book=" + Request.QueryString["book"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void PrevChapter_Click(object sender, EventArgs e)
        {
            string query = "SELECT Chapter_ID FROM `chapter`"
                    + " WHERE Chapter_ID < ?chapter" //+ Request.QueryString["problem"]
                    + " AND Book_ID = ?book" //+ Request.QueryString["chapter"]
                    + " ORDER BY Chapter_ID ASC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", Request.QueryString["chapter"]));
            param.Add(new SQLParameters("?book", Request.QueryString["book"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                {
                    Response.Redirect("Problems.aspx?book=" + Request.QueryString["book"] + "&chapter=" + data[0]["Chapter_ID"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                else
                {
                    Response.Redirect("Chapters.aspx?book=" + Request.QueryString["book"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
        }
        }
        //End
    }
}