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
        public double[] yAxis = new double[7];
        public int difficulty = 1;
        public int numberOfSteps = 5;
        public int currentStep = 0;
        public String equation = "";

        //Default constructor meant for testing.
        public Graphs()
        {
            this.numberOfSteps = 1;
            this.xAxis = new int[] { -3, -2, -1, 0, 1, 2, 3 };
            this.yAxis = new double[] { 9, 4, 1, 0, 1, 4, 9 };
        }

        //Main constructor 
        public Graphs(String theEquation) 
        {
            this.equation = theEquation;
            generatePoints(this.equation);
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

        //Gets the positions of individual pieces of a y=mx+b equation (EX: y=2x+4 or y=2x^2+4)
        
        public void generatePoints(String equation){
            char op = '+';
            int[]  x = { -3, -2, -1, 0, 1, 2, 3 };
            int xPos = 0, powPos = 0, m = 1, b = 0, pow = 1;
                       
            for (int index = 2; index < equation.Length; index++) {
                if (equation[index].Equals('x')){
                    xPos = index;
                    if(index > 2)
                        m = getM(xPos, equation);                
                }
                if (equation[index].Equals('^')){
                    powPos = index;
                    pow = getPow(powPos, equation);
                }
                if(equation[index].Equals('+') || equation[index].Equals('-') || 
                equation[index].Equals('*') || equation[index].Equals('/')){
                    op = equation[index];
                    b = getB(index + 1, equation);
                }              
            }

            for(int i = 0; i < 7; i ++){
                if (op.Equals('+'))
                    yAxis[i] = m * Math.Pow(x[i], pow) + b;
                if(op.Equals('-'))
                    yAxis[i] = m * Math.Pow(x[i], pow) - b;
                if(op.Equals('*'))
                    yAxis[i] = m * Math.Pow(x[i], pow) * b;
                if(op.Equals('/'))    
                    yAxis[i] = m * Math.Pow(x[i], pow) / b;
            }
        }

        public static int getM(int xPos, String equation) {

            String temp = "";
            int m = 0;
            for (int index = 2; index < xPos; index++) {
                temp += equation[index];
            }
            m = Convert.ToInt32(temp);
            return m;
        }
        public static int getPow(int powPos, String equation) {

            String temp = "";
            int pow = 1;
            for (int index = powPos + 1;
                index < equation.Length && (!(equation[index].Equals('+')) && !(equation[index].Equals('-')) &&
                !(equation[index].Equals('*')) && !(equation[index].Equals('/'))); index++) {
                temp += equation[index];
            }
            pow = Convert.ToInt32(temp);
            return pow;
        }
        public static int getB(int index, String equation) {
            String temp = "";
            int b = 0;
            for (int i = index; i < equation.Length; i++)
                temp += equation[index];

            b = Convert.ToInt32(temp);
            return b;
        }
    }
}