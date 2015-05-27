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
                labelUserNameTeacher.Text = TeacherName;
            }
        }

        protected void btnTeacherLogOut_Click(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Session.Abandon();
            Response.BufferOutput = true;
            Response.Redirect("LogIn.aspx", false);
        }
    }
}