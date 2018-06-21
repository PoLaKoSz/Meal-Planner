using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class MealForMenu
    {
        public string Name { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }



        public MealForMenu(string mealName, List<Ingredient> mealIngredients)
        {
            Name = mealName;
            Ingredients = mealIngredients;
        }
    }
}
