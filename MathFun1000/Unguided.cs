using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 
{
    public class Unguided : IProblemType
    {
        public String[] step;
        public String[] example;
        public String[] rule;
        public int difficulty = 1;
        public int number_of_steps = 5;
        public int current_step = 0;

        public Unguided() 
        {
            this.number_of_steps = 2;
            this.difficulty = 1;
            this.step = new String[] {"Identify the different variables.", 
                "Separate the variables into like groups.", 
                "Combine the like terms.", 
                "Recombine the terms after removing the parenthese to make an equation in its seimplets form. Since the variables are differnt, this is the simplest form.", 
                "Solution"};
            this.example = new String[] {"<p style=\"color:blue\">(2x<sup>2</sup>y</p> <p style=\"color:red\">-3xy)</p> <p>+</p> <p style=\"color:blue\">(6x<sup>2</sup>y</p><p>-</p><p style=\"color:red\">9xy)</p>", 
                                        "<p style=\"color:blue\">(2x<sup>2</sup>y+6x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-3xy-9xy)</p>",
                                        "<p style=\"color:blue\">(8x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-12xy)</p>", 
                                        "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>", 
                                        "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>"};
            this.rule = new String[] {"Rule Here", 
                "Rule Here", 
                "Rule Here", 
                "Rule Here", 
                "Rule Here"};
        }

        public Unguided(String[] step, String[] example, String[] rule, int difficulty, int number_of_steps) 
        {
            this.step = step;
            this.example = example;
            this.rule = rule;
            this.difficulty = difficulty;
            this.number_of_steps = number_of_steps;
        }

        public override int getNumberOfSteps()
        {
            return number_of_steps;
        }

        public override string getExampleAt(int index)
        {
            return example[index];
        }

        public override string getStepAt(int index)
        {
            return step[index];
        }

        public override string getRuleAt(int index)
        {
            return rule[index];
        }

        public override string generateCode(int numOfSteps)
        {
            string code = "";
            if (numOfSteps > -1)
            { 
                //for (int i = 0; i <= numOfSteps; i++)
                //{
                    //if (i < number_of_steps)
                    //{
                        code += "<div class=\"StepContainer\">";

                        

                        if (numOfSteps == 0)
                        {
                            code += "<div class=\"box\"><p>" + getStepAt(0) + "</p></div>";
                            code += "<div class=\"box\"><p>" + setUpInput(getExampleAt(0)) + "</p></div>";
                            code += "<div class=\"box\"><p>" + getRuleAt(0) + "</p></div>";
                        }
                        else
                        {
                            code += "<div class=\"box\"><p>" + getStepAt(step.Length - 1) + "</p></div>";
                            code += "<div class=\"box\"><p>" + removeColons(getExampleAt(example.Length - 1)) + "</p></div>";
                            code += "<div class=\"box\"><p>" + getRuleAt(rule.Length - 1) + "</p></div>";
                        }
                        

                        code += "<div class=\"buttons\">";
                        code += "</div>";

                        code += "</div>";
                   // }
             }

            return code;
        }

        private string parseToRemoveTags(string parse)
        {
            parse = removeColons(parse);
            parse.Trim();

            while(parse.Contains("<") && parse.Contains(">"))
            {
                int first = parse.IndexOf("<");

                int last = parse.IndexOf(">");

                int final = last - first + 1;

                parse = parse.Remove(first, final);
            }

            while(parse.Contains(" "))
            {
                parse = parse.Remove(parse.IndexOf(" "), 1);
            }

            return parse;
        }

        private string removeColons(string parse)
        {
            if (parse.IndexOf("::") >= 0)
            {
                int first = parse.IndexOf("::");

                int last = parse.LastIndexOf("::");

                parse = parse.Remove(last, 2);
                parse = parse.Remove(first, 2);
            }

            return parse;
        }

        private string setUpInput(string parse)
        {
            string code = "";
            string answer = parseToRemoveTags(getExampleAt(example.Length - 1));

            code += removeColons(parse);

            code += "<br/><input class=\"unguidedBox\" id=\"AnswerBox\" type=\"text\" value=\"\" autoComplete=\"off\"/>";
            code += "<br/><input class=\"button\" id=\"CheckButton\" type=\"button\" value=\"&#x2713\" onClick=\"checkAnswer()\"/>";
            code += "<label for=\"CheckButton\" id=\"CheckLabel\" style=\"display:inline-block\" ></label>"; 

            code += "<script> function checkAnswer(){" +
                        "var label = document.getElementById('CheckLabel');" +
                        "var answer = document.getElementById('AnswerBox').value;" +
                        " answer = answer.replace(/\\s/g, \"\");" +
                        "if(answer == \"" + answer + "\")" +
                            "label.innerHTML = \"Correct!\";" +
                        "if(answer != \"" + answer + "\")" +
                            "label.innerHTML = \"incorrect\";" +
                    "} </script>";



            return code; 
        }
    }
}