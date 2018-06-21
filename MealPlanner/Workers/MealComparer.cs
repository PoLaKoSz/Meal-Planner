using MealPlanner.Models;

namespace MealPlanner.Workers
{
    public class MealComparer : IMealEqualComparer
    {
        // <inheritdoc />
        public bool AreEqual(MealForMenu firstMeal, MealForMenu secondMeal)
        {
            return firstMeal.Name.Equals(secondMeal.Name);
        }
    }
}
