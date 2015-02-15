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

        protected void Page_Load(object sender, EventArgs e)
        {
            tut1 = new Tutorial();

            String[] step = new String[] { "step1", "step2", "step3" };
            String[] example = new String[] { "step1", "step2", "step3" };
            String[] rule = new String[] { "step1", "step2", "step3" };

            tut2 = new Tutorial(step, example, rule, 1, 3);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MathProgram.aspx?problem=" + "2");
        }


    }
}