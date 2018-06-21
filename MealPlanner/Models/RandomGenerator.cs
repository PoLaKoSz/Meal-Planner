using System;

namespace MealPlanner.Models
{
    public class RandomGenerator : IRandomGenerator
    {
        private static Random Random { get; set; }



        public RandomGenerator()
        {
            Random = new Random();
        }



        /// <inheritdoc/>
        public int Next(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }
    }
}
