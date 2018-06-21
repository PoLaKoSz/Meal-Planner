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


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Meal anotherMeal = (Meal)obj;

            if (!Name.Equals(anotherMeal.Name))
                return false;

            if (Ingredients != anotherMeal.Ingredients)
                return false;

            return true;
        }
    }
}
