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

            Console.WriteLine("Type [W] to write a new recipe or [L] to list the current available recepts");
            string input1 = Console.ReadLine();

            CookBook book = new CookBook();
            book.recipes = new List<Recipe>();

            

            if (input1 == "w" || input1 == "W")
            {
                bool isWorking = true;
                string error = "";
                

                while (isWorking == true)
                {
                    Recipe recipe = Add.AddRecipe(ref isWorking);
                    book.recipes.Add(recipe);
                    //Convering the Book to Json

                    Display.DisplayRecipe(recipe, 1);
                    //Decisions.Decision(recipe);
                }
                if (isWorking == false)
                {
                    Display.DisplayEnd();
                }
            }
            else if (input1 == "L" || input1 == "l")
            {
                //NewDisplay();
            }
            else
            {
                input1 = null;
            }


            Console.ReadKey();
        }

    }
}
