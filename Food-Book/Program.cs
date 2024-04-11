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
            Recipe recipe=AddRecipe();
            DisplayRecipe(recipe, 1);

            Console.WriteLine("To Restart the recipe type R or to ReScale the recipe type S");
            string input = Console.ReadLine();
            
            while(input =="R" || input == "r")
            {
                recipe = AddRecipe();
                DisplayRecipe(recipe, 1);

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
                    DisplayRecipe(recipe, 0.5);
                }
                else if (input2 == "2")
                {
                    DisplayRecipe(recipe, 2);
                }
                else if (input2 == "3")
                {
                    DisplayRecipe(recipe, 3);
                }
                else
                {
                    DisplayRecipe(recipe, 1);
                }
            }
            Console.ReadKey();
        }

        static Recipe AddRecipe()
        {
            Console.WriteLine("-----");
            Recipe recipe = new Recipe();

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
                Ingredient ingred = AddIngredient(i+1);
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
                Step step = AddSteps(j+1);
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
            step.instruction= thestep;
            Console.WriteLine("----");
            return step;
        }

        static void DisplayRecipe(Recipe recipe,int x)
        {
            Console.WriteLine($"**************************************************\n" +
                $"Recipe name: {recipe.Name}\n" +
                $"Number of Ingredients:    {recipe.ingediants.Count}\n" +
                $"Number of Steps:          {recipe.steps.Count}\n"+
                "\t\tINGREDIENTS\t\t\n" +
                "-----------------------");

            foreach (var ing in recipe.ingediants)
            {
                Console.WriteLine(
                    $"Name:                 {ing.name}\n" +
                    $"Unit of Measurement:  {ing.UOM}\n" +
                    $"Quantity:             {ing.Quantity*x}\n" +
                    $"----");
            }
            Console.WriteLine("\t\tSTEPS\t\t\n" +
                              "--------------");
            foreach (var step in recipe.steps)
            {
                Console.WriteLine($"Step {step.step}\n" +
                    $"{step.instruction}\n" +
                    $"--");
            }
        }
        static void DisplayRecipe(Recipe recipe, double x)
        {
            Console.WriteLine($"**************************************************\n" +
                $"Recipe name: {recipe.Name}\n" +
                $"Number of Ingredients:    {recipe.ingediants.Count}\n" +
                $"Number of Steps:          {recipe.steps.Count}\n" +
                "       INGREDIENTS     \n" +
                "-----------------------");

            foreach (var ing in recipe.ingediants)
            {
                Console.WriteLine(
                    $"Name:                 {ing.name}\n" +
                    $"Unit of Measurement:  {ing.UOM}\n" +
                    $"Quantity:             {ing.Quantity * x}\n" +
                    $"----");
            }
            Console.WriteLine("     STEPS   \n" +
                              "--------------");
            foreach (var step in recipe.steps)
            {
                Console.WriteLine($"Step {step.step}\n" +
                    $"{step.instruction}\n" +
                    $"--");
            }
        }

    }
}
