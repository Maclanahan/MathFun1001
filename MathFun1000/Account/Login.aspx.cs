﻿/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: login.aspx.cs
*
* Brief Description: Code behind login page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace MathFun1000.Account
{
    public partial class Login : Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String CurrentName;

        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["uname"] != null)
           {
                Response.BufferOutput = true;
                Response.Redirect("~/Default.aspx", false);
           }

            RegisterHyperLink.NavigateUrl = "Register";

            LoginWithPasswordHashFunction();

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        private void LoginWithPasswordHashFunction()
        {
            List<String> salthashList = null;
            List<String> nameList = null;
            List<String> typeList = null;

            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";
                queryStr = "SELECT UserName, SlowHashSalt, UserType FROM db_9bad3d_test.userinfo WHERE UserName=?uname";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("?uname", textboxUserName.Text);
                reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    if (salthashList == null)
                    {
                        typeList = new List<String>();
                        salthashList = new List<String>();
                        nameList = new List<String>();
                    }

                    String userType = reader.GetString(reader.GetOrdinal("UserType"));
                    typeList.Add(userType);

                    String saltHashes = reader.GetString(reader.GetOrdinal("SlowHashSalt"));
                    salthashList.Add(saltHashes);

                    String userName = reader.GetString(reader.GetOrdinal("UserName"));
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
                            if (validUser == true)
                            {
                                if (typeList[i] == "Student")
                                {
                                    Session["uname"] = nameList[i];
                                    Session["userType"] = "Student";
                                    Response.BufferOutput = true;
                                    FormsAuthentication.RedirectFromLoginPage(nameList[i], true);
                                    Response.Redirect("LoggedInStudent.aspx", false);
                                }
                                if (typeList[i] == "Teacher")
                                {
                                    Session["uname"] = nameList[i];
                                    Session["userType"] = "Teacher";
                                    Response.BufferOutput = true;
                                    FormsAuthentication.RedirectFromLoginPage(nameList[i], true);
                                    Response.Redirect("LoggedInTeacher.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            lbl_Confirmation.Text = "*User and/or Password is not valid*";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                lbl_Confirmation.Text = "E: ERROR";
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
    }
}