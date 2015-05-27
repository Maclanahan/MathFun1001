using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class LoggedInStudent : System.Web.UI.Page
    {
        String StudentName;
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentName = (String)Session["uname"];
            if (StudentName == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("LogIn.aspx", false);
            }
            else
            {
                labelUserNameStudent.Text = StudentName;
            }
        }

        protected void btnStudentLogOut_Click(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Session.Abandon();
            Response.BufferOutput = true;
            Response.Redirect("LogIn.aspx", false);
        }
    }
}