using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            string tCalories = recipe.TotalCalories.ToString();
            var table = new Table().Title(recipe.Name.ToString()).Width(40);

            table.AddColumn(new TableColumn("Description"));
            table.AddColumn(new TableColumn("Values"));
            table.AddRow("Recipe name", recipe.Name);
            table.AddRow("Total calories", recipe.TotalCalories.ToString()) ;
            table.AddRow("Number of Ingredients", recipe.ingediants.Count.ToString());
            table.AddRow("Number of Steps", recipe.steps.Count.ToString());
            
            AnsiConsole.Write(table);

            var ingTable = new Table().Title("Ingredient Information").Width(40);
            ingTable.AddColumn(new TableColumn("Description"));
            ingTable.AddColumn(new TableColumn("Values"));

            foreach (var ing in recipe.ingediants)
            {
                var newQuantity = ing.Quantity * x;
                ingTable.AddRow("Name",ing.name.ToString());
                ingTable.AddRow("Unit of Measurement",ing.UOM.ToString());
                ingTable.AddRow("Quantity", newQuantity.ToString());
                ingTable.AddRow("Calories",ing.Calories.ToString());
            }
            AnsiConsole.Write(ingTable);

            var stepTable = new Table().Title("Steps").Width(40);
            stepTable.AddColumn(new TableColumn("Step"));
            stepTable.AddColumn(new TableColumn("Description"));
            int counter = 1;
            foreach (var step in recipe.steps)
            {
                stepTable.AddRow(counter.ToString(), step.instruction.ToString());
                counter++;
            }
            AnsiConsole.Write(stepTable);
            Decisions.Decision(recipe);
        }
        public static void DisplayRecipe(Recipe recipe, double x)
        {
            var table = new Table().Title(recipe.Name.ToString());

            table.AddColumn(new TableColumn("Description"));
            table.AddColumn(new TableColumn("Values"));
            table.AddRow("Recipe name", recipe.Name);
            table.AddRow("Total calories", recipe.TotalCalories.ToString());
            table.AddRow("Number of Ingredients", recipe.ingediants.Count.ToString());
            table.AddRow("Number of Steps", recipe.steps.Count.ToString());

            AnsiConsole.Write(table);

            var ingTable = new Table().Title("Ingredient Information");
            ingTable.AddColumn(new TableColumn("Description"));
            ingTable.AddColumn(new TableColumn("Values"));

            foreach (var ing in recipe.ingediants)
            {
                var newQuantity = ing.Quantity * x;
                ingTable.AddRow("Name", ing.name.ToString());
                ingTable.AddRow("Unit of Measurement", ing.UOM.ToString());
                ingTable.AddRow("Quantity", newQuantity.ToString());
                ingTable.AddRow("Calories", ing.Calories.ToString());
            }

            var stepTable = new Table().Title("Steps");
            stepTable.AddColumn(new TableColumn("Step"));
            stepTable.AddColumn(new TableColumn("Description"));
            int counter = 1;
            foreach (var step in recipe.steps)
            {
                stepTable.AddRow(counter.ToString(), step.instruction.ToString());
                counter++;
            }
            AnsiConsole.Write(stepTable);
            Decisions.Decision(recipe);
        }

        public static void DisplayList()
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
                List<string> rList = new List<string>();

                foreach (var recps in recipes)
                {
                    name = recps.Name;
                    rList.Add(name);
                    i++;
                }
                rList.Add("..");
                string[] newList = rList.ToArray();

                // Ask for the user's favorite fruit
                var food = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select your favorite recipe?")
                        .PageSize(10)
                        .AddChoices(newList));

                foreach (var recps in recipes)
                {
                    if (recps.Name == food)
                    {
                        Display.DisplayRecipe(recps, 1);
                    }

                }
                if (food == "..")
                {

                }
            }
        }
        public static void DisplayEnd()
        {
            Console.WriteLine("...........GOODBYE...........");
        }
    }
}
