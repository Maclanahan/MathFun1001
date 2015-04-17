using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000
{
    public class Multis
    {
        public string Question;
        public string Answer1;
        public string Answer2;
        public string Answer3;
        public string Answer4;
        public string Correct; //Correct answer is just the same string as 1 of the 4 answers.

        public Multis()
        {
            this.Question = "This is a test question?";
            this.Answer1 = "Wrong";
            this.Answer2 = "Wrong";
            this.Answer3 = "Correct";
            this.Answer4 = "Wrong";
            this.Correct = "Correct";
        }

        public Multis(string Question, string Answer1, string Answer2, string Answer3, string Answer4, string Correct)
        {
            this.Question = Question;
            this.Answer1 = Answer1;
            this.Answer2 = Answer2;
            this.Answer3 = Answer3;
            this.Answer4 = Answer4;
            this.Correct = Correct;
        }

        //Generate code to send to the Mathprogram to then be generated on the website.
        public string GenerateCode()
        {
            string code = "";

            code += "<div class=\"StepContainerQuestion\">";

            code += "<div class=\"boxQuestion\"><p>" + this.Question + "</p></div>";
            code += "<div class=\"boxQuestion\"><p>" + this.Answer1 + "</p></div>";
            code += "<div class=\"boxQuestion\"><p>" + this.Answer2 + "</p></div>";
            code += "<div class=\"boxQuestion\"><p>" + this.Answer3 + "</p></div>";
            code += "<div class=\"boxQuestion\"><p>" + this.Answer4 + "</p></div>";

            code += "<div class=\"buttons\">";
            code += "</div>";

            code += "</div>";


            return code;

        }
    }
}