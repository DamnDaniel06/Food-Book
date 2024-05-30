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
        private int totalCalories;
        public int TotalCalories
        {
            get { return totalCalories; }
            set { totalCalories = CalTotalCalories(ingediants); }
        }
        private int CalTotalCalories(List<Ingredient> ingredient)
        {
            int count = ingredient.Count();

            int TotalCalories = 0;
            foreach (var ingre in ingediants)
            {
                TotalCalories = TotalCalories + ingre.Calories;
            }
            return TotalCalories;
        }

        public int numingre;
        public int Numingre
        {
            get { return numingre; }
            set { numingre = CalTotalIngredient(ingediants); }
        }

        private int CalTotalIngredient(List<Ingredient> ingediants)
        {
            int count = ingediants.Count;
            return count;
        }

        public int numsteps;
        public int Numsteps
        {
            get { return numsteps; }
            set { numsteps = CalTotalSteps(steps); }
        }

        private int CalTotalSteps(List<Step> steps)
        {
            int count = steps.Count;
            return count;
        }
    }
}
