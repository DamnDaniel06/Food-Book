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
        public Recipe AddRecipe()
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
                



                Console.WriteLine("Please enter the number of ingredients");
                string Ingrd = Console.ReadLine();
                isValid = InputChecker.IntChecker(Ingrd);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the number of ingredients");
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

                Console.WriteLine("\n--------ingredients--------");
                recipe.ingediants = new List<Ingredient>();
                for (int i = 0; i < numIngrd; i++)
                {
                    Ingredient ingred = AddIngredient(i + 1,ref isWorking);
                    recipe.ingediants.Add(ingred);
                }


                Console.WriteLine("How many steps does this recipe require?");
                string steps = Console.ReadLine();
                isValid = InputChecker.IntChecker(steps);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the steps that this recipe require");
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

        static Ingredient AddIngredient(int x, ref bool isWorking)
        {
            int counter = 0;
            bool isValid = false;
            bool isChecked = true;
            Ingredient ingredient = new Ingredient();

            while (isChecked == true)
            {
                Console.WriteLine($"What is the name of Ingredient No{x}?");
                string name = Console.ReadLine();
                isValid = InputChecker.StringChecker(name);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the recipe name");
                    isValid = InputChecker.StringChecker(name);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    isChecked = false;
                    break;
                }
                counter = 0;
                ingredient.name = name;

                Console.WriteLine("What is the Unit of Measurement?");
                string uom = Console.ReadLine();
                isValid = InputChecker.StringChecker(uom);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the Unit of Measurement");
                    isValid = InputChecker.StringChecker(uom);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    isChecked = false;
                    break;
                }
                counter = 0;
                ingredient.UOM = uom;

                Console.WriteLine("What is the quantity used");
                string qt = Console.ReadLine();
                isValid = InputChecker.IntChecker(qt);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the quantity used");
                    isValid = InputChecker.IntChecker(qt);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    isChecked = false;
                    break;
                }
                counter = 0;
                int Qnt = System.Convert.ToInt32(qt);
                ingredient.Quantity = Qnt;
                Console.WriteLine("----");
            }
            return ingredient;
        }

        static Step AddSteps(int j, ref bool isWorking)
        {
            int counter = 0;
            bool isValid = false;
            bool isChecked = true;
            Step step = new Step();

            while (isChecked == true)
            {
                step.step = j;
                Console.WriteLine("Step" + j);
                string thestep = Console.ReadLine();
                isValid = InputChecker.StringChecker(thestep);
                while (isValid == false && counter < 2)
                {
                    Console.WriteLine("Please Try again to enter the Unit of Measurement");
                    isValid = InputChecker.StringChecker(thestep);
                    counter++;
                }
                if (isValid == false)
                {
                    isWorking = false;
                    isChecked = false;
                    break;
                }
                counter = 0;
                step.instruction = thestep;
                Console.WriteLine("----");
            }
            return step;
        }
    }
}
