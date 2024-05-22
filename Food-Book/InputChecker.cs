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
        static bool StringChecker(string input)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(input))
            {
                isValid = false;
                throw new ArgumentNullException(nameof(input),"String is null");
            }
            else
            {
                try
                {
                    isValid = true;
                }
                catch (FormatException fx)
                {
                    Console.WriteLine($"...An Error has occured: {fx.Message}");
                    isValid = false;
                }
            }
            return isValid;
        }
        
    }
}
