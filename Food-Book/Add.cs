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
                    goto Afterloop;
                }
                counter = 0;
                ingredient.name = name;
                //-------------------------------------------------------------------------
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
                    goto Afterloop;
                }
                counter = 0;
                ingredient.UOM = uom;
                //-------------------------------------------------------------------------
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
                    goto Afterloop;
                }
                counter = 0;
                int Qnt = System.Convert.ToInt32(qt);
                ingredient.Quantity = Qnt;
                //-------------------------------------------------------------------------
                Console.WriteLine("How many calories does it have?");
                int Cal = System.Convert.ToInt32(Console.ReadLine());
                ingredient.Quantity = Cal;

                Console.WriteLine("Which food group does it belong to? Type\n" +
                    "\t1 for Strach\n" +
                    "\t2 for Fruits\n" +
                    "\t3 for Vegetables\n" +
                    "\t4 for Grains\n" +
                    "\t5 for Proteins\n" +
                    "\t6 for Fats and Oils ");
                int foodtype = System.Convert.ToInt32(Console.ReadLine());
                switch (foodtype)
                {
                    case 1:
                        ingredient.Food_Group = Ingredient.FoodType.Starches;
                        break;
                    case 2:
                        ingredient.Food_Group = Ingredient.FoodType.Fruits;
                        break;
                    case 3:
                        ingredient.Food_Group = Ingredient.FoodType.Vegetables;
                        break;
                    case 4:
                        ingredient.Food_Group = Ingredient.FoodType.Grains;
                        break;
                    case 5:
                        ingredient.Food_Group = Ingredient.FoodType.Protein;
                        break;
                    case 6:
                        ingredient.Food_Group = Ingredient.FoodType.FatsAndOils;
                        break;
                }
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
                Console.WriteLine("Step" + j);
                string thestep = Console.ReadLine();
                //isValid = InputChecker.StringChecker(thestep);
                //while (isValid == false && counter < 2)
                //{
                //    Console.WriteLine("Please Try again to enter the Unit of Measurement");
                //    isValid = InputChecker.StringChecker(thestep);
                //    counter++;
                //}
                //if (isValid == false)
                //{
                //    isWorking = false;
                //    goto Afterloop;
                //}
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
        public static Recipe AddRecipe(ref bool isWorking)
        {
            Console.WriteLine("-----");
            Recipe recipe = new Recipe();
            //bool isWorking = true;

            if (isWorking == true)
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
                    goto Afterloop;
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
                    goto Afterloop;
                }
                counter = 0;
                int numIngrd = System.Convert.ToInt32(Ingrd);
                
                //-------------------------------------------------------------------------
                Console.WriteLine("\n--------ingredients--------");
                recipe.ingediants = new List<Ingredient>();
                for (int i = 0; i < numIngrd; i++)
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
    }
}
