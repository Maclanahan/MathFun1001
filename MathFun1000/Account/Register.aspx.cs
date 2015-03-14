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

            if(IsPostBack && username.Value != "" && email.Value != "")
            {
                MessageBox("POSTBACK");
                //registerUserWithSlowHash();
            }
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //MessageBox("HereFirst");

            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);
            MessageBox("In Created User");

            username.Value = RegisterUser.UserName;
            email.Value = RegisterUser.Email;
            password.Value = RegisterUser.Password;

            registerUserWithSlowHash();

            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
           // if (!OpenAuth.IsLocalUrl(continueUrl))
           // {
            //    continueUrl = "~/";
           // }
           // Response.Redirect(continueUrl);
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
            MessageBox("In Slow Hash");
            bool methodStatus = true;
            if (InputValidation.ValidateUserName(username.Value) == false)
            {
                MessageBox("Failed Name");
                methodStatus = false;
            }
            if (InputValidation.ValidateEmail(email.Value) == false)
            {
                MessageBox("Failed Email");
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
                cmd.Parameters.AddWithValue("?UserName", username.Value);
                cmd.Parameters.AddWithValue("?EmailAddress", RegisterUser.Email);

                String saltHashReturned = PasswordHash.CreateHash(password.Value);
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
                //MessageBox("Here");
                //lbl_Confirmation.Text = "Congratulations, you are registered!";
                FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

                string continueUrl = RegisterUser.ContinueDestinationPageUrl;
                if (!OpenAuth.IsLocalUrl(continueUrl))
                {
                    continueUrl = "~/";
                }
                Response.Redirect(continueUrl);
            }

            
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
    }
}