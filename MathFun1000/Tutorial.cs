/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Tutorial.cs
*
* Brief Description: Tutorial is a problem type that is meant
* to hold your hand threw the problem there is not fill in
* or answering questions, just learning the problem.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 
{
    public class Tutorial : IProblemType
    {
        public String[] step;
        public String[] example;
        public String[] rule;
        public String[] link;
        public int difficulty = 1;
        public int numberOfSteps = 5;
        public int currentStep = 0;

        //Default constructor, this is only meant for testing purpuses and is not going to be seen in the final project.
        public Tutorial() 
        {
            this.numberOfSteps = 5;
            this.difficulty = 1;
            this.step = new String[] {"Identify the different variables.", 
                "Separate the variables into like groups.", 
                "Combine the like terms.", 
                "Recombine the terms after removing the parenthese to make an equation in its seimplets form. Since the variables are different, this is the simplest form.", 
                "Solution"};

            /*this.example = new String[] {"<p style=\"color:blue\">(2x<sup>2</sup>y</p> <p style=\"color:red\">-3xy)</p> <p>+</p> <p style=\"color:blue\">(6x<sup>2</sup>y</p><p>-</p><p style=\"color:red\">9xy)</p>", 
                                        "<p style=\"color:blue\">(2x<sup>2</sup>y+6x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-3xy-9xy)</p>",
                                        "<p style=\"color:blue\">(8x<sup>2</sup>y)</p> <p>+</p> <p style=\"color:red\">(-12xy)</p>", 
                                        "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>", 
                                        "<p style=\"color:blue\">8x<sup>2</sup>y</p> <p>-</p> <p style=\"color:red\">12xy</p>"};*/
            this.example = new String[] {"$$\\\\color{blue}{(2x^2y}-\\\\color{red}{3xy)}+\\\\color{blue}{(6x^2y}-\\\\color{red}{9xy)}$$",
                                          "$$\\\\color{blue}{(2x^2y+6x^2y)} + \\\\color{red}{(-3xy-9xy)}$$",
                                          "$$\\\\color{blue}{(8x^2y)} + \\\\color{red}{(-12xy)}$$",
                                          "$$\\\\color{blue}{8x^2y} + \\\\color{red}{12xy}$$",
                                          "$$\\\\color{blue}{8x^2y} + \\\\color{red}{12xy}$$"};

            this.rule = new String[] {"Rule Here", 
                "Rule Here", 
                "Rule Here", 
                "Rule Here", 
                "Rule Here"};

            this.link = new String[] {"Link Here", 
                "Link Here", 
                "Link Here", 
                "Link Here", 
                "Link Here"};
        }

        //Main constructor
        public Tutorial(String[] step, String[] example, String[] rule, String[] link, int difficulty, int numberOfSteps)
        {
            this.step = step;
            this.example = example;
            this.rule = rule;
            this.link = link;
            this.difficulty = difficulty;
            this.numberOfSteps = numberOfSteps;
        }

        //Generate code to send to the Mathprogram to then be generated on the website.
        public override string GenerateCode(int numOfSteps)
        {
            string code = "";
            if (numOfSteps > -1)
                for (int i = 0; i <= numOfSteps; i++)
                {
                    if (i < numberOfSteps)
                    {
                        code += "<div class=\"StepContainer\">";

                        code += "<div class=\"box\"><p>" + GetStepAt(i) + "</p></div>";
                        code += "<div class=\"box\"><p>" + GetExampleAt(i) + "</p></div>";
                        code += "<div class=\"box\"><p>" + GetRuleAt(i) + "</p></div>";

                        code += "<div class=\"buttons\">";
                        code += "</div>";

                        code += "</div>";
                    }
                }

            return code;
            
        }

        //Start - Get and Sets
        public void incrementStep()
        {
            this.currentStep++;
        }

        public void decrementStep()
        {
            this.currentStep--;
        }

        public override int GetNumberOfSteps()
        {
            return numberOfSteps;
        }

        public override string GetExampleAt(int index)
        {
            return example[index];
        }

        public override string GetStepAt(int index)
        {
            return step[index];
        }

        public override string GetRuleAt(int index)
        {
            return rule[index];
        }

        public override string GetLinkAt(int index)
        {
            return link[index];
        }
        //End
    }
}