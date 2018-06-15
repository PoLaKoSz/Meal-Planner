using System;

namespace MealPlanner.Models
{
    public class FoodIngredient : Ingredient
    {
        public double Quantity { get; set; }
        public string QuantityName { get; set; }



        public FoodIngredient()
            : this(0, "", "") { }
        public FoodIngredient(double foodQuantity, string foodQuantityName, string foodName)
            : base(foodName)
        {
            Quantity = foodQuantity;
            QuantityName = foodQuantityName;
        }
    }
}
