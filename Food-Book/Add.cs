using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    internal class Add
    {
        /// <summary>
        /// The purpose of this class is to add Recipes 
        /// </summary>
        /// <returns></returns>
        public static Recipe AddRecipe(ref bool isWorking)
        {
            Console.WriteLine("-----");
            Recipe recipe = new Recipe();
            //bool isWorking = true;

            if (isWorking == true)
            {
                bool isValid = true;
                int counter = 0;
                //-------------------------------VARIABLES------------------------------
                var name = "";
                var Ingrd = 0;
                var steps = 0;
                //-------------------------------------------------------------------------
                do
                {
                    name = AnsiConsole.Ask<string>("What is the [green]name of the recipe[/]?");
                    isValid = InputChecker.StringChecker(name);
                    counter++;

                } while (isValid == false && counter < 2);

                if (isValid == false)
                {
                    isWorking = false;
                    goto Afterloop;
                }
                recipe.Name = name;

                //-------------------------------------------------------------------------
                counter = 0;
                do
                {
                    Ingrd = AnsiConsole.Ask<int>("How many [green]Ingredients[/] does it have?");
                    isValid = InputChecker.IntChecker(Ingrd);
                    counter++;

                } while (isValid == false && counter < 2);

                if (isValid == false)
                {
                    isWorking = false;
                    goto Afterloop;
                }
                counter = 0;

                //-------------------------------------------------------------------------
                Console.WriteLine("\n--------ingredients--------");
                recipe.ingediants = new List<Ingredient>();
                for (int i = 0; i < Ingrd; i++)
                {
                    Ingredient ingred = AddIngredient(i + 1, ref isWorking);
                    if (isWorking == false)
                    {
                        break;
                    }
                    recipe.ingediants.Add(ingred);
                }
                if (isWorking == false)
                {
                    goto Afterloop;
                }

                //-------------------------------------------------------------------------
                counter = 0;
                do
                {
                    Ingrd = AnsiConsole.Ask<int>("How many [green]steps[/] does this recipe require?");
                    isValid = InputChecker.IntChecker(Ingrd);
                    counter++;

                } while (isValid == false && counter < 2);
                if (isValid == false)
                {
                    isWorking = false;
                    goto Afterloop;
                }
                counter = 0;
                int numSteps = System.Convert.ToInt32(steps);
                //-------------------------------------------------------------------------
                Console.WriteLine("");
                Console.WriteLine("\n--------Steps--------");
                recipe.steps = new List<Step>();
                for (int j = 0; j < numSteps; j++)
                {
                    Step step = AddSteps(j + 1, ref isWorking);
                    if (isWorking == false)
                    {
                        break;
                    }
                    recipe.steps.Add(step);
                }
            }
        Afterloop:

            return recipe;

        }
        ///---------------------------------------------
        public static Recipe AddRecipe()
        {
            Console.WriteLine("-----");
            Recipe recipe = new Recipe();
            bool isWorking = true;

            while (isWorking == true)
            {
                bool isValid = true;
                int counter = 0;

                Console.WriteLine("Please enter the Name of Recipe");
                string name = Console.ReadLine();
                isValid = InputChecker.StringChecker(name);

                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the recipe name");
                    name = Console.ReadLine();
                    isValid = InputChecker.StringChecker(name);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    break;
                }
                else
                {
                    counter = 0;
                    recipe.Name = name;
                }
                //-------------------------------------------------------------------------
                Console.WriteLine("Please enter the number of ingredients");
                string Ingrd = Console.ReadLine();
                isValid = InputChecker.IntChecker(Ingrd);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the number of ingredients");
                    Ingrd = Console.ReadLine();
                    isValid = InputChecker.IntChecker(Ingrd);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    break;
                }
                counter = 0;
                int numIngrd = System.Convert.ToInt32(Ingrd);
                //-------------------------------------------------------------------------
                Console.WriteLine("\n--------ingredients--------");
                recipe.ingediants = new List<Ingredient>();
                for (int i = 0; i < numIngrd; i++)
                {
                    Ingredient ingred = AddIngredient(i + 1,ref isWorking);
                    recipe.ingediants.Add(ingred);
                }

                //-------------------------------------------------------------------------
                Console.WriteLine("How many steps does this recipe require?");
                string steps = Console.ReadLine();
                isValid = InputChecker.IntChecker(steps);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the steps that this recipe require");
                    steps = Console.ReadLine();
                    isValid = InputChecker.IntChecker(steps);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    break;
                }
                counter = 0;
                int numSteps = System.Convert.ToInt32(steps);
                //-------------------------------------------------------------------------
                Console.WriteLine("");
                Console.WriteLine("\n--------Steps--------");
                recipe.steps = new List<Step>();
                for (int j = 0; j < numSteps; j++)
                {
                    Step step = AddSteps(j + 1, ref isWorking);
                    recipe.steps.Add(step);
                }
            }
            return recipe;

        }
        //************************************************************************
        //-----
        //************************************************************************
        static Ingredient AddIngredient(int x, ref bool isWorking)
        {
            int counter = 0;
            bool isValid = true;
            Ingredient ingredient = new Ingredient();

            if (isWorking == true)
            {
                //-----variables
                var name = "";
                var uom = "";
                var Qnt = 0;
                var Cal = 0;
                var foodtype = "";
                //_____________
                do
                {
                    name = AnsiConsole.Ask<string>("What is the name of Ingredient [green]No {x}[/]?");
                    isValid = InputChecker.StringChecker(name);
                    counter++;

                } while (isValid == false && counter < 2);
                if (isValid == false)
                {
                    isWorking = false;
                    goto Afterloop;
                }
                counter = 0;
                ingredient.name = name;
                //-------------------------------------------------------------------------
                counter++;
                uom = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                           .Title("What is the Unit of Measurement?")
                           .PageSize(10)
                           .AddChoices(new[] {
                               "Milligram (mg)",
                               "Gram (g)",
                               "Ounce (oz)",
                               "Pound (lb)",
                               "Millilitre (ml)",
                               "Litre (l)",
                               "Fluid ounce (fl. oz.)",
                               "Gallon (gal)"
                           }));
                ingredient.UOM = uom;
                //-------------------------------------------------------------------------
                do
                {
                    Qnt = AnsiConsole.Ask<int>("What is the [green]quantity[/] used?");
                    isValid = InputChecker.IntChecker(Qnt);
                    counter++;

                } while (isValid == false && counter < 2);
                if (isValid == false)
                {
                    isWorking = false;
                    goto Afterloop;
                }
                counter = 0;
                //int Qnt = System.Convert.ToInt32(qt);
                ingredient.Quantity = Qnt;
                //-------------------------------------------------------------------------
                do
                {
                    Cal = AnsiConsole.Ask<int>("How many [green]calories[/] does it have?");
                    isValid = InputChecker.IntChecker(Cal);
                    counter++;

                } while (isValid == false && counter < 2);
                if (isValid == false)
                {
                    isWorking = false;
                    goto Afterloop;
                }
                counter = 0;
                ingredient.Quantity = Cal;
                //-------------------------------------------------------------------------

                foodtype = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Which food group does it belong to?")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Strach",
                        "Fruits",
                        "Vegetables",
                        "Grains",
                        "Proteins",
                        "Fats and Oils"
                    }));
                ingredient.Food_Group = foodtype;
                Console.WriteLine("----");
            }
        Afterloop:

            return ingredient;
        }
        //************************************************************************
        //-------------------------------ADD CLASS--------------------------------//
        //------------------------------------
        //This method takes 
        //************************************************************************
        static Step AddSteps(int j, ref bool isWorking)
        {
            int counter = 0;
            bool isValid = true;
            Step step = new Step();

            if (isWorking == true)
            {
                step.step = j;
                AnsiConsole.Write($"Step  [red]{j}[/]");
                string thestep = Console.ReadLine();
                //counter = 0;
                step.instruction = thestep;
                Console.WriteLine("----");
            }
        Afterloop:

            return step;
        }
        //-------------------------------------------------------
        //These are overloaded methods of the previous classes. Are used in the Display class
        //---------------------------------------------------------
        
    }
}
