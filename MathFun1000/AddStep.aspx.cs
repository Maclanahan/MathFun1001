using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class AddTutorial : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        String queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addStep_Click(object sender, EventArgs e)
        {
            addStep();
        }

        private void addStep()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            queryStr = "";

            queryStr = "INSERT INTO db_9bad3d_test.Step (Info, Example, Rules, Difficulty)" +
                //"VALUES('" + Info_TextBox.Text + "','" + Example_TextBox.Text + "','" + Rules_TextBox.Text + "','" + Diff_TextBox.Text + "')";
                    "VALUES(?Info, ?Example, ?Rules, ?Diff)";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Prepare();
            cmd.Parameters.AddWithValue("?Info", Info_TextBox.Text);
            cmd.Parameters.AddWithValue("?Example", Example_TextBox.Text);
            cmd.Parameters.AddWithValue("?Rules", Rules_TextBox.Text);
            cmd.Parameters.AddWithValue("?Diff", Diff_TextBox.Text);

            cmd.ExecuteReader();

            conn.Close();
        }

    }
}