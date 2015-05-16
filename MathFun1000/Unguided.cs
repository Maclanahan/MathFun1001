/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Unguided.cs
*
* Brief Description: Unguided is a problem type that ask the
* user to put in the end solution without any help.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 
{
    public class Unguided //: IProblemType
    {
        //public String[] step;
        //public String[] example;
        //public String[] rule;
        //public int difficulty = 1;
        //public int numberOfSteps = 5;
        //public int currentStep = 0;

        ////Default constructor, this is used for testing and will not be viewed in the final product
        //public Unguided() 
        //{
        //    this.numberOfSteps = 2;
        //    this.difficulty = 1;
        //    this.step = new String[] {"Identify the different variables.", 
        //        "Separate the variables into like groups.", 
        //        "Combine the like terms.", 
        //        "boxed Recombine the terms after removing the parenthese to make an equation in its seimplets form. Since the variables are differnt, this is the simplest form.", 
        //        "Solution"};
        //    /*this.example = new String[] {"<p style=\"color:blue\">(2x<sup>2</sup>y</p> <p style=\"color:red\">-3xy)</p> <p>+</p> <p style=\"color:blue\">(6x<sup>2</sup>y</p><p>-</p><p style=\"color:red\">9xy)</p>", 
        //                                "<p style=\"color:blue\">(2x<sup>2</sup>y+6x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-3xy-9xy)</p>",
        //                                "<p style=\"color:blue\">(8x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-12xy)</p>", 
        //                                "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>", 
        //                                "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>"};*/
        //    this.example = new String[] {"$$\\color{blue}{(2x^2y}-\\color{red}{3xy)}+\\color{blue}{(6x^2y}-\\color{red}{9xy)}$$",
        //                                  "$$\\color{blue}{(2x^2y+6x^2y)} + \\color{red}{(-3xy-9xy)}$$",
        //                                  "$$\\color{blue}{(8x^2y)} + \\color{red}{(-12xy)}$$",
        //                                  "$$\\color{blue}{8x^2y} + \\color{red}{12xy}$$",
        //                                  "$$\\color{blue}{8x^2y} + \\color{red}{12xy}$$"};
        //    this.rule = new String[] {"Rule Here", 
        //        "Rule Here", 
        //        "Rule Here", 
        //        "Rule Here", 
        //        "Rule Here"};
        //}

        ////Main constructor
        //public Unguided(String[] step, String[] example, String[] rule, int difficulty, int numberOfSteps) 
        //{
        //    this.step = step;
        //    this.example = example;
        //    this.rule = rule;
        //    this.difficulty = difficulty;
        //    this.numberOfSteps = numberOfSteps;
        //}

        ////Generate code, this is to create the boxes and input boxes necessary to create the unguided problem 
        ////then this code is sent to Math Program to be put on the website
        //public override string GenerateCode(int numOfSteps)
        //{
        //    string code = "";
        //    if (numOfSteps > -1)
        //    { 
        //        code += "<div class=\"StepContainer\">";

        //        if (numOfSteps == 0)
        //        {
        //            code += "<div class=\"box\"><p>" + GetStepAt(0) + "</p></div>";
        //            code += "<div class=\"box\"><p>" + SetUpInput(GetExampleAt(0)) + "</p></div>";
        //            code += "<div class=\"box\"><p>" + GetRuleAt(0) + "</p></div>";
        //        }
        //        else
        //        {
        //            code += "<div class=\"box\"><p>" + GetStepAt(step.Length - 1) + "</p></div>";
        //            code += "<div class=\"box\"><p>" + RemoveColons(GetExampleAt(example.Length - 1)) + "</p></div>";
        //            code += "<div class=\"box\"><p>" + GetRuleAt(rule.Length - 1) + "</p></div>";
        //        }
                  
        //        code += "<div class=\"buttons\">";
        //        code += "</div>";
        //        code += "</div>";
        //     }

        //    return code;
        //}

        ////Description
        //private string ParseToRemoveTags(string parse)
        //{
        //    parse = RemoveColons(parse);
        //    parse.Trim();

        //    while(parse.Contains("<") && parse.Contains(">"))
        //    {
        //        int first = parse.IndexOf("<");

        //        int last = parse.IndexOf(">");

        //        int final = last - first + 1;

        //        parse = parse.Remove(first, final);
        //    }

        //    while(parse.Contains(" "))
        //    {
        //        parse = parse.Remove(parse.IndexOf(" "), 1);
        //    }

        //    return parse;
        //}

        ////Remove colons from the string, as colons indicate were to place input boxes
        //private string RemoveColons(string parse)
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

        ////Create the code needed to place check answer box into the website.
        //private string SetUpInput(string parse)
        //{
        //    string code = "";
        //    string answer = ParseToRemoveTags(GetExampleAt(example.Length - 1));

        //    code += RemoveColons(parse);

        //    code += "<br/><input class=\"unguidedBox\" id=\"AnswerBox\" type=\"text\" value=\"\" autoComplete=\"off\"/>";
        //    code += "<br/><input class=\"button\" id=\"CheckButton\" type=\"button\" value=\"&#x2713\" onClick=\"checkAnswer()\"/>";
        //    code += "<label for=\"CheckButton\" id=\"CheckLabel\" style=\"display:inline-block\" ></label>"; 

        //    code += "<script> function checkAnswer(){" +
        //                "var label = document.getElementById('CheckLabel');" +
        //                "var answer = document.getElementById('AnswerBox').value;" +
        //                " answer = answer.replace(/\\s/g, \"\");" +
        //                "if(answer == \"" + answer + "\")" +
        //                    "label.innerHTML = \"Correct!\";" +
        //                "if(answer != \"" + answer + "\")" +
        //                    "label.innerHTML = \"incorrect\";" +
        //            "} </script>";



        //    return code; 
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

        //public override string GetLinkAt(int index)
        //{
        //    return link[index];
        //}
        //End
    }
}