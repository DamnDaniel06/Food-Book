using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    internal class Decisions
    {
        

        public static void Decision(Recipe recipe)
        {
            Display display = new Display();
            Add add = new Add();
            
            int counter = 0;
            
            Console.WriteLine("To Restart the recipe type R or to ReScale the recipe type S");
            string input = Console.ReadLine();

            while (counter < 2 && (input!="r" || input != "R" || input != "S" || input != "s"))
            {
                Console.WriteLine("To Restart the recipe type R or to ReScale the recipe type S");
                input = Console.ReadLine();
                counter++;
            }
            if (counter == 3)
            {
                //ending
                Console.WriteLine("Thank you and goodbye");
            }
            if (input == "R" || input == "r")
            {
                Confirmation(input, recipe);
            }
            if(input =="s" || input == "S")
            {
                Console.WriteLine("To change the scale of the quantity used to :\n" +
                   "\t0,5(Half)\ttype 0\n" +
                   "\t2(double)\ttype 2\n" +
                   "\t3(triple)\ttype 3\n" +
                   "\tor type 1 to reset to the original scale");
                string input2 = Console.ReadLine();
                if (input2 == "0")
                {
                    Display.DisplayRecipe(recipe, 0.5);
                }
                else if (input2 == "2")
                {
                    Display.DisplayRecipe(recipe, 2);
                }
                else if (input2 == "3")
                {
                    Display.DisplayRecipe(recipe, 3);
                }
                else
                {
                    Display.DisplayRecipe(recipe, 1);
                }
            }
        }
        public static void Confirmation(string input, Recipe recipe)
        {
            Add add = new Add();

            Console.WriteLine("Are you sure? type Y for yes");
            input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                recipe = add.AddRecipe();
                Display.DisplayRecipe(recipe, 1);
            }
            else
            {
                Decision(recipe);
            }
        }
    }
}
