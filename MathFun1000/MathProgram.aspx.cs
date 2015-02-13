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
            if(!IsPostBack)
            {
                stepCount.Value = "0";
            }

            innerMain.InnerHtml = generateCode();

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
        }
    }
}