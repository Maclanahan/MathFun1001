using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000
{
    public class Multis
    {
        public string[] example;
        public string Question;
        public string Answer1;
        public string Answer2;
        public string Answer3;
        public string Answer4;
        public string Correct; //Correct answer is just the same string as 1 of the 4 answers.
        public int NumSteps;
        public int currentStep = 0;

        public Multis()
        {

            this.Question = "This is a really long test question, This would be an example of a long test question.?";
            this.Answer1 = "This is a very long answer, Sit down and let me tell you a story....I was a young boy, a boy with a dream, a dream to dream, a dream that was bigger then any dream that you or any one has ever dreampt";
            this.Answer2 = "This is wrong wrong wrong";
            this.Answer3 = "Correct";
            this.Answer4 = "Wrong";
            this.Correct = "Correct";
            this.NumSteps = 5;

            //this.example[0] = this.Question;
            //this.example[1] = this.Answer1;
            //this.example[2] = this.Answer2;
            //this.example[3] = this.Answer3;
            //this.example[4] = this.Answer4;

            this.example = new String[] {"$$\\\\color{blue}{(2x^2y}-\\\\color{red}{3xy)}+\\\\color{blue}{(6x^2y}-\\\\color{red}{9xy)}$$",
                                          "$$\\\\color{blue}{(2x^2y+6x^2y)} + \\\\color{red}{(-3xy-9xy)}$$",
                                          "$$\\\\color{blue}{(8x^2y)} + \\\\color{red}{(-12xy)}$$",
                                          "$$\\\\color{blue}{8x^2y} + \\\\color{red}{12xy}$$",
                                          "$$\\\\color{blue}{8x^2y} + \\\\color{red}{12xy}$$"};

        }

        public Multis(string Question, string Answer1, string Answer2, string Answer3, string Answer4, string Correct)
        {
            this.Question = Question;
            this.Answer1 = Answer1;
            this.Answer2 = Answer2;
            this.Answer3 = Answer3;
            this.Answer4 = Answer4;
            this.Correct = Correct;
            this.NumSteps = 5;
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

        public string getCorrect()
        {
            return this.Correct;
        }

        public int GetNumberOfSteps()
        {
            return NumSteps;
        }


        public void incrementStep()
        {
            this.currentStep++;
        }

        public void decrementStep()
        {
            this.currentStep--;
        }
    }
}