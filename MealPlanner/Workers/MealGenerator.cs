using MealPlanner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MealPlanner.Workers
{    
    public class MealGenerator
    {
        private IRandomGenerator Random { get; set; }



        /// <summary>
        /// Convert a <see cref="Meal"/> to a <see cref="MealForMenu"/>
        /// </summary>
        /// <param name="randomGenerator">Required when a random <see cref="Ingredient"/> selected</param>
        public MealGenerator(IRandomGenerator randomGenerator)
        {
            Random = randomGenerator;
        }



        /// <summary>
        /// Get one random <see cref="Ingredient"/> from each <see cref="Meal"/> Ingredient row and craft to a <see cref="MealForMenu"/>
        /// </summary>
        /// <param name="baseMeal">It's name will be inherited and one of an <see cref="Ingredient"/> from each row in the Ingredient matrix</param>
        /// <returns></returns>
        public MealForMenu GenerateMeal(Meal baseMeal)
        {
            var mealIngredients = new List<FoodIngredient>();

            foreach (ObservableCollection<FoodIngredient> ingredients in baseMeal.Ingredients)
                mealIngredients.Add(ingredients[Random.Next(0, ingredients.Count)]);

            return new MealForMenu(baseMeal.Name, mealIngredients);
        }
    }
}
