using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class Repast
    {
        public string Name { get; protected set; }
        public List<Meal> Meals { get; protected set; }



        public Repast(string repastName, List<Meal> meals)
        {
            Name = repastName;
            Meals = meals;
        }
    }
}
