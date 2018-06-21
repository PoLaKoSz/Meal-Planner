using MealPlanner.Models;
using System.Collections.Generic;

namespace MealPlanner.Workers
{
    public class ShoppingListGenerator
    {
        public List<FoodIngredient> Ingredients { get; private set; }



        public ShoppingListGenerator()
        {
            Ingredients = new List<FoodIngredient>();
        }



        public void AddMenu(List<Day> days)
        {
            foreach (Day day in days)
            {
                foreach (RepastForMenu repast in day.Repasts)
                {
                    foreach (FoodIngredient ingredient in repast.Meal.Ingredients)
                    {
                        int index = Ingredients.FindIndex(i => i.Name.Equals(ingredient.Name));

                        if (index == -1)
                            Ingredients.Add(ingredient);
                        else
                            Ingredients[index].Quantity += ingredient.Quantity;
                    }
                }
            }
        }
    }
}
