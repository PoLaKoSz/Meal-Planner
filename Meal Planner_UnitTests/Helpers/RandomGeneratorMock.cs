using MealPlanner.Models;

namespace Meal_Planner_UnitTests.Helpers
{
    internal class RandomGeneratorMock : IRandomGenerator
    {
        /// <summary>
        /// Return minValue
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int Next(int minValue, int maxValue)
        {
            return minValue;
        }
    }
}
