using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000 {
    public class Unguided {
        public int difficulty = 3;
        public String[] problem;

        public Unguided() {
            this.problem = new String[] { "(2x2y -3xy) + (6x2y-9xy)" };
        }
        public Unguided(String[] problem) {
            this.problem = problem;
        }
    }
}