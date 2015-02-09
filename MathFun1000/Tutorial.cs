using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 {
    public class Tutorial {

        public String[] step;
        public String[] example;
        public String[] rule;
        public int difficulty = 1;
        public int number_of_steps = 5;

        //Basic Constructor
        public Tutorial() {
            this.number_of_steps = 5;
            this.difficulty = 1;
            this.step = new String[] {"Identify the different variables.", 
                "Separate the variables into like groups.", 
                "Combine the like terms.", 
                "Recombine the terms after removing the parenthese to make an equation in its seimplets form. Since the variables are differnt, this is the simplest form.", 
                "Solution"};
            this.example = new String[] {"(2x^2y -3xy) + (6x^2y-9xy)", 
                "(2x^2y+6x^2y) + (-3xy-9xy)", 
                "(8x2y) + (-12xy)", 
                "8x^2y-12xy", 
                "8x^2y-12xy"};
            this.rule = new String[] {"Rule Here", 
                "Rule Here", 
                "Rule Here", 
                "Rule Here", 
                "Rule Here"};
        }

        public Tutorial(String[] step, String[] example, String[] rule, int difficulty, int number_of_steps){
            this.step = step;
            this.example = example;
            this.rule = rule;
            this.difficulty = difficulty;
            this.number_of_steps = number_of_steps;
        }

        
    }
}