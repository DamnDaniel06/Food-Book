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

            bool isValid = false;
            int counter = 0;
            Console.WriteLine("Please enter the Name of Recipe");
            string name = Console.ReadLine();
            recipe.Name = name;

            Console.WriteLine("Please enter the number of ingredients");
            string Ingrd = Console.ReadLine();
            int numIngrd = System.Convert.ToInt32(Ingrd);

            Console.WriteLine("\n--------ingredients--------");
            recipe.ingediants = new List<Ingredient>();
            for (int i = 0; i < numIngrd; i++)
            {
                Ingredient ingred = AddIngredient(i + 1);
                recipe.ingediants.Add(ingred);
            }


            Console.WriteLine("How many steps does this recipe require?");
            string steps = Console.ReadLine();
            int numSteps = System.Convert.ToInt32(steps);

            Console.WriteLine("");
            Console.WriteLine("\n--------Steps--------");
            recipe.steps = new List<Step>();
            for (int j = 0; j < numSteps; j++)
            {
                Step step = AddSteps(j + 1);
                recipe.steps.Add(step);
            }

            return recipe;

        }

        static Ingredient AddIngredient(int x)
        {
            Ingredient ingredient = new Ingredient();

            Console.WriteLine($"What is the name of Ingredient No{x}?");
            string name = Console.ReadLine();
            ingredient.name = name;

            Console.WriteLine("What is the Unit of Measurement?");
            string uom = Console.ReadLine();
            ingredient.UOM = uom;

            Console.WriteLine("What is the quantity used");
            int Qnt = System.Convert.ToInt32(Console.ReadLine());
            ingredient.Quantity = Qnt;
            Console.WriteLine("----");

            return ingredient;
        }

        static Step AddSteps(int j)
        {
            Step step = new Step();

            step.step = j;
            Console.WriteLine("Step" + j);
            string thestep = Console.ReadLine();
            step.instruction = thestep;
            Console.WriteLine("----");
            return step;
        }
    }
}
