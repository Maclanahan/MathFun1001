using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class LogIn : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Confirmation.Text = "";
        }

        /**
         * This method handles the "Log In" button clicking on the LogIn Page. 
         **/
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (checkAgainstWhiteList(textboxUserName.Text) == true && checkAgainstWhiteList(textboxPassword.Text) == true)
            {

                LoginWithPasswordHashFunction();
            }
            else
            {
                lbl_Confirmation.Text = "Invalid characters.";
            }
        }

        /**
         * This method checks the password in the textbox against the hashed version stored in the database.
         * Security: SlowHashSalt Implemented.
         **/
        private void LoginWithPasswordHashFunction()
        {
            List<String> salthashList = null;
            List<String> nameList = null;
            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";
                queryStr = "SELECT EmailAddress, SlowHashSalt FROM db_9bad3d_test.userinfo WHERE UserName=?uname";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("?uname", textboxUserName.Text);
                reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    if (salthashList == null)
                    {
                        salthashList = new List<String>();
                        nameList = new List<String>();
                    }
                    String saltHashes = reader.GetString(reader.GetOrdinal("SlowHashSalt"));
                    salthashList.Add(saltHashes);

                    String userName = reader.GetString(reader.GetOrdinal("EmailAddress"));
                    nameList.Add(userName);
                }
                reader.Close();

                if (salthashList != null)
                {
                    for (int i = 0; i < salthashList.Count; i++)
                    {
                        queryStr = "";
                        bool validUser = PasswordHash.ValidatePassword(textboxPassword.Text, salthashList[i]);
                        if (validUser == true)
                        {
                            Session["uname"] = nameList[i];
                            Response.BufferOutput = true;
                            Response.Redirect("LoggedIn.aspx", false);
                        }
                        else
                        {
                            lbl_Confirmation.Text = "Else: User not authenticated";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_Confirmation.Text = "Exception Thrown: User not authenticated";
            }
        }

        /**
         * This is the Regex check for the input to handle SQL Injecttion. 
         **/
        private bool checkAgainstWhiteList(String userInput)
        {
            var regExpression = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9!@#$%^&*]*$");
            if (regExpression.IsMatch(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * This is the original working version of the LogIn Query
         * Security: Unhashed, checking password only.
         **/
        //private void query()
        //{
        //    //try
        //    //{
        //        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["webAppconnString"].ToString();
        //        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        //        conn.Open();
        //        queryStr = "";
        //        queryStr = "SELECT * FROM db_9bad3d_test.userinfo WHERE UserName=?uname AND Password=?pword";
        //        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        //        cmd.Parameters.AddWithValue("?uname", textboxUserName.Text);
        //        cmd.Parameters.AddWithValue("?pword", textboxPassword.Text);

        //        //cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

        //        reader = cmd.ExecuteReader();
        //        name = "";
        //        while (reader.HasRows && reader.Read())
        //        {
        //            name = reader.GetString(reader.GetOrdinal("EmailAddress"));
        //        }
        //        if (reader.HasRows)
        //        {
        //            Session["uname"] = name;
        //            Response.BufferOutput = true;
        //            Response.Redirect("LoggedIn.aspx", false);
        //        }
        //        else
        //        {
        //            lbl_Confirmation.Text = "Else: Invalid User Name or Password!!!";
        //        }

        //        reader.Close();
        //        conn.Close();
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    lbl_Confirmation.Text = "Exception Thrown: Invalid User Name or Password!!!";
        //    //}
        //}


    }
}