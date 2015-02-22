using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000
{
    public abstract class IProblemType
    {
        public abstract int getNumberOfSteps();

        public abstract  string getExampleAt(int index);

        public abstract string getStepAt(int index);

        public abstract string getRuleAt(int index);

        public abstract string generateCode(int numOfSteps);
    }
}