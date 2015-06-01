using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MathFun1000.Account
{
    public partial class Register : System.Web.UI.Page
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        String queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Confirmation.Text = "";
        }

        /**
         * This class handles the Register button.
         **/
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            registerUserWithSlowHash();
        }

        /**
         * Current Register User Method. 
         * Security: SlowHashSalt
         **/
        private void registerUserWithSlowHash()
        {
            bool methodStatus = true;
            if (InputValidation.ValidateUserName(textboxUserName.Text) == false)
            {
                methodStatus = false;
            }
            if (InputValidation.ValidateEmail(textboxEmailAddress.Text) == false)
            {
                methodStatus = false;
            }
            
            if (methodStatus == true)
            {
                String uType = "";

                if (rbList_uType.SelectedItem.ToString() == "Student") { uType = "Student"; }
                if (rbList_uType.SelectedItem.ToString() == "Teacher") { uType = "Teacher"; }
                
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySqlConnection(connString);
                conn.Open();
                queryStr = "";

                queryStr = "INSERT INTO db_9bad3d_test.userinfo (UserName, EmailAddress, SlowHashSalt, UserType)" +
                "VALUES(?UserName, ?EmailAddress, ?SlowHashSalt, ?UserType)";

                cmd = new MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("?UserName", textboxUserName.Text);
                cmd.Parameters.AddWithValue("?EmailAddress", textboxEmailAddress.Text);
                cmd.Parameters.AddWithValue("?UserType", uType);

                String saltHashReturned = PasswordHash.CreateHash(textboxPassword.Text);
                int commaIndex = saltHashReturned.IndexOf(":");
                String extractedString = saltHashReturned.Substring(0, commaIndex);
                commaIndex = saltHashReturned.IndexOf(":");
                extractedString = saltHashReturned.Substring(commaIndex + 1);
                commaIndex = extractedString.IndexOf(":");
                String salt = extractedString.Substring(0, commaIndex);
                commaIndex = extractedString.IndexOf(":");
                extractedString = extractedString.Substring(commaIndex + 1);

                String hash = extractedString;
                cmd.Parameters.AddWithValue("?SlowHashSalt", saltHashReturned);
                cmd.Prepare();
                cmd.ExecuteReader();
                conn.Close();

                lbl_Confirmation.Text = "*Congratulations, you are registered!*";
            }
            else
            {
                lbl_Confirmation.Text = "*Your Account Name and/or E-mail are either taken or not valid.*";
            }
        }

        protected void checkbox_teacher_CheckedChanged(object sender, EventArgs e)
        {

        }

        /**
         * Original working Register User Method, not used anymore. 
         * Security: Password in Text
         **/
        //private void registerUser()
        //{
        //    String connString = System.Configuration.ConfigurationManager.ConnectionStrings["webAppconnString"].ToString();
        //    conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        //    conn.Open();
        //    queryStr = "";

        //    queryStr = "INSERT INTO db_9bad3d_test.userinfo (UserName, EmailAddress, Password)" + 
        //        "VALUES('" + textboxUserName.Text + "','" + textboxEmailAddress.Text + "','" + textboxPassword.Text + "')";      

        //    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        //    cmd.ExecuteReader();

        //    conn.Close();
        //}
    }
}