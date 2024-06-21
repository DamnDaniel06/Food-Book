using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    internal class InputChecker
    {
        //public static bool StringChecker(string input)
        //{
        //    bool isValid = true;
        //    if (string.IsNullOrEmpty(input))
        //    {
        //        isValid = false;
        //        throw new ArgumentNullException(nameof(input),"String is null. please try again");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            foreach (char c in input)
        //            {
        //                if (!char.IsLetter(c))
        //                    return false;
        //            }
        //            return true;
        //        }
        //        catch (FormatException fx)
        //        {
        //            Console.WriteLine($"...An Error has occured: {fx.Message}");
        //            isValid = false;
        //        }
        //    }
        //    return isValid;
        //}
        public static bool IntChecker(string input)
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(input))
            {
                isValid = false; 
                //throw new ArgumentNullException(nameof(input), "Input is null. Please try again");
            }
            else
            {
                int n;
                isValid = int.TryParse(input, out n);
                if(isValid == false)
                {
                    //throw new ArgumentNullException(nameof(input), "Input is not numeric. Please try again");
                }
            }
            return isValid;
        }

        public static bool IntChecker(int input)
        {
            bool isValid = false;

            if (input>0 && input<500)
            {
                isValid = true;
                //throw new ArgumentNullException(nameof(input), "Input is null. Please try again");
            }
            return isValid;
        }

    }
}
