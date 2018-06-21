using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class MealWithRepastType : Meal
    {
        public List<RepastType> RepastTypes { get; set; }



        public MealWithRepastType(List<RepastType> mealRepastTypes)
        {
            RepastTypes = mealRepastTypes;
        }
    }
}
