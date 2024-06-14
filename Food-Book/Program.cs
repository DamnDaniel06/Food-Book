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
                    NewDisplay();
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

        public static void NewDisplay()
        {
            CookBook newBook = new CookBook();
            newBook = Convert.Convert_to_object();

            //if book is empty
            if (newBook == null)
            {
                AnsiConsole.Write(new Markup("CookBook is [red]empty![/]"));
                Console.ReadKey();
            }
            else
            {
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
                string[] newList = rList.ToArray();

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
    
}
