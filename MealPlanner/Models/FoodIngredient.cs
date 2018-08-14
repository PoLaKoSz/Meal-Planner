using System;

namespace MealPlanner.Models
{
    public class FoodIngredient : Ingredient, IFoodIngredient
    {
        public int Quantity { get; set; }
        public string QuantityName { get; set; }



        public FoodIngredient()
            : this(0, "", "") { }
        public FoodIngredient(int foodQuantity, string foodQuantityName, string foodName)
            : base(foodName)
        {
            Quantity = foodQuantity;
            QuantityName = foodQuantityName;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            FoodIngredient anotherFoodIngredient = (FoodIngredient)obj;

            if (!Quantity.Equals(anotherFoodIngredient.Quantity))
                return false;

            if (!QuantityName.Equals(anotherFoodIngredient.QuantityName))
                return false;

            return base.Equals(obj);
        }
    }
}
