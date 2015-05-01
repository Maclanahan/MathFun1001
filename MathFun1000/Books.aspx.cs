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
    public partial class Books : System.Web.UI.Page
    {
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
            queryStr = "SELECT Book_ID, Book_Name FROM book ORDER BY Book_ID ASC;";

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
            } catch (Exception e)
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
                ButtonHolder.Controls.Add(button);
                ButtonHolder.Controls.Add(new LiteralControl("<br />"));
            }
            
        }

        private void DynamicCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("Chapters.aspx?book=" + e.CommandArgument, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}