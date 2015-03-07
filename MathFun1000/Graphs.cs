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
        public int[] xAxis;
        public int[] yAxis;
        public int difficulty = 1;
        public int numberOfSteps = 5;
        public int currentStep = 0;

        //Default constructor meant for testing.
        public Graphs()
        {
            this.numberOfSteps = 1;
            this.xAxis = new int[] { -3, -2, -1, 0, 1, 2, 3 };
            this.yAxis = new int[] { 9, 4, 1, 0, 1, 4, 9 };
        }

        //Main constructor 
        public Graphs(int[] X, int[] Y, int numberOfSteps) 
        {
            this.numberOfSteps = numberOfSteps;
            this.xAxis = X;
            this.yAxis = Y;
        }


        //Start - Get and Sets
        public int[] GetX()
        {
            return this.xAxis;
        }

        public int[] GetY() 
        {
            return this.yAxis;
        }

        public int GetNumberOfSteps() 
        {
            return numberOfSteps;
        }
        //End

    }
}