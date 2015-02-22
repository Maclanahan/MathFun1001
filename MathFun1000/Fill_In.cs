using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 {
    public class Fill_In {
        public String[] step;
        public String[] example;
        public String[] rule;
        public int difficulty = 1;
        public int number_of_steps = 5;
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
            this.example = new String[]{"(2__ - 3__) + (6___ - 9__) ", 
                "(2__ + 6__) + (-3__ - 9__) ",
                "(8__) + (-12__)", 
                "8__ - 12__", 
                "8__ - 12__"};
            this.rule = new String[] {"Rule Here!",
                "Rule Here!",
                "Rule Here!",
                "Rule Here!",
                "Rule Here!"};
        }

        public Fill_In(String[] step, String[] example, String[] rule, int difficulty, int number_of_steps)
        {
            this.step = step;
            this.example = example;
            this.rule = rule;
            this.difficulty = difficulty;
            this.number_of_steps = number_of_steps;
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