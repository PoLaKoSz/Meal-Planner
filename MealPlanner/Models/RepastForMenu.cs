using Newtonsoft.Json;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class RepastForMenu
    {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public MealForMenu Meal { get; set; }



        public RepastForMenu(string repastName)
            : this(repastName, new MealForMenu("", new List<FoodIngredient>())) { }
        [JsonConstructor]
        public RepastForMenu(string repastName, MealForMenu meal)
        {
            Name = repastName;
            Meal = meal;
        }
    }
}
