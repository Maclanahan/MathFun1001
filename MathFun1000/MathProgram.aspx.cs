/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: MathProgram.aspx.cs
*
* Brief Description: MathProgram is the main webpage for our site
* it controls the overall flow of the program as well as interactions
* with other classes.
*/

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
        public IProblemType steps = new Unguided();
        private int currentProblemNumber;

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUpProblem();

            if(!IsPostBack)
            {
                stepCount.Value = "0";
                problemType.Value = "Tutorial";
            }
            
            GenerateCode();

            SetUpButtons();
        }

        //Description
        private void SetUpProblem()
        {
            if(!string.IsNullOrEmpty(Request.QueryString["problem"]))
            {
                if (Request.QueryString["problem"] == "1")
                {
                    CheckTypeOfProblem();
                }

                if (Request.QueryString["problem"] == "2")
                {
                    String[] step = new String[] { "step1", "step2", "step3" };
                    String[] example = new String[] { "step1", "step2", "step3" };
                    String[] rule = new String[] { "step1", "step2", "step3" };

                    steps = new Tutorial(step, example, rule, 1, 3);
                }
                if (Request.QueryString["problem"] == "3") 
                {
                    Response.Redirect("Graph.aspx");
                }
                else
                {
                    CheckTypeOfProblem();
                }
            }
        }

        //Check to see what type of problem it is
        private void CheckTypeOfProblem()
        {
            if (problemType.Value.Equals("Tutorial"))
                steps = new Tutorial();

            else if (problemType.Value.Equals("FillIn"))
                steps = new Fill_In();

            else
                steps = new Unguided();
        }

        //Set up basic buttons for the problem
        private void SetUpButtons()
        {
            if (Convert.ToInt32(stepCount.Value) > 0)
            {
                Button bt2 = new Button();
                bt2.CssClass = bt2.ID = "StepBackwardButton";                
                bt2.Text = "Prev";
                bt2.Click += new EventHandler(StepBackwardButton_Click);

                innerMain.Controls.Add(bt2);
            }

            if (Convert.ToInt32(stepCount.Value) < steps.GetNumberOfSteps() - 1)
            {
                Button bt1 = new Button();
                bt1.CssClass = bt1.ID = "StepForwardButton";               
                bt1.Text = "Next";
                bt1.Click += new EventHandler(StepForwardButton_Click);

                innerMain.Controls.Add(bt1);
            }

            if(Convert.ToInt32(stepCount.Value) == steps.GetNumberOfSteps() - 1)
            {
                Button bt3 = new Button();
                bt3.CssClass = bt3.ID = "StepForwardButton";
                bt3.Text = "Next Problem";
                bt3.Click += new EventHandler(GoToNextProblem_Click);

                innerMain.Controls.Add(bt3);
            }

        }

        //Event handler for next button
        protected void StepForwardButton_Click(object sender, EventArgs e)
        {
            IncrementStepCount(1);

            GenerateCode();
       
            SetUpButtons();
            
        }

        //Event handler for prev button
        protected void StepBackwardButton_Click(object sender, EventArgs e)
        {
            IncrementStepCount(-1);

            GenerateCode();

            SetUpButtons();

        }

        //Event handler for next problem button (next button turns into this button at the end of problem)
        protected void GoToNextProblem_Click(object sender, EventArgs e)
        {
            String problemNum = Request.QueryString["problem"];
            int num = Convert.ToInt32(problemNum) + 1;
            Console.Out.WriteLine(num);
            Response.Redirect("MathProgram.aspx?problem=" + num.ToString());

        }

        //Generates code from the problem itself
        private void GenerateCode()
        {
            string parse = steps.GenerateCode( Convert.ToInt32(stepCount.Value) );

            ParseForInput(parse);

        }

        //Description
        private void ParseForInput(string parse)
        {
            innerMain.InnerHtml = parse;
        }

        //Increment Step Count
        private void IncrementStepCount(int _inc)
        {
            if (Convert.ToInt32(stepCount.Value) + _inc >= 0)
            {
                int count = Convert.ToInt32(stepCount.Value);
                count += _inc;
                stepCount.Value = count.ToString();
            }
        }

        //Event handler for Fill In The Blank problem type
        protected void FillInTheBlank_Click(object sender, EventArgs e)
        {
            steps = new Fill_In();
            problemType.Value = "FillIn";

            Tutorial.BackColor = System.Drawing.ColorTranslator.FromHtml("#68709F");
            FillInTheBlank.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");
            AnswerOnly.BackColor = System.Drawing.ColorTranslator.FromHtml("#68709F");

            GenerateCode();

            SetUpButtons();
        }

        //Event handler for Tutorial problem type
        protected void Tutorial_Click(object sender, EventArgs e)
        {
            steps = new Tutorial();
            problemType.Value = "Tutorial";

            Tutorial.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");
            FillInTheBlank.BackColor = System.Drawing.ColorTranslator.FromHtml("#68709F");
            AnswerOnly.BackColor = System.Drawing.ColorTranslator.FromHtml("#68709F");

            GenerateCode();

            SetUpButtons();
        }

        //Event handler for Unguided problem type
        protected void AnswerOnly_Click(object sender, EventArgs e)
        {
            steps = new Unguided();
            problemType.Value = "Unguided";

            Tutorial.BackColor = System.Drawing.ColorTranslator.FromHtml("#68709F");
            FillInTheBlank.BackColor = System.Drawing.ColorTranslator.FromHtml("#68709F");
            AnswerOnly.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");

            stepCount.Value = "0";

            GenerateCode();

            SetUpButtons();
        }
    }
}