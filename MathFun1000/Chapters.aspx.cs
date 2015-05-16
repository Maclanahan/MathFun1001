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
        private Tutorial tut1;
        private Tutorial tut2;

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
                queryStr = "SELECT Chapter_ID, Chapter_Title FROM chapter WHERE Book_ID = " + Request.QueryString["book"] 
                    + " ORDER BY Chapter_ID ASC;";
            else
                Response.Redirect("Books.aspx");
            try
            {
                using (cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var id = new List<string>();
                        var name = new List<string>();

                        while (reader.Read())
                        {
                            id.Add(reader.GetString(0));
                            name.Add(reader.GetString(1));
                        }

                        setUpButtons(id, name);
                    }

                    conn.Close();
                }
            }  catch (Exception e)
            {
                //need to log the exception
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
            Response.Redirect("Problems.aspx?book=" + Request.QueryString["book"] +"&chapter=" + e.CommandArgument, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

}