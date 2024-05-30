using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    internal class Display
    {
        /// <summary>
        /// These are Methods to display the recipe information that the user entered
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="x"></param>
        public static void DisplayRecipe(Recipe recipe, int x)
        {
            Console.WriteLine($"**************************************************\n" +
                $"Recipe name: {recipe.Name}\n" +
                $"Total calories:           {recipe.TotalCalories}"+
                $"Number of Ingredients:    {recipe.ingediants.Count}\n" +
                $"Number of Steps:          {recipe.steps.Count}\n" +
                "\t\tINGREDIENTS\t\t\n" +
                "-----------------------");

            foreach (var ing in recipe.ingediants)
            {
                Console.WriteLine(
                    $"Name:                 {ing.name}\n" +
                    $"Unit of Measurement:  {ing.UOM}\n" +
                    $"Quantity:             {ing.Quantity * x}\n" +
                    $"Calories:             {ing.Calories}"+
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
            Decisions.Decision(recipe);
        }
        public static void DisplayRecipe(Recipe recipe, double x)
        {
            Console.WriteLine($"**************************************************\n" +
                $"Recipe name: {recipe.Name}\n" +
                $"Total calories:           {recipe.TotalCalories}" +
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
                    $"Calories:             {ing.Calories}" +
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
            Decisions.Decision(recipe);
        }

        public static void DisplayEnd()
        {
            Console.WriteLine("...........GOODBYE...........");
        }
    }
}
