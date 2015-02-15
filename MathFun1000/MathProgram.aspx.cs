using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class MathProgram : System.Web.UI.Page
    {
        public Chapter chapter;
        public Tutorial steps = new Tutorial();

        protected void Page_Load(object sender, EventArgs e)
        {
            

            setUpProblem();

            //test for Session object. Can use it, but the data does persist even if you visit a different page.
            //could be usefull for other things
            if(Session["count"] == null)
            {
                Session["count"] = 0;
            }

            if(!IsPostBack)
            {
                stepCount.Value = "0";
                
            }
            
            innerMain.InnerHtml = generateCode();

        }

        private void setUpProblem()
        {
            if(!string.IsNullOrEmpty(Request.QueryString["problem"]))
            {
                if (Request.QueryString["problem"] == "1")
                {
                    steps = new Tutorial();
                }

                if (Request.QueryString["problem"] == "2")
                {
                    String[] step = new String[] { "step1", "step2", "step3" };
                    String[] example = new String[] { "step1", "step2", "step3" };
                    String[] rule = new String[] { "step1", "step2", "step3" };

                    steps = new Tutorial(step, example, rule, 1, 3);
                }

                else
                {
                    steps = new Tutorial();
                }
            }
        }

        protected void StepForwardButton_Click(object sender, EventArgs e)
        {
            incrementStepCount();

            innerMain.InnerHtml = generateCode();
            
        }

        private string generateCode()
        {
            string code = "";

            for (int i = 0; i <= Convert.ToInt32(stepCount.Value); i++)
            {
                if (i < steps.number_of_steps)
                {
                    code += "<div class=\"StepContainer\">";

                    code += "<div class=\"box\">" + steps.step[i] + "</div>";
                    code += "<div class=\"box\">" + steps.example[i] + "</div>";
                    code += "<div class=\"box\">" + steps.rule[i] + "</div>";

                    code += "</div>";
                }
            }

            return code;
        }

        private void incrementStepCount()
        {
            int count = Convert.ToInt32(stepCount.Value);
            count++;
            stepCount.Value = count.ToString();

            int num = Convert.ToInt32(Session["count"]);
            num++;
            Session["count"] = num.ToString();
        }
    }
}