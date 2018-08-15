using System;

namespace MealPlanner.Models
{
    public class FoodIngredient : Ingredient, IFoodIngredient
    {
        public int Quantity { get; set; }
        public string QuantityName { get; set; }



        public FoodIngredient(int quantity, string quantityName, string name)
            : base(name)
        {
            Quantity = quantity;
            QuantityName = quantityName;
        }
        public FoodIngredient(int id, int quantity, string quantityName, string name)
            : this(quantity, quantityName, name)
        {
            SetID(id);
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
