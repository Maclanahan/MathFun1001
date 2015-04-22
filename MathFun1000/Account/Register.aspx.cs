using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace MathFun1000.Account
{
    public partial class Register : Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        String queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            registerUserWithSlowHash();

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        ///**
        //  * This class handles the Register button.
        //  **/
        // protected void btnRegister_Click(object sender, EventArgs e)
        // {
        //     registerUserWithSlowHash();
        // }

        /**
         * Current Register User Method. 
         * Security: SlowHashSalt
         **/
        private void registerUserWithSlowHash()
        {
            bool methodStatus = true;
            if (InputValidation.ValidateUserName(RegisterUser.UserName) == false)
            {
                methodStatus = false;
            }
            if (InputValidation.ValidateEmail(RegisterUser.Email) == false)
            {
                methodStatus = false;
            }
            if (methodStatus == true)
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";

                queryStr = "INSERT INTO db_9bad3d_test.userinfo (UserName, EmailAddress, SlowHashSalt)" +
                "VALUES(?UserName, ?EmailAddress, ?SlowHashSalt)";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("?UserName", RegisterUser.UserName);
                cmd.Parameters.AddWithValue("?EmailAddress", RegisterUser.Email);

                String saltHashReturned = PasswordHash.CreateHash(RegisterUser.Password);
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

                cmd.ExecuteReader();
                conn.Close();

                //lbl_Confirmation.Text = "Congratulations, you are registered!";
            }
        }
    }
}