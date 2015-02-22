using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 {
    public class Fill_In : IProblemType {
        public String[] step;
        public String[] example;
        public String[] rule;
        public int difficulty = 1;
        public int number_of_steps = 5;
        public string answer_to_current_step;
        public int current_step = 0;


        //Basic Contructor
        public Fill_In() {
            this.difficulty = 2;
            this.number_of_steps = 5;
            this.step = new String[] {"Identify the different variables.", 
                                      "Separate the variables into like groups.",
                                      "Combine the like terms.",
                                      "Recombine the terms after removing the parentheses to make an equation in its simplest form. Since the variables are different, this is the simplest form.",
                                      "Solution"};
            this.example = new String[]{"(2x<sup>2</sup>y -3xy) + (6x<sup>2</sup>y-9xy)", 
                                        "(2x<sup>2</sup>y+::6::x<sup>2</sup>y) + (-3xy-9xy)",
                                        "(8x<sup>2</sup>y) + (::-12::xy)", 
                                        "8x<sup>2</sup>y ::-:: 12xy", 
                                        "8x<sup>2</sup>y-12xy"};
            this.rule = new String[] {"Rule Here",
                                      "Rule Here",
                                      "Rule Here",
                                      "Rule Here",
                                      "Rule Here"};
        }

        public Fill_In(String[] step, String[] example, String[] rule, int difficulty, int number_of_steps)
        {
            this.step = step;
            this.example = example;
            this.rule = rule;
            this.difficulty = difficulty;
            this.number_of_steps = number_of_steps;
        }

        public override string generateCode(int numOfSteps)
        {
            string code = "";
            if (numOfSteps > -1)
                for (int i = 0; i <= numOfSteps; i++)
                {
                    if (i < number_of_steps)
                    {
                        code += "<div class=\"StepContainer\">";

                        code += "<div class=\"box\">" + getStepAt(i) + "</div>";

                        if( (i) == numOfSteps)
                            code += "<div class=\"box\">" + parseForInput(getExampleAt(i)) +"</div>";

                        else
                            code += "<div class=\"box\">" + parseToRemoveColons(getExampleAt(i)) + "</div>";

                        code += "<div class=\"box\">" + getRuleAt(i) + "</div>";

                        code += "<div class=\"buttons\">";
                        code += "</div>";

                        code += "</div>";
                    }
                }

            return code;

        }

        private string parseToRemoveColons(string parse)
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

        private string parseForInput(string parse)
        {
            string code = "";

            if (parse.IndexOf("::") >= 0)
            {
                int first = parse.IndexOf("::");

                int last = parse.LastIndexOf("::");
                Console.Out.WriteLine((first + 2) - (last - 2));
                String answer = parse.Substring(first + 2, (last - 1) - (first + 1));
                
                string firstHalf = parse.Substring(0, first);

                string secondHalf = parse.Substring(last + 2);

                code += firstHalf + " ";

                code += "<input class=\"answerBox\" id=\"AnswerBox\" type=\"text\" value=\"\" autoComplete=\"off\"/>";
                //code += "<asp:TextBox class=\"answerBox\" ID=\"TextBox1\" runat=\"server\" value=\"HelloWorld\"></asp:TextBox>";
                code += " " + secondHalf;

                code += "<br/><input class=\"button\" id=\"CheckButton\" type=\"button\" value=\"&#x2713\" onClick=\"checkAnswer()\"/>";
                code += "<label for=\"CheckButton\" id=\"CheckLabel\" style=\"display:inline-block\" ></label>";
                
                code += "<script> function checkAnswer(){" +
                            "var label = document.getElementById('CheckLabel');" +
                            "var answer = document.getElementById('AnswerBox').value;" +
                            "if(answer == \"" + answer + "\")" +
                                "label.innerHTML = \"Correct!\";" +
                            "if(answer != \"" + answer + "\")" +
                                "label.innerHTML = \"incorrect\";" +
                            //"document.getElementById(\"CheckLabel\").innerHTML = \"Hello\";" +
                        "} </script>";

                

                return code;
            }

            return parse;
            
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

        public void incrementStep()
        {
            this.current_step++;
        }

        public void decrementStep()
        {
            this.current_step--;

        }
    }
}