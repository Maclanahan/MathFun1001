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
        public int number_of_steps = 5;
        public int current_step = 0;

        public Graphs()
        {
            this.number_of_steps = 1;
            this.xAxis = new int[] { -3, -2, -1, 0, 1, 2, 3 };
            this.yAxis = new int[] { 9, 4, 1, 0, 1, 4, 9 };
        }

        public Graphs(int[] X, int[] Y, int numberOfSteps) 
        {
            this.number_of_steps = numberOfSteps;
            this.xAxis = X;
            this.yAxis = Y;
        }

        public int[] getX()
        {
            return this.xAxis;
        }

        public int[] getY() 
        {
            return this.yAxis;
        }

        public int getNumberOfSteps() 
        {
            return number_of_steps;
        }

    }
}