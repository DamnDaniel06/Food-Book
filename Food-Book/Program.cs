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
            Display display = new Display();
            Add add = new Add();

            Recipe recipe=add.AddRecipe();
            display.DisplayRecipe(recipe, 1);

            Console.WriteLine("To Restart the recipe type R or to ReScale the recipe type S");
            string input = Console.ReadLine();
            
            while(input =="R" || input == "r")
            {
                recipe = add.AddRecipe();
                display.DisplayRecipe(recipe, 1);

                Console.WriteLine("To Restart the recipe type R or to ReScale the recipe type S");
            }
            if(input == "S" || input == "s")
            {
                Console.WriteLine("To change the scale of the quantity used to :\n" +
                    "\t0,5(Half)\ttype 0\n" +
                    "\t2(double)\ttype 2\n" +
                    "\t3(triple)\ttype 3\n" +
                    "\tor type 1 to reset to the original scale");
                string input2 = Console.ReadLine();
                if(input2 == "0")
                {
                    display.DisplayRecipe(recipe, 0.5);
                }
                else if (input2 == "2")
                {
                    display.DisplayRecipe(recipe, 2);
                }
                else if (input2 == "3")
                {
                    display.DisplayRecipe(recipe, 3);
                }
                else
                {
                    display.DisplayRecipe(recipe, 1);
                }
            }
            Console.ReadKey();
        }

    }
}
