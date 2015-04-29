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

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";
            if (Request.QueryString.HasKeys())
                queryStr = "SELECT c.Chapter_Title, c.Chapter_Intro, p.Problem_ID FROM problem AS p INNER JOIN chapter AS c WHERE c.Chapter_ID = " + Request.QueryString["chapter"] + " AND p.Chapter_ID = " + Request.QueryString["chapter"] + ";";
            else
                Response.Redirect("Books.aspx");

            using (cmd = new MySqlCommand(queryStr, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SetTitle(reader.GetString(0));
                        SetDescription(reader.GetString(1));
                        SetButton(reader.GetString(2));
                    }
                }

                conn.Close();
            }
        }

        private void SetButton(string p)
        {
            var button = new Button { ID = p, Text = "Problem " + ProblemNum, Width = 210 };
            button.Command += new CommandEventHandler(DynamicCommand);
            button.CommandArgument = p;
            ButtonHolder.Controls.Add(button);
            ButtonHolder.Controls.Add(new LiteralControl("<br />"));


            ProblemNum++;
        }

        private void DynamicCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + e.CommandArgument);
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
            Response.Redirect("MathProgram.aspx?problem=" + "1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "2");
        }

        protected void Button3_Click(object sender, EventArgs e) 
        {
            Response.Redirect("Graph.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Multi.aspx");
        }
        //End
    }
}