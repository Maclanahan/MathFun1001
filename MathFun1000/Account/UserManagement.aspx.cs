﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        String queryStr;

        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            //if (!IsPostBack)
            //{
            //    // Determine the sections to render
            //    //var hasLocalPassword = OpenAuth.HasLocalPassword(User.Identity.Name);
            //    //setPassword.Visible = !hasLocalPassword;
            //    //changePassword.Visible = true;

            //    //CanRemoveExternalLogins = hasLocalPassword;

            //    // Render success message
            //    var message = Request.QueryString["m"];
            //    if (message != null)
            //    {
            //        // Strip the query string from action
            //        Form.Action = ResolveUrl("~/Account/Manage");

            //        SuccessMessage =
            //            message == "ChangePwdSuccess" ? "Your password has been changed."
            //            : message == "SetPwdSuccess" ? "Your password has been set."
            //            : message == "RemoveLoginSuccess" ? "The external login was removed."
            //            : String.Empty;
            //        successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
            //    }
            //}

        }

        //protected void setPassword_Click(object sender, EventArgs e)
        //{
        //    if (IsValid)
        //    {
        //        var result = OpenAuth.AddLocalPassword(User.Identity.Name, password.Text);
        //        if (result.IsSuccessful)
        //        {
        //            Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
        //        }
        //        else
        //        {

        //            ModelState.AddModelError("NewPassword", result.ErrorMessage);

        //        }
        //    }
        //}


        //public IEnumerable<OpenAuthAccountData> GetExternalLogins()
        //{
        //    var accounts = OpenAuth.GetAccountsForUser(User.Identity.Name);
        //    CanRemoveExternalLogins = CanRemoveExternalLogins || accounts.Count() > 1;
        //    return accounts;
        //}

        //public void RemoveExternalLogin(string providerName, string providerUserId)
        //{
        //    var m = OpenAuth.DeleteAccount(User.Identity.Name, providerName, providerUserId)
        //        ? "?m=RemoveLoginSuccess"
        //        : String.Empty;
        //    Response.Redirect("~/Account/Manage" + m);
        //}
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            updatePassword();
        }

        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            // You can change this method to convert the UTC date time into the desired display
            // offset and format. Here we're converting it to the server timezone and formatting
            // as a short date and a long time string, using the current thread culture.
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[never]";
        }

        private void updatePassword()
        {
            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";

                //queryStr = "INSERT INTO db_9bad3d_test.userinfo (UserName, EmailAddress, SlowHashSalt)" +
                //"VALUES(?UserName, ?EmailAddress, ?SlowHashSalt)";

                queryStr = "UPDATE db_9bad3d_test.userinfo SET SlowHashSalt=?shs WHERE UserName=?uname";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("?uname", User.Identity.Name);

                //TextBox passwordBox = (TextBox)changePassword.FindControl("NewPassword");
                String NP = NewPassword.Text;

                String saltHashReturned = Account.PasswordHash.CreateHash(NP);
                int commaIndex = saltHashReturned.IndexOf(":");
                String extractedString = saltHashReturned.Substring(0, commaIndex);
                commaIndex = saltHashReturned.IndexOf(":");
                extractedString = saltHashReturned.Substring(commaIndex + 1);
                commaIndex = extractedString.IndexOf(":");
                String salt = extractedString.Substring(0, commaIndex);
                commaIndex = extractedString.IndexOf(":");
                extractedString = extractedString.Substring(commaIndex + 1);

                String hash = extractedString;
                cmd.Parameters.AddWithValue("?shs", saltHashReturned);

                cmd.ExecuteReader();
                conn.Close();
                FailureText.Text = "Congratulations, your password has been changed!";
            }
            catch (Exception e)
            {
                FailureText.Text = "There was an error, your password was not changed.";
            }


        }
    }
}