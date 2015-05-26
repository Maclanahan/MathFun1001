/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: Graph.cs
*
* Brief Description: Graph will be a problem type and have a visual
* that will guide the user along graph type problems.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 
{
    public class Graphs
    {
        public int[] xAxis = { -3, -2, -1, 0, 1, 2, 3 };
        public double[] yAxis = {0, 0, 0, 0, 0, 0, 0};
        public int difficulty = 1;
        public int numberOfSteps = 5;
        public int currentStep = 0;
        public int ans = -1;
        public String[] options;
        public String equation = "";

        //Default constructor meant for testing.
        public Graphs()
        {
            this.xAxis = new int[] { -3, -2, -1, 0, 1, 2, 3 };
            this.yAxis = new double[] { 9, 4, 1, 0, 1, 4, 9 };
        }

        //Main constructor 
        public Graphs(String theEquation) 
        {
            this.equation = theEquation;
            findPiecePositions(this.xAxis, this.equation);
            picAnsPos();
        }


        //Start - Get and Sets
        public int[] GetX()
        {
            return this.xAxis;
        }

        public double[] GetY() 
        {
            return this.yAxis;
        }

        public int picAnsPos() 
        {

            Random rnd = new Random();
            ans = rnd.Next(0, 5);
            return ans;
        }

        public string[] getEquationOptions() {            

            this.options = new String[] { "$$\\color{white}{y=x}$$",
                                          "$$\\color{white}{y=x+5}$$",
                                          "$$\\color{white}{y=x^2}$$",
                                          "$$\\color{white}{y=6x^3+4}$$",
                                          "$$\\color{white}{y=3x+5}$$"};
            
            options[ans] = "$$\\color{white}{" + this.equation + "}$$";
            
            return options;
        }

        public int getAnsPos() 
        {
            return this.ans;
        }

        public String GenerateCode() 
        {            
            return null;

        }

        //Finds the positions of individual pieces of a y=mx+b equation (EX: y=2x+4 or y=2x^2+4)        
        public void findPiecePositions(int[] xAxis, String equation) {
            char op = '+';
            int xPos = 0, powPos = 0, m = 1, b = 0, opPos = 0, pow = 1;
            Boolean powered = false;

            for (int index = 2; index < equation.Length; index++) {
                if (equation[index].Equals('x')) {
                    xPos = index;
                }
                if (equation[index].Equals('^')) {
                    powPos = index;
                    powered = true;
                }
                if (equation[index].Equals('+') || equation[index].Equals('-')) {
                    op = equation[index];
                    opPos = index;
                }
            }

            getPieces(xPos, powPos, opPos, m, b, pow, powered, op);
        }

        public void getPieces(int xPos, int powPos, int opPos, int m, int b, int pow, Boolean powered, char op) {
            String temp = "";

            for (int index = 2; index < equation.Length; index++) {
                if (equation[2] != 'x') {
                    temp += equation[index];
                    if (index + 1 == xPos) {
                        m = Convert.ToInt32(temp);
                        temp = "";
                        index += 2;
                    }
                    if (powered == true && index == opPos - 1) {
                        pow = Convert.ToInt32(temp);
                        temp = "";
                        index += 1;
                    }
                    if (index + 1 == equation.Length) {
                        b = Convert.ToInt32(temp);
                    }
                }
                else {
                    temp += equation[index];
                    if (powered == true) {
                        if (index == xPos + 2) {
                            pow = Convert.ToInt32(temp.Substring(2));
                            temp = "";
                        }
                        if (opPos > 0 && index == xPos + 4) {
                            b = Convert.ToInt32(temp.Substring(1));
                            temp = "";
                        }
                    }
                    else if (powered == false && index + 1 == equation.Length) {
                        b = Convert.ToInt32(temp.Substring(2));
                    }
                }
            }//end for
            generatePoints(m, b, pow, op);
        }//end getpieces

        public void generatePoints(int m, int b, int pow, char op) {
            for (int i = 0; i < yAxis.Length; i++) {
                if (op.Equals('+'))
                    yAxis[i] = m * Math.Pow(xAxis[i], pow) + b;
                if (op.Equals('-'))
                    yAxis[i] = m * Math.Pow(xAxis[i], pow) - b;
            }

        }
    }
}