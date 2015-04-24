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
    public partial class MathProgramJavascript : System.Web.UI.Page
    {
        public Problem problem = new Problem();
        public IProblemType steps = new Unguided();
        private int currentProblemNumber;

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            steps =  new Tutorial();

            convertToJavaScript();

            executeJavaScript();
        }

        private void executeJavaScript()
        {
            //string script = "<script>";

            //script +=
        }

        private void convertToJavaScript()
        {
            string script = "<script>";
            script += "var step = [];\n";
            script += "var example = [];\n";
            script += "var rule = [];\n";

            for(int i = 0; i < steps.GetNumberOfSteps(); i++)
            {
                script += "step[" + i + "] = \"" + steps.GetStepAt(i) + "\";\n";
                script += "example[" + i + "] = \"" + steps.GetExampleAt(i) + "\";\n";
                script += "rule[" + i + "] = \"" + steps.GetRuleAt(i) + "\";\n"; 

            }

            script += "</script>\n";
            arrayData.InnerHtml = script;
        }

        //Description
        private void SetUpProblem()
        {
            
        }

        //Check to see what type of problem it is
        private void CheckTypeOfProblem()
        {
            
        }

        //Set up basic buttons for the problem
        private void SetUpButtons()
        {
           

        }

        //Event handler for next button
        protected void StepForwardButton_Click(object sender, EventArgs e)
        {
           

        }

        //Event handler for prev button
        protected void StepBackwardButton_Click(object sender, EventArgs e)
        {
           

        }

        //Event handler for next problem button (next button turns into this button at the end of problem)
        protected void GoToNextProblem_Click(object sender, EventArgs e)
        {
           

        }

        //Generates code from the problem itself
        private void GenerateCode()
        {
            

        }

        //Description
        private void ParseForInput(string parse)
        {
           
        }

        //Increment Step Count
        private void IncrementStepCount(int _inc)
        {
           
        }

        //Event handler for Fill In The Blank problem type
        protected void FillInTheBlank_Click(object sender, EventArgs e)
        {

        }

        //Event handler for Tutorial problem type
        protected void Tutorial_Click(object sender, EventArgs e)
        {
           
        }

        //Event handler for Unguided problem type
        protected void AnswerOnly_Click(object sender, EventArgs e)
        {
            
        }
    }
}