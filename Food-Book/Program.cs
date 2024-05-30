using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Food Book");
            Add add = new Add();
            bool isWorking = true;
            
            Recipe recipe = add.AddRecipe(ref isWorking);
            while (isWorking == true)
            {
                Display.DisplayRecipe(recipe, 1);
            }
            if(isWorking == false)
            {
                Display.DisplayEnd();
            }

            Console.ReadKey();
        }

    }
}
