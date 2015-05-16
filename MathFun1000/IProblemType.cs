/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: IProblemType.cs
*
* Brief Description: IProblemType is the abstract class
 * that all problems inherit from.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000
{
    public abstract class IProblemType
    {
        public abstract int GetNumberOfSteps();

        public abstract  string GetExampleAt(int index);

        public abstract string GetStepAt(int index);

        public abstract string GetRuleAt(int index);

        public abstract string GetLinkAt(int index);

        public abstract string GenerateCode(int numOfSteps);
    }
}