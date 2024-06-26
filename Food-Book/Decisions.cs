using Spectre.Console;
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

            // Ask the user what they would like to do with this information
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .PageSize(10)
                    .AddChoices(new[] { "ReScale","Remove current recipe", "Add a new recipe", "..." }));

            if(choice != "...")
            {
                if(choice == "ReScale")
                {
                    // Ask the user what they would like to do with this information
                    var input2 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("What would you like to ReScale?")
                            .PageSize(10)
                            .AddChoices(new[] { "Half", "Double", "Triple", "Reset to Original" }));

                    if (input2 == "Half")
                    {
                        Display.DisplayRecipe(recipe, 0.5);
                    }
                    else if (input2 == "Double")
                    {
                        Display.DisplayRecipe(recipe, 2);
                    }
                    else if (input2 == "triple")
                    {
                        Display.DisplayRecipe(recipe, 3);
                    }
                    else
                    {
                        Display.DisplayRecipe(recipe, 1);
                    }
                }
                if (choice =="Remove current recipe")
                {
                    bool conf = Confirmation("Remove the current recipe", recipe);
                    if (conf == true)
                    {
                        Console.Clear();
                        //remove current recipe
                        CookBook newBook = Convert.Convert_to_object();
                        List<Recipe> recipes = newBook.recipes;
                        recipes.Remove(recipe);
                        newBook.recipes = recipes;
                        Convert.Convert_to_json(newBook);

                        //display list without current recipe
                        Display.DisplayList();
                    }
                    else
                    {
                        Decision(recipe);
                    }
                }
                if(choice=="Add a new recipe")
                {
                    Console.Clear();
                    //Add new recipe
                    CookBook book = new CookBook();
                    book.recipes = new List<Recipe>();

                    bool isWorking = true;
                    Recipe recip = Add.AddRecipe(ref isWorking);
                    if (isWorking == false)
                    {
                        Display.DisplayEnd();
                    }
                    book.recipes.Add(recip);
                    //Convering the Book to Json
                    Convert.Convert_to_json(book);

                    Display.DisplayRecipe(recip, 1);
                }

            }
            else
            {
                Console.Clear();
                Display.DisplayList();
            }

        }
        public static bool Confirmation(string input, Recipe recipe)
        {
            // Ask the user to confirm
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Are you sure you want to {input}?")
                    .PageSize(10)
                    .AddChoices(new[] { "No", "Yes" }));

            if (choice == "No")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
