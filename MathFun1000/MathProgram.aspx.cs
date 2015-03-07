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

        protected void Page_Load(object sender, EventArgs e)
        {
            setUpProblem();

            if(!IsPostBack)
            {
                stepCount.Value = "0";
                problemType.Value = "Tutorial";
            }
            
            generateCode();

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
                if (Request.QueryString["problem"] == "3") 
                {
                    Response.Redirect("Graph.aspx");
                    /*Graphs newGraph = new Graphs();
                    
                    

                    Button btn = new Button();
                    btn.CssClass = btn.ID = "StepForwardButton";
                    btn.Text = "Next Problem";
                    btn.Click += new EventHandler(GoToNextProblem_Click);

                    innerMain.Controls.Add(btn);*/
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
                steps = new Unguided();
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

            generateCode();
       
            setUpButtons();
            
        }

        protected void StepBackwardButton_Click(object sender, EventArgs e)
        {
            incrementStepCount(-1);

            generateCode();

            setUpButtons();

        }

        protected void GoToNextProblem_Click(object sender, EventArgs e)
        {
            String problemNum = Request.QueryString["problem"];
            int num = Convert.ToInt32(problemNum) + 1;
            Console.Out.WriteLine(num);
            Response.Redirect("MathProgram.aspx?problem=" + num.ToString());

        }

        private void generateCode()
        {
            string parse = steps.generateCode( Convert.ToInt32(stepCount.Value) );

            parseForInput(parse);

            //innerMain.InnerHtml = parse;
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

        private void parseForInput(string parse)
        {
            
            innerMain.InnerHtml = parse;
            

            /*
            int first = parse.IndexOf("::");
            //Console.Out.WriteLine(first);

            int last = parse.LastIndexOf("::");
            //Console.Out.WriteLine(last);

            String answer = parse.Substring(first + 2, (first + 2) - (last - 2));

            //removes the ::
            //parse = parse.Remove(first, 2);
            //parse = parse.Remove(last - 2, 2);

            //Console.Out.WriteLine(parse);
            //Console.Out.WriteLine(answer);

            string firstHalf = parse.Substring(0, first);
            

            string secondHalf = parse.Substring(last - 2);

            innerMain.InnerHtml = firstHalf;
            innerMain.Controls.Add(new TextBox());
            innerMain.InnerHtml = secondHalf;

            //parse.Console.Out.WriteLine(firstHalf);
            //parse.Console.Out.WriteLine(secondHalf);*/
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
            problemType.Value = "FillIn";

            Tutorial.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");
            FillInTheBlank.BackColor = System.Drawing.ColorTranslator.FromHtml("#819FF7");
            AnswerOnly.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");

            generateCode();

            setUpButtons();
        }

        protected void Tutorial_Click(object sender, EventArgs e)
        {
            steps = new Tutorial();
            problemType.Value = "Tutorial";

            Tutorial.BackColor = System.Drawing.ColorTranslator.FromHtml("#819FF7");
            FillInTheBlank.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");
            AnswerOnly.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");

            generateCode();

            setUpButtons();
        }

        protected void AnswerOnly_Click(object sender, EventArgs e)
        {
            steps = new Unguided();
            problemType.Value = "Unguided";

            Tutorial.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");
            FillInTheBlank.BackColor = System.Drawing.ColorTranslator.FromHtml("#58ACFA");
            AnswerOnly.BackColor = System.Drawing.ColorTranslator.FromHtml("#819FF7");

            stepCount.Value = "0";

            generateCode();

            setUpButtons();
        }
    }
}