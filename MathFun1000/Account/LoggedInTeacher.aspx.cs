/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: InputValidation.cs
*
* Brief Description: CS code for the Logged in teacher page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000.Account
{
    public partial class LoggedInTeacher : System.Web.UI.Page
    {
        String TeacherName;
        protected void Page_Load(object sender, EventArgs e)
        {
            TeacherName = (String)Session["uname"];
            if (TeacherName == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("LogIn.aspx", false);
            }
            else
            {
               
                Response.Redirect("~/", false);
            }
        }
    }
}