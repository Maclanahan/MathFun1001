﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;

namespace MathFun1000
{
    /// <summary>
    /// Summary description for ContentManager
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    [ScriptService]
    public class ContentManager : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] HelloWorld()
        {
            string[] words = new string[5];
            words[0] = "Hello World";

            words[1] = "How are you doing?";

            words[4] = "Goodbye World";

            return words;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetBooks()
        {
            string query = "SELECT Book_ID, Book_Name FROM book"
                            + " ORDER BY Book_ID ASC";

            List<SQLParameters> param = new List<SQLParameters>();
            //param.Add(new SQLParameters("?chapter", Request.QueryString["chapter"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[2]{ "Book_ID", "Book_Name" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetChapters(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT Chapter_ID, Chapter_Title FROM chapter"
                            + " WHERE Book_ID = ?book";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", id));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[2] { "Chapter_ID", "Chapter_Title" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetChapter(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT Chapter_ID, Chapter_Title, Chapter_Intro FROM chapter"
                            + " WHERE Chapter_ID = ?id";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?id", id));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[3] { "Chapter_ID", "Chapter_Title", "Chapter_Intro" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetProblems(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT Problem_ID, Type_ID FROM problem"
                            + " WHERE Chapter_ID = ?chapter";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", id));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[2] { "Problem_ID", "Type_ID" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetSteps(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT Step_ID, Info, Example, Rules FROM step"
                            + " WHERE Problem_ID = ?problem ORDER BY Step_ID ASC";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", id));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[4] { "Step_ID", "Info", "Example", "Rules" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetMultipleChoice(string id)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT mcpID, answer1, answer2, answer3, answer4, correct_answer, question FROM mcproblems"
                            + " WHERE Problem_ID = ?problem";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", id));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[7] { "mcpID", "answer1", "answer2", "answer3", "answer4", "correct_answer", "question" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetGraph(string id)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT gID, Option1, Option2, Option3, Option4, Option5, Answer FROM graphproblem"
            //string query = "SELECT * FROM graphproblem"
                            + " WHERE Problem_ID = ?problem";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", id));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;
                string[] columns = new string[7] { "gID", "Option1", "Option2", "Option3", "Option4", "Option5", "Answer" };
                return createStringArray(data, columns);

            }

            else
            {
                //Response.Redirect("ERROR.aspx", false);
                //Context.ApplicationInstance.CompleteRequest();
            }

            List<string[]> fail = new List<string[]>();//.Add(new string[1] { id });
            fail.Add(new string[1] { id });
            return fail;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddBook(string title)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "INSERT INTO book SET Book_Name=?book";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", title));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                
                return "Success";

            }

            return "Could Not Add " + title;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateBook(string title, string id)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "UPDATE book SET Book_Name=?book WHERE Book_ID=?id";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", title));
            param.Add(new SQLParameters("?id", id));

            SQLHandler handler = new SQLHandler(query, param, 2);

            if (handler.executeStatment())
            {

                return "Success";

            }

            return "Could Not Update " + title.ToString();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddChapter(string title, string desc, int book)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "INSERT INTO chapter SET Chapter_Title=?chapter, Chapter_Intro=?intro, Book_ID=?book";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", title));
            param.Add(new SQLParameters("?intro", desc));
            param.Add(new SQLParameters("?book", book));

            SQLHandler handler = new SQLHandler(query, param, 3);

            if (handler.executeStatment())
            {

                return "Success";

            }

            return "Could Not Add " + title;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateChapter(string title, string desc, string id)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "UPDATE chapter SET Chapter_Title=?title, Chapter_Intro=?desc WHERE Chapter_ID=?id";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?title", title));
            param.Add(new SQLParameters("?desc", desc));
            param.Add(new SQLParameters("?id", id));

            SQLHandler handler = new SQLHandler(query, param, 3);

            if (handler.executeStatment())
            {

                return "Success";

            }

            return "Could Not Update " + title.ToString();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateProblem(string step, string example, string rule, string id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            string query = "UPDATE step SET Info=?step, Example=?example, Rules=?rule WHERE Step_ID=?id";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?step", step));
            param.Add(new SQLParameters("?example", example));
            param.Add(new SQLParameters("?rule", rule));
            param.Add(new SQLParameters("?id", id));

            SQLHandler handler = new SQLHandler(query, param, 4);

            if (handler.executeStatment())
            {

                return "Success";

            }

            return "Could Not Update " + id.ToString();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateMultipleChoice(string question, string option1, string option2, string option3, string option4, string answer, string id)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            //string query = "UPDATE mcproblems SET answer1=?a1, answer2=?a2, answer3=?a3, answer4=?a4, correct_answer=?ca question=?q WHERE Problem_ID=?id";
            string query = "UPDATE mcproblems SET answer1=?a1, answer2=?a2, answer3=?a3, answer4=?a4, correct_answer=?ca, question=?q WHERE Problem_ID=?id";
            //string query = "SELECT * FROM mcproblems";
            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?a1", option1));
            param.Add(new SQLParameters("?a2", option2));
            param.Add(new SQLParameters("?a3", option3));
            param.Add(new SQLParameters("?a4", option4));
            param.Add(new SQLParameters("?ca", answer));
            param.Add(new SQLParameters("?q", question));
            param.Add(new SQLParameters("?id", id));

            SQLHandler handler = new SQLHandler(query, param, 7);

            if (handler.executeStatment())
            {

                return "Success";

            }

            return "Could Not Update " + id.ToString();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateGraph(string option1, string option2, string option3, string option4, string option5, string answer, string id)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "UPDATE graphproblem SET Option1=?a1, Option2=?a2, Option3=?a3, Option4=?a4, Option5=?a5, Answer=?ca WHERE Problem_ID=?id";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?a1", option1));
            param.Add(new SQLParameters("?a2", option2));
            param.Add(new SQLParameters("?a3", option3));
            param.Add(new SQLParameters("?a4", option4));
            param.Add(new SQLParameters("?a5", option5));
            param.Add(new SQLParameters("?ca", answer));
            param.Add(new SQLParameters("?id", id));

            SQLHandler handler = new SQLHandler(query, param, 7);

            if (handler.executeStatment())
            {

                return "Success";

            }

            return "Could Not Update " + id.ToString();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddMultipleChoice(string question, string option1, string option2, string option3, string option4,
            string answer, string id, string book, string type)
        {
            string query = "INSERT INTO problem SET Chapter_ID=?chapter, Type_ID=?type";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", id));
            param.Add(new SQLParameters("?type", type));

            SQLHandler handler = new SQLHandler(query, param, 2);

            if (handler.executeStatment())
            {

                //handler.IDofLastInsert;
                string queryInner = "INSERT INTO mcproblems SET answer1=?a1, answer2=?a2, answer3=?a3, answer4=?a4, correct_answer=?ca,"
                                        + " question=?q, Problem_ID=?id, Chapter_ID=?chapter, Book_ID=?book";
                //string query = "SELECT * FROM mcproblems";
                List<SQLParameters> paramInner = new List<SQLParameters>();
                paramInner.Add(new SQLParameters("?a1", option1));
                paramInner.Add(new SQLParameters("?a2", option2));
                paramInner.Add(new SQLParameters("?a3", option3));
                paramInner.Add(new SQLParameters("?a4", option4));
                paramInner.Add(new SQLParameters("?ca", answer));
                paramInner.Add(new SQLParameters("?q", question));
                paramInner.Add(new SQLParameters("?id", handler.IDofLastInsert));
                paramInner.Add(new SQLParameters("?chapter", id));
                paramInner.Add(new SQLParameters("?book", book));

                SQLHandler handlerInner = new SQLHandler(queryInner, paramInner, 7);

                if (handlerInner.executeStatment())
                {

                    return "Success";

                }

                return "Could Not Update " + id.ToString();


            }

            return "Could Not Add Problem ";

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddGraph(string option1, string option2, string option3, string option4, string option5, string answer,
            string id, string book, string type)
        {
            string query = "INSERT INTO problem SET Chapter_ID=?chapter, Type_ID=?type";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", id));
            param.Add(new SQLParameters("?type", type));

            SQLHandler handler = new SQLHandler(query, param, 2);

            if (handler.executeStatment())
            {

                //handler.IDofLastInsert;
                string queryInner = "INSERT INTO graphproblem SET Option1=?a1, Option2=?a2, Option3=?a3, Option4=?a4, Option5=?a5,"
                                    + " Answer=?ca, Problem_ID=?id, Book_ID=?book, Chapter_ID=?chapter";
                //string query = "SELECT * FROM mcproblems";
                List<SQLParameters> paramInner = new List<SQLParameters>();
                paramInner.Add(new SQLParameters("?a1", option1));
                paramInner.Add(new SQLParameters("?a2", option2));
                paramInner.Add(new SQLParameters("?a3", option3));
                paramInner.Add(new SQLParameters("?a4", option4));
                paramInner.Add(new SQLParameters("?a5", option5));
                paramInner.Add(new SQLParameters("?ca", answer));
                paramInner.Add(new SQLParameters("?id", handler.IDofLastInsert));
                paramInner.Add(new SQLParameters("?chapter", id));
                paramInner.Add(new SQLParameters("?book", book));

                SQLHandler handlerInner = new SQLHandler(queryInner, paramInner, 7);

                if (handlerInner.executeStatment())
                {

                    return "Success";

                }

                return "Could Not Update " + id.ToString();


            }

            return "Could Not Add Problem ";

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddProblem(string chapter, string type)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "INSERT INTO problem SET Chapter_ID=?chapter, Type_ID=?type";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?chapter", chapter));
            param.Add(new SQLParameters("?type", type));

            SQLHandler handler = new SQLHandler(query, param, 2);

            if (handler.executeStatment())
            {

                return handler.IDofLastInsert;

            }

            return "Could Not Add Problem ";
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddStep(string step, string example, string rule, string problem)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "INSERT INTO step SET Problem_ID=?problem, Info=?step, Example=?example, Rules=?rule";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", problem));
            param.Add(new SQLParameters("?step", step));
            param.Add(new SQLParameters("?example", example));
            param.Add(new SQLParameters("?rule", rule));

            SQLHandler handler = new SQLHandler(query, param, 4);

            if (handler.executeStatment())
            {

                return handler.IDofLastInsert;

            }

            return "Could Not Add Problem ";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DeleteProblem(string problem)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "DELETE FROM problem WHERE Problem_ID=?problem";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", problem));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                //return "success";

                string queryInner = "DELETE FROM step WHERE Problem_ID=?problem";

                List<SQLParameters> paramInner = new List<SQLParameters>();
                paramInner.Add(new SQLParameters("?problem", problem));

                SQLHandler handlerInner = new SQLHandler(queryInner, paramInner, 1);
                if (handlerInner.executeStatment())
                {
                    return "success";
                }
            }

            return "Could Not Delete Problem ";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DeleteMultipleChoice(string problem)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "DELETE FROM problem WHERE Problem_ID=?problem";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", problem));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                //return "success";

                string queryInner = "DELETE FROM mcproblems WHERE Problem_ID=?problem";

                List<SQLParameters> paramInner = new List<SQLParameters>();
                paramInner.Add(new SQLParameters("?problem", problem));

                SQLHandler handlerInner = new SQLHandler(queryInner, paramInner, 1);
                if (handlerInner.executeStatment())
                {
                    return "success";
                }
            }

            return "Could Not Delete Problem ";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DeleteGraph(string problem)
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "DELETE FROM problem WHERE Problem_ID=?problem";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?problem", problem));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                //return "success";

                string queryInner = "DELETE FROM graphproblem WHERE Problem_ID=?problem";

                List<SQLParameters> paramInner = new List<SQLParameters>();
                paramInner.Add(new SQLParameters("?problem", problem));

                SQLHandler handlerInner = new SQLHandler(queryInner, paramInner, 1);
                if (handlerInner.executeStatment())
                {
                    return "success";
                }
            }

            return "Could Not Delete Problem ";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string[]> GetRules()
        {
            //System.Diagnostics.Debug.WriteLine(id);

            string query = "SELECT rule_ID, rule_name from rule ORDER BY rule_ID ASC";

            List<SQLParameters> param = new List<SQLParameters>();

            SQLHandler handler = new SQLHandler(query, param, 0);

            if (handler.executeStatment())
            {

                DataRow[] data = handler.Data;
                string[] columns = new string[2] { "rule_ID", "rule_name"};
                return createStringArray(data, columns);

            }

            return new List<string[]>() ;
        }



        private List<string[]> createStringArray(DataRow[] data, string[] columns)
        {
            List<string[]> list = new List<string[]>();

            for (int i = 0; i < data.Length; i++ )
            {
                string[] row = new string[columns.Length];

                for(int j = 0; j < row.Length; j++)
                {
                    row[j] = data[i][columns[j]].ToString();
                }

                list.Add(row);
            }
            
            return list;
        }
    }
}
