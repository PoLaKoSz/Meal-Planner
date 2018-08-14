using MealPlanner.Workers.IngredientTable;
using System.Collections.ObjectModel;

namespace MealPlanner.Models
{
    public class Meal
    {
        public string Name { get; set; }
        public ObservableCollection<IngredientTableRow> Ingredients { get; set; }



        public Meal(string mealName, ObservableCollection<IngredientTableRow> mealIngredients)
        {
            Name = mealName;
            Ingredients = mealIngredients;
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
