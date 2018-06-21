using Newtonsoft.Json;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class MealForMenu
    {

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public List<FoodIngredient> Ingredients { get; private set; }



        public MealForMenu(string mealName, List<FoodIngredient> mealIngredients)
        {
            Name = mealName;
            Ingredients = mealIngredients;
        }
    }
}
