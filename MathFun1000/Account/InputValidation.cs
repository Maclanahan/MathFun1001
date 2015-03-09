using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000.Account
{
    public class InputValidation
    {
        public static bool ValidateUserName(String input)
        {
            bool pass = true;
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");

            if (positiveIntRegex.IsMatch(input) == false)
            {
                pass = false;
            }

            if (input.Length < 7 || input.Length > 20)
            {
                pass = false;
            }
            return pass;
        }

        public static bool ValidateEmail(String email)
        {
            bool pass = true;
            int index1 = email.IndexOf("@");
            int index2 = email.LastIndexOf("@");

            int num = email.Split('@').Length - 1;
            if (email.Split('@').Length - 1 > 1)
            {
                pass = false;
            }
            if (index1 != index2)
            {
                pass = false;
            }
            if (email.Trim() == "")
            {
                pass = false;
            }
            return pass;
        }

        public static bool ValidatePassword(String p1, String p2)
        {
            bool pass = true;

            if (p1.Equals(p2) == false)
            {
                pass = false;
            }
            return pass;
        }

    }
}