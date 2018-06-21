using System;

namespace MealPlanner.Models
{
    public interface IMealEqualComparer
    {
        /// <summary>
        /// Definition how to determinate if two <see cref="Meal"/> is equal
        /// </summary>
        /// <param name="firstMeal"></param>
        /// <param name="secondMeal"></param>
        /// <returns>TRUE if equal</returns>
        bool AreEqual(MealForMenu firstMeal, MealForMenu secondMeal);
    }
}
