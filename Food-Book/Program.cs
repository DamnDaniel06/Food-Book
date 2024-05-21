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
            Display display = new Display();
            Add add = new Add();

            Recipe recipe = add.AddRecipe();
            display.DisplayRecipe(recipe, 1);

            Decisions decisions = new Decisions();
            decisions.reDecided();
            Console.ReadKey();
        }

    }
}
