using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;

namespace MathFun1000
{
    public partial class ParameterizedQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            queryDatabase();
        }

        private void queryDatabase()
        {
            var problem = "25";

            MySql.Data.MySqlClient.MySqlConnection con;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            con = new MySql.Data.MySqlClient.MySqlConnection(connString);

            queryStr = "SELECT UserName, Password FROM userinfo WHERE UserID = ?id";

            try
            {
                using (cmd = new MySqlCommand(queryStr, con))
                {
                    con.Open();
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("?id", problem);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.InnerText += reader.GetString(0) + " ";
                            results.InnerText += reader.GetString(1) + ". ";
                        }
                    }
                }

                con.Close();
            }
            catch(Exception e)
            {
                con.Close();
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}