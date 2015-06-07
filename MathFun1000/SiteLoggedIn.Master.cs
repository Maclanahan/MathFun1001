/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Site.Master.cs
*
* Brief Description: Site.Master is an over all template for all
* the sites we create, it controls color, looks, and over all feel
* of every class to keep consistent.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class SiteLoggedIn : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private String StudentName;
        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentName = (String)Session["uname"];
            if (StudentName == null)
            {
                FindControl("xx").Visible = false;
                Response.BufferOutput = true;
                Response.Redirect("LogIn.aspx", false);
            }

            if (Session["userType"] != null)
            {
                if (Session["userType"].Equals("Teacher"))
                {
                    FindControl("xx").Visible = true;
                }
                else
                {
                    FindControl("xx").Visible = false;
                }
            }
            else
            {
                FindControl("xx").Visible = false;
            }
            //else
            //{
            //    label_UserName.Text = "Welcome, " + StudentName;
            //}
        }

        //On page initiation this event handler is called
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            if (Session["userType"] != null)
            {
                if (Session["userType"].Equals("Teacher"))
                {
                    FindControl("xx").Visible = true;
                }
                else
                {
                    FindControl("xx").Visible = false;
                }
            }
            else
            {
                FindControl("xx").Visible = false;
            }
            
            
            Page.PreLoad += MasterPagePreLoad;
        }

        //Master Page Preload
        protected void MasterPagePreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        public void btn_Logout_Click(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Session["userType"] = null;
            Session.Abandon();
            Response.BufferOutput = true;
            Response.Redirect("LogIn.aspx", false);
        }


    }
}