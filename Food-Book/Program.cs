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
            Add add = new Add();
            bool end = false;
            
            Recipe recipe = add.AddRecipe();
            while (end == false)
            {
                Display.DisplayRecipe(recipe, 1);
            }
            if(end == true)
            {
                Display.DisplayEnd();
            }

            Console.ReadKey();
        }

    }
}
