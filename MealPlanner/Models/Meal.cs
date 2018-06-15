using System.Collections.ObjectModel;

namespace MealPlanner.Models
{
    public class Meal
    {
        public string Name { get; set; }
        public ObservableCollection<ObservableCollection<FoodIngredient>> Ingredients { get; set; }



        public Meal()
            : this("", new ObservableCollection<ObservableCollection<FoodIngredient>>())
        {
            Ingredients.Add(new ObservableCollection<FoodIngredient>()
            {
                new FoodIngredient(),
            });
        }
        public Meal(string mealName, ObservableCollection<ObservableCollection<FoodIngredient>> mealIngredients)
        {
            Name = mealName;
            Ingredients = new ObservableCollection<ObservableCollection<FoodIngredient>>(mealIngredients);
        }
    }
}
