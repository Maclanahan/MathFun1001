/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Problems.aspx.cs
*
* Brief Description: Problems webpage, after the Chapter
* is selected you select a Problem from that Chapter.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class Problems : System.Web.UI.Page
    {
        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            //None
        }

        //Start - These buttons are made for test purpuses, they will be dynamically created in final product
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "2");
        }

        protected void Button3_Click(object sender, EventArgs e) 
        {
            Response.Redirect("MathProgram.aspx?problem=" + "3");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "4");
        }
        //End
    }
}