using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class Multi : System.Web.UI.Page
    {
        public Multis multi_int = new Multis();

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            querryDatabase();

            GenerateCode();
            //CorrectAnswer();//Give JavaScript Correct Answer.
            SetUpButtons();
        }

        private void querryDatabase()
        {

        }

        private void SetUpButtons()
        {

        }

        public void CorrectAnswer()
        {
            string TheCorrectAnswer = multi_int.getCorrect();

            string script = "<script>";
            script += "var CorrectAnswer = "+TheCorrectAnswer+";\n";
            script += "</script>\n";
            arrayData.InnerHtml = script;
        }

        private void GenerateCode()
        {
            string TheCorrectAnswer = multi_int.getCorrect();
            string script = "<script>";
            script += "var example = [];\n";
            script += "var CorrectAnswer = \"" + TheCorrectAnswer + "\";\n";

            for (int i = 0; i < multi_int.GetNumberOfSteps(); i++)
            {
                if(i==0)
                {
                    script += "example[" + i + "] = \"" + multi_int.Question + "\";\n";
                }
                else if (i == 1)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer1 + "\";\n";
                }
                else if (i == 2)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer2 + "\";\n";
                }
                else if (i == 3)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer3 + "\";\n";
                }
                else if (i == 4)
                {
                    script += "example[" + i + "] = \"" + multi_int.Answer4 + "\";\n";
                }
                else if (i == 5)
                {
                    
                }
                

            }

            script += "</script>\n";
            arrayData.InnerHtml = script;

            


            //string parse = multi_int.GenerateCode();
            //ParseForInput(parse);
        }

        private void ParseForInput(string parase)
        {
            innerMain.InnerHtml = parase;
        }
    }
}