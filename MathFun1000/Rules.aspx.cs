/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Rules.aspx.cs
*
* Brief Description: Display of rules on the math problem page
 * this is a helper class.
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
using System.Web.UI.HtmlControls;

namespace MathFun1000
{
    public partial class Rules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            queryDatabase();
        }

        private void queryDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            String queryStr;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";

            queryStr = "SELECT rule_name, rule_Desc, rule_example, rule_Link FROM `rule`"
                + " WHERE rule_ID > 1 "
                + " ORDER BY rule_name ASC;";

            try
            {
                using (cmd = new MySqlCommand(queryStr, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var name = new List<string>();
                        var desc = new List<string>();
                        var example = new List<string>();
                        var link = new List<string>();

                        while (reader.Read())
                        {
                            setUpRule(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                            setUpMenu(reader.GetString(0), reader.GetString(3));
                        }

                    }

                    conn.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                Response.Redirect("ERROR.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private void setUpMenu(string name, string link)
        {
            var newLink = new HtmlGenericControl("li");

            var anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", "#MainContent_" + link);
            anchor.InnerHtml = name;

            newLink.Controls.Add(anchor);

            linkList.Controls.Add(newLink);
            
        }

        private void setUpRule(String name, String desc, String example, string link)
        {
            var header = new HtmlGenericControl("h2");
            header.InnerHtml = name;
            header.Attributes.Add("class", "ruleHeader");
            header.ID = link;

            var description = new HtmlGenericControl("p");
            description.InnerHtml = desc;

            var ex = new HtmlGenericControl("p");
            ex.InnerHtml = example;

            var box = new HtmlGenericControl("div");
            box.Attributes.Add("class", "ruleDescBox");
            box.Controls.Add(description);
            box.Controls.Add(new LiteralControl("<br/>"));
            box.Controls.Add(ex);
            box.Controls.Add(new LiteralControl("<br/>"));
            box.Controls.Add(new LiteralControl("<br/>"));
            box.Controls.Add(new LiteralControl("<br/>"));
            box.Controls.Add(new LiteralControl("<br/>"));

            ruleHolder.Controls.Add(header);
            ruleHolder.Controls.Add(box);
        }
    }
}