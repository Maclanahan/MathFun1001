/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Fill_In.cs
*
* Brief Description: Fill_In is the fill in the blank question
* for the problem. It will have boxes to fill in your answer
* and check to see if you are correct.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 
{
    public class Fill_In //: IProblemType 
    {
        //public String[] step;
        //public String[] example;
        //public String[] rule;
        //public int difficulty = 1;
        //public int numberOfSteps = 5;
        //public string answerToCurrentStep;
        //public int currentStep = 0;

        ////Default constructor, never used except for testing purposes.
        //public Fill_In() 
        //{
        //    this.difficulty = 2;
        //    this.numberOfSteps = 5;
        //    this.step = new String[] {"Identify the different variables.", 
        //                              "Separate the variables into like groups.",
        //                              "Combine the like terms.",
        //                              "Recombine the terms after removing the parentheses to make an equation in its simplest form. Since the variables are different, this is the simplest form.",
        //                              "Solution"};
        //    /*this.example = new String[]{"<p style=\"color:blue\">(2x<sup>2</sup>y</p> <p style=\"color:red\">-3xy)</p> <p>+</p> <p style=\"color:blue\">(6x<sup>2</sup>y</p><p>-</p><p style=\"color:red\">9xy)</p>", 
        //                                "<p style=\"color:blue\">(2x<sup>2</sup>y+::6::x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-3xy-9xy)</p>",
        //                                "<p style=\"color:blue\">(8x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(::-12::xy)</p>", 
        //                                "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>::-::</p> <p style=\"color:red\">12xy</p>", 
        //                                "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>"};*/
        //    this.example = new String[] {"$$\\color{blue}{(2x^2y}-\\color{red}{3xy)} + \\color{blue}{(6x^2y}-\\color{red}{9xy)}$$",
        //                                  "$$\\color{blue}{(2x^2y}+\\bbox[4px, border:2px solid black]{???}\\ \\color{blue}{x^2y)}+\\color{red}{(-3xy-9xy)}$$",
        //                                  "$$\\color{blue}{(8x^2y)}\\bbox[4px, border:2px solid black]{???}\\color{red}{(xy)}$$",
        //                                  "$$\\color{blue}{8x^2y}\\bbox[4px, border:2px solid black]{???}\\color{red}{12xy}$$",
        //                                  "$$\\color{blue}{8x^2y}-\\color{red}{12xy}$$"};
        //    this.rule = new String[] {"Rule Here",
        //                              "Rule Here",
        //                              "Rule Here",
        //                              "Rule Here",
        //                              "Rule Here"};
        //}

        ////Main Constructor
        //public Fill_In(String[] step, String[] example, String[] rule, int difficulty, int numberOfSteps)
        //{
        //    this.step = step;
        //    this.example = example;
        //    this.rule = rule;
        //    this.difficulty = difficulty;
        //    this.numberOfSteps = numberOfSteps;
        //}

        ////GenerateCode creates the code for the said problem and sents it to MathProgram to then create the HTML code in the site
        //public override string GenerateCode(int numOfSteps)
        //{
        //    string code = "";
        //    if (numOfSteps > -1)
        //        for (int i = 0; i <= numOfSteps; i++)
        //        {
        //            if (i < numberOfSteps)
        //            {
        //                code += "<div class=\"StepContainer\">";

        //                code += "<div class=\"box\"><p>" + GetStepAt(i) + "</p></div>";

        //                if( (i) == numOfSteps)
        //                    code += "<div class=\"box\"><p>" + ParseForInput(GetExampleAt(i)) + "</p></div>";

        //                else
        //                    code += "<div class=\"box\"><p>" + ParseToRemoveColons(GetExampleAt(i)) + "</p></div>";

        //                code += "<div class=\"box\"><p>" + GetRuleAt(i) + "</p></div>";

        //                code += "<div class=\"buttons\">";
        //                code += "</div>";

        //                code += "</div>";
        //            }
        //        }

        //    return code;

        //}

        ////Remove the ::, which indicates the use of a fill in box inside the problem
        //private string ParseToRemoveColons(string parse)
        //{
        //    if (parse.IndexOf("::") >= 0)
        //    {
        //        int first = parse.IndexOf("::");

        //        int last = parse.LastIndexOf("::");

        //        parse = parse.Remove(last, 2);
        //        parse = parse.Remove(first, 2);
        //    }

        //    return parse;
        //}

        ////Places input boxes inside of the code string to then be sent to the website.
        //private string ParseForInput(string parse)
        //{
        //    string code = "";

        //    if (parse.IndexOf("::") >= 0)
        //    {
        //        int first = parse.IndexOf("::");

        //        int last = parse.LastIndexOf("::");
        //        Console.Out.WriteLine((first + 2) - (last - 2));
        //        String answer = parse.Substring(first + 2, (last - 1) - (first + 1));
                
        //        string firstHalf = parse.Substring(0, first);

        //        string secondHalf = parse.Substring(last + 2);

        //        code += firstHalf + " ";

        //        code += "<input class=\"answerBox\" id=\"AnswerBox\" type=\"text\" value=\"\" autoComplete=\"off\"/>";
        //        //code += "<asp:TextBox class=\"answerBox\" ID=\"TextBox1\" runat=\"server\" value=\"HelloWorld\"></asp:TextBox>";
        //        code += " " + secondHalf;

        //        code += "<br/><input class=\"button\" id=\"CheckButton\" type=\"button\" value=\"&#x2713\" onClick=\"checkAnswer()\"/>";
        //        code += "<label for=\"CheckButton\" id=\"CheckLabel\" style=\"display:inline-block\" ></label>";
                
        //        code += "<script> function checkAnswer(){" +
        //                    "var label = document.getElementById('CheckLabel');" +
        //                    "var answer = document.getElementById('AnswerBox').value;" +
        //                    "if(answer == \"" + answer + "\")" +
        //                        "label.innerHTML = \"Correct!\";" +
        //                    "if(answer != \"" + answer + "\")" +
        //                        "label.innerHTML = \"incorrect\";" +
        //                    //"document.getElementById(\"CheckLabel\").innerHTML = \"Hello\";" +
        //                "} </script>";

        //        return code;
        //    }

        //    return parse;
            
        //}

        ////Start - Get and Sets
        //public override int GetNumberOfSteps()
        //{
        //    return numberOfSteps;
        //}

        //public override string GetExampleAt(int index)
        //{
        //    return example[index];
        //}

        //public override string GetStepAt(int index)
        //{
        //    return step[index];
        //}

        //public override string GetRuleAt(int index)
        //{
        //    return rule[index];
        //}

        //public void IncrementStep()
        //{
        //    this.currentStep++;
        //}

        //public void DecrementStep()
        //{
        //    this.currentStep--;

        //}
        //End
    }
}