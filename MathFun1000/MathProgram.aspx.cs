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
        public Problem problem = new Problem();
        public IProblemType steps = new Tutorial();
        private int currentProblemNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            setUpProblem();

            if(!IsPostBack)
            {
                stepCount.Value = "0";
                problemType.Value = "FillIn";
            }
            
            innerMain.InnerHtml = generateCode();

            setUpButtons();
        }


        private void setUpProblem()
        {
            if(!string.IsNullOrEmpty(Request.QueryString["problem"]))
            {
                if (Request.QueryString["problem"] == "1")
                {
                    checkTypeOfProblem();
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
                    checkTypeOfProblem();
                }
            }
        }

        private void checkTypeOfProblem()
        {
            if (problemType.Value.Equals("Tutorial"))
                steps = new Tutorial();

            else if (problemType.Value.Equals("FillIn"))
                steps = new Fill_In();

            else
                steps = new Tutorial();
        }

        private void setUpButtons()
        {
            if (Convert.ToInt32(stepCount.Value) > 0)
            {
                Button bt2 = new Button();
                bt2.CssClass = bt2.ID = "StepBackwardButton";                
                bt2.Text = "Prev";
                bt2.Click += new EventHandler(StepBackwardButton_Click);

                innerMain.Controls.Add(bt2);
            }

            if (Convert.ToInt32(stepCount.Value) < steps.getNumberOfSteps() - 1)
            {
                Button bt1 = new Button();
                bt1.CssClass = bt1.ID = "StepForwardButton";               
                bt1.Text = "Next";
                bt1.Click += new EventHandler(StepForwardButton_Click);

                innerMain.Controls.Add(bt1);
            }

            if(Convert.ToInt32(stepCount.Value) == steps.getNumberOfSteps() - 1)
            {
                Button bt3 = new Button();
                bt3.CssClass = bt3.ID = "StepForwardButton";
                bt3.Text = "Next Problem";
                bt3.Click += new EventHandler(GoToNextProblem_Click);

                innerMain.Controls.Add(bt3);
            }
        }

        protected void StepForwardButton_Click(object sender, EventArgs e)
        {
            incrementStepCount(1);

            innerMain.InnerHtml = generateCode();
       
            setUpButtons();
            
        }

        protected void StepBackwardButton_Click(object sender, EventArgs e)
        {
            incrementStepCount(-1);

            innerMain.InnerHtml = generateCode();

            setUpButtons();

        }

        protected void GoToNextProblem_Click(object sender, EventArgs e)
        {
            String problemNum = Request.QueryString["problem"];
            int num = Convert.ToInt32(problemNum) + 1;
            Console.Out.WriteLine(num);
            Response.Redirect("MathProgram.aspx?problem=" + num.ToString());

        }

        private string generateCode()
        {
            return steps.generateCode( Convert.ToInt32(stepCount.Value) );

            /*string code = "";
            if (Convert.ToInt32(stepCount.Value) > -1)
                for (int i = 0; i <= Convert.ToInt32(stepCount.Value); i++)
                {
                    if (i < steps.getNumberOfSteps())
                    {
                        code += "<div class=\"StepContainer\">";

                        code += "<div class=\"box\">" + steps.getStepAt(i) + "</div>";
                        code += "<div class=\"box\">" + steps.getExampleAt(i) + "</div>";
                        code += "<div class=\"box\">" + steps.getRuleAt(i) + "</div>";

                        code += "<div class=\"buttons\">";
                        code += "</div>";

                        code += "</div>";
                    }
                }

            return code;*/
        }

        private void incrementStepCount(int _inc)
        {
            if (Convert.ToInt32(stepCount.Value) + _inc >= 0)
            {
                int count = Convert.ToInt32(stepCount.Value);
                count += _inc;
                stepCount.Value = count.ToString();
            }
        }

        protected void FillInTheBlank_Click(object sender, EventArgs e)
        {
            steps = new Fill_In();

            innerMain.InnerHtml = generateCode();

            setUpButtons();
        }

        protected void Tutorial_Click(object sender, EventArgs e)
        {
            steps = new Tutorial();

            innerMain.InnerHtml = generateCode();

            setUpButtons();
        }
    }
}