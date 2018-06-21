using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class RepastForMenu
    {
        public string Name { get; private set; }
        public MealForMenu Meal { get; set; }



        public RepastForMenu(string repastName)
            : this(repastName, new MealForMenu("", new List<Ingredient>())) { }
        public RepastForMenu(string repastName, MealForMenu meal)
        {
            Name = repastName;
            Meal = meal;
        }
    }
}
