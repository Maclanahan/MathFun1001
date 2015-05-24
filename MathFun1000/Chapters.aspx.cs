/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Chapters.aspx.cs
*
* Brief Description: Chapters webpage code.
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
    public partial class Chapters : System.Web.UI.Page
    {

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            querryDatabase();

            setBookTitle();
        }

        private void setBookTitle()
        {
            string query = "SELECT Book_Name FROM book WHERE Book_ID = ?book";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", Request.QueryString["book"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                {
                    BookTitle.InnerText = data[0]["Book_Name"].ToString();
                }

                else
                {
                    Response.Redirect("ERROR.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        private void querryDatabase()
        {
            string query = "SELECT Chapter_ID, Chapter_Title FROM chapter WHERE Book_ID = ?book" //+ Request.QueryString["book"] 
                    + " ORDER BY Chapter_ID ASC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", Request.QueryString["book"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                {
                    var id = new List<string>();
                    var name = new List<string>();

                    for(int i = 0; i < data.Length; i++)
                    {
                        id.Add(data[i]["Chapter_ID"].ToString());
                        name.Add(data[i]["Chapter_Title"].ToString());
                    }

                    setUpButtons(id, name);
                }

                else
                {
                    //COMMENTED OUT SO THAT I CAN TEST PROPERLY

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

        private void setUpButtons(List<string> id, List<string> name)
        {
            for(int i = 0; i < id.Count; i++)
            {
                var button = new Button { ID = id[i], Text = name[i], Width = 210 };
                //button.Click += ButtonClick;
                button.Command += new CommandEventHandler(DynamicCommand);
                button.CommandArgument = id[i];
                ChapterHolder.Controls.Add(button);
                ChapterHolder.Controls.Add(new LiteralControl("<br />"));
            }
            
        }

        private void DynamicCommand(object sender, CommandEventArgs e)
        {
            try
            {
                Response.Redirect("Problems.aspx?book=" + Request.QueryString["book"] + "&chapter=" + e.CommandArgument, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch(Exception except)
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void PrevButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT Book_ID FROM `book`"
                    + " WHERE Book_ID < ?book"
                    + " ORDER BY Book_ID DESC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", Request.QueryString["book"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                {
                    Response.Redirect("Chapters.aspx?book=" + data[0]["Book_ID"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                else
                {
                    Response.Redirect("Books.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT Book_ID FROM `book`"
                    + " WHERE Book_ID > ?book"
                    + " ORDER BY Book_ID ASC;";

            List<SQLParameters> param = new List<SQLParameters>();
            param.Add(new SQLParameters("?book", Request.QueryString["book"]));

            SQLHandler handler = new SQLHandler(query, param, 1);

            if (handler.executeStatment())
            {
                DataRow[] data = handler.Data;

                if (data.Length > 0)
                {
                    Response.Redirect("Chapters.aspx?book=" + data[0]["Book_ID"], false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                else
                {
                    Response.Redirect("Books.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }

            else
            {
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

            
        }
    }

}