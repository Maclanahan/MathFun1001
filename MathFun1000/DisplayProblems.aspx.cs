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
    public partial class DisplayProblems : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        String queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow grow in GridView1.Rows)
            {
                CheckBox chkdel = (CheckBox)grow.FindControl("chkDel");
                if (chkdel.Checked)
                {
                    int stepid = Convert.ToInt32(grow.Cells[1].Text);

                    DeleteRecord(stepid);
                }
            }
            BindData();
        }

        protected void DeleteRecord(int stepid)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            cmd = new MySqlCommand("DELETE FROM STEP where Step_ID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", stepid);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            queryStr = "";
            queryStr = "SELECT Step_ID,Info,Example,Rules,Difficulty FROM STEP;";
            cmd = new MySqlCommand(queryStr, conn);
            conn.Open();


            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox textboxInfo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("textboxInfo");
            TextBox textboxExample = (TextBox)GridView1.Rows[e.RowIndex].FindControl("textboxExample");
            TextBox textboxRules = (TextBox)GridView1.Rows[e.RowIndex].FindControl("textboxRules");
            TextBox textboxDifficulty = (TextBox)GridView1.Rows[e.RowIndex].FindControl("textboxDifficulty");

            UpdateStep(id, textboxInfo.Text, textboxExample.Text, textboxRules.Text, int.Parse(textboxDifficulty.Text));
            GridView1.EditIndex = -1;
            BindData();
        }

        private void UpdateStep(int id, String info, String Example, String Rules, int diff)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            using (conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                queryStr = "UPDATE STEP SET info=?info, Example=?example, Rules=?rules, Difficulty=?difficulty WHERE Step_ID=?id";
                //queryStr = "UPDATE STEP SET Info='" + info + "',Example='" + Example + "',Rules='" + Rules + "',Difficulty='" + diff + "' WHERE Step_ID='" + id + "';";
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();

                cmd.Prepare();
                cmd.Parameters.AddWithValue("?info", info);
                cmd.Parameters.AddWithValue("?example", Example);
                cmd.Parameters.AddWithValue("?rules", Rules);
                cmd.Parameters.AddWithValue("?difficulty", diff);
                cmd.Parameters.AddWithValue("?id", id);

                cmd.ExecuteNonQuery();
            }

        }

        protected void btnAllHelp_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnMedium_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            using (conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                queryStr = "";
                queryStr = "SELECT Step_ID,Info,Example,Rules,Difficulty FROM STEP WHERE Difficulty >= 2";
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


        protected void btnNoHelp_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            using (conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                queryStr = "";
                queryStr = "SELECT Step_ID,Info,Example,Rules,Difficulty FROM STEP WHERE Difficulty = 3";
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

    }
}