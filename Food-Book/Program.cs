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


            CookBook book = new CookBook();
            book.recipes = new List<Recipe>();

            bool isWorking = true;
            string error = "";
            int counter = 0;


            var choice = Choice();
            do
            {
                if (choice == "Write a rescipe")
                {
                    Recipe recipe = Add.AddRecipe(ref isWorking);

                    book.recipes.Add(recipe);
                    //Convering the Book to Json
                    Convert.Convert_to_json(book);

                    Display.DisplayRecipe(recipe, 1);
                    //Decisions.Decision(recipe);
                }

                if (choice == "Read a recipe") {
                    Display.DisplayList();
                }


                choice = Choice();
                counter++;

            } while (choice != "Quit program" && isWorking == true && counter < 2);


            if (choice == "Quit program" || isWorking == false || counter >= 3)
            {
                Display.DisplayEnd();
            }

            Console.ReadKey();
        }
        public static string Choice()
        {
            // Ask for the user's favorite fruit
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What would you like to do?")
                        .PageSize(10)
                        .AddChoices(new[] { "Write a rescipe", "Read a recipe", "Quit program" }));
            return choice;
        }


    }
    
}
