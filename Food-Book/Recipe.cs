using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> ingediants { get; set; }
        public List<Step> steps { get; set; }
    }
}
