/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Chapters.aspx.cs
*
* Brief Description: Chapters webpage code.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class Chapters : System.Web.UI.Page
    {
        private Tutorial tut1;
        private Tutorial tut2;

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //Buttons for the chapters, when clicked send you to the problems in that chapter.
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Problems.aspx?chapter=" + "1");
        }

        


    }
}