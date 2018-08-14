using System;

namespace MealPlanner.Models
{
    public interface IFoodIngredient
    {
        string Name { get; }
        int Quantity { get; }
        string QuantityName { get; }
    }
}
