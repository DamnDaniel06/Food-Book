using Spectre.Console;
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
                    Convert.Convert_to_json(book);

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
                NewDisplay();
            }
            else
            {
                input1 = null;
            }


            Console.ReadKey();
        }
        public static void NewDisplay()
        {
            CookBook newBook = new CookBook();
            newBook = Convert.Convert_to_object();

            List<Recipe> recipes = new List<Recipe>();
            recipes = newBook.recipes;
            recipes.Sort();
            int num = recipes.Count;
            int i = 1;
            

            string name;
            string tCalories;
            string display;
            //string[] rList = new string[num];
            List<string> rList = new List<string>();

            foreach (var recps in recipes)
            {
                name = recps.Name;
                //tCalories = recps.TotalCalories.ToString();
                //display = name + " " + tCalories + " calories";
                rList.Add(name);
                //Console.WriteLine($"{i} {recps.Name} ( {recps.TotalCalories} calories)");
                i++;

            }
            string[] newList =rList.ToArray();

            // Ask for the user's favorite fruit
            var food = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select your favorite recipe?")
                    .PageSize(10)
                    .AddChoices(newList));

            foreach (var recps in recipes)
            {
                name = recps.Name;
                rList.Add(name);
                if (recps.Name == food)
                {
                    Display.DisplayRecipe(recps, 1);
                }

            }

        }

    }
    
}
