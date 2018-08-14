using MealPlanner.Models;
using System.Collections.Generic;

namespace MealPlanner.Workers
{
    public class MealGenerator
    {
        private IRandomGenerator _random { get; set; }



        /// <summary>
        /// Convert a <see cref="Meal"/> to a <see cref="MealForMenu"/>
        /// </summary>
        /// <param name="randomGenerator">Required when a random <see cref="Ingredient"/> selected</param>
        public MealGenerator(IRandomGenerator randomGenerator)
        {
            _random = randomGenerator;
        }



        /// <summary>
        /// Get one random <see cref="Ingredient"/> from each <see cref="Meal"/> Ingredient row and craft to a <see cref="MealForMenu"/>
        /// </summary>
        /// <param name="baseMeal">It's name will be inherited and one of an <see cref="Ingredient"/> from each row in the Ingredient matrix</param>
        /// <returns></returns>
        public MealForMenu GenerateMeal(Meal baseMeal)
        {
            var mealIngredients = new List<IFoodIngredient>();

            foreach (var row in baseMeal.Ingredients)
            {
                mealIngredients.Add(row.Cells[_random.Next(0, row.Cells.Count)]);
            }

            return new MealForMenu(baseMeal.Name, mealIngredients);
        }
    }
}
