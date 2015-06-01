using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class Multi : System.Web.UI.Page
    {
        public Multis multi_int = new Multis();

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            querryDatabase();

            GenerateCode();
        }

        private void querryDatabase()
        {
            MySqlConnection conn;
            MySqlCommand cmd;
            String queryStr = "";

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySqlConnection(connString);

            //Text to Output box for debugging.
            System.Diagnostics.Debug.WriteLine("ProblemID: " + Request.QueryString["problem"]);
            System.Diagnostics.Debug.WriteLine("ChapterID: " + Request.QueryString["chapter"]);
            System.Diagnostics.Debug.WriteLine("BookID: " + Request.QueryString["book"]);
            //End

            if (Request.QueryString.HasKeys())
            {
                queryStr = "SELECT question , answer1 , answer2 , answer3 , answer4, correct_answer"
                    + " FROM mcproblems"
                    + " WHERE Problem_ID = " + Request.QueryString["problem"]
                    + " AND Chapter_ID = " + Request.QueryString["chapter"]
                    + " AND Book_ID = " + Request.QueryString["book"];
            }
            else
            {
                Response.Redirect("Books.aspx");
            }

            try
            {
                using(cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();
                    cmd.Prepare();
                   // cmd.Parameters.AddWithValue("?problem", Request.QueryString["problem"]);
                    //cmd.Parameters.AddWithValue("?chapter", Request.QueryString["chapter"]);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();

                        string Question;
                        string Answer1;
                        string Answer2;
                        string Answer3;
                        string Answer4;
                        string Correct;

                        Question = reader.GetString(0);
                        Answer1 = reader.GetString(1);
                        Answer2 = reader.GetString(2);
                        Answer3 = reader.GetString(3);
                        Answer4 = reader.GetString(4);
                        Correct = reader.GetString(5);

                        multi_int = new Multis(Question, Answer1, Answer2, Answer3, Answer4, Correct);
                    }
                    conn.Close();
                }
            }
            catch(Exception e)
            {
                conn.Close();
                System.Diagnostics.Debug.WriteLine("P"+e);
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }



        }

        public void CorrectAnswer()
        {
            string TheCorrectAnswer = multi_int.getCorrect();

            string script = "<script>";
            script += "var CorrectAnswer = "+TheCorrectAnswer+";\n";
            script += "</script>\n";
            arrayData.InnerHtml = script;
        }

        private void GenerateCode()
        {
            string TheCorrectAnswer = multi_int.getCorrect();
            string script = "<script>";
            script += "var example = [];\n";
            script += "var CorrectAnswer = \"" + TheCorrectAnswer + "\";\n";

            for (int i = 0; i < multi_int.GetNumberOfSteps(); i++)
            {
                if(i==0)
                {
                    script += "example[" + i + "] = \"" + multi_int.Question + "\";\n";
                }
                else if (i == 1)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer1 + "\";\n";
                }
                else if (i == 2)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer2 + "\";\n";
                }
                else if (i == 3)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer3 + "\";\n";
                }
                else if (i == 4)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer4 + "\";\n";
                }
                else if (i == 5)
                {
                    
                }
                

            }

            script += "</script>\n";
            arrayData.InnerHtml = script;

            


            //string parse = multi_int.GenerateCode();
            //ParseForInput(parse);
        }

        private void ParseForInput(string parase)
        {
            innerMain.InnerHtml = parase;
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