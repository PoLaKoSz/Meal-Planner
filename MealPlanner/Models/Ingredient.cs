using System;

namespace MealPlanner.Models
{
    public class Ingredient
    {
        public string Name { get; set; }



        public Ingredient(string ingredientName)
        {
            Name = ingredientName;
        }
    }
}
