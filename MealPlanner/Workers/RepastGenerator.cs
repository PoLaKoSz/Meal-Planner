using MealPlanner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MealPlanner.Workers
{
    /// <summary>
    /// The class resposible to genereate a <see cref="RepastForMenu"/>
    /// </summary>
    public class RepastGenerator
    {
        private RepastForMenu GeneratedRepast { get; set; }
        private RepastType RepastType { get; set; }
        private List<MealForMenu> PreviousMeals { get; set; }
        private List<Meal> AvailableMeals { get; set; }



        public RepastGenerator(RepastType repastType, List<Repast> availableRepasts)
            : this(repastType, new RepastForMenu(repastType.Name), availableRepasts) { }
        public RepastGenerator(RepastType repastType, RepastForMenu outputRepast, List<Repast> availableRepasts)
        {
            RepastType = repastType;
            GeneratedRepast = outputRepast;
            AvailableMeals = availableRepasts[GetTypeIndex(RepastType, availableRepasts)].Meals;
        }



        public void CollectPreviousMeals(ObservableCollection<Day> days, int startIndex, int length)
        {
            PreviousMeals = new List<MealForMenu>();

            for (int d = startIndex; ((d < startIndex + length) && d < days.Count); d++)
            {
                foreach (RepastForMenu repast in days[d].Repasts)
                {
                    if (repast.Name.Equals(RepastType.Name))
                    {
                        PreviousMeals.Add(repast.Meal);
                        break;
                    }
                }
            }
        }

        public int GetTypeIndex(RepastType repastType, List<Repast> repastCollection)
        {
            for (int i = 0; i < repastCollection.Count; i++)
            {
                if (repastType.Name.Equals(repastCollection[i].Name))
                    return i;
            }

            return -1;
        }

        public RepastForMenu GenerateRepast(int uniquePercent, IRandomGenerator random, IMealEqualComparer comparer)
        {
            int uniqueCount = GetUniqueCount(uniquePercent, AvailableMeals);

            var mealGenerator = new MealGenerator(random);

            MealForMenu generatedMenu = mealGenerator.GenerateMeal(AvailableMeals[random.Next(0, AvailableMeals.Count)]);
            
            for (int i = PreviousMeals.Count - 1; 0 <= i; i++)
            {
                if (comparer.AreEqual(PreviousMeals[i], generatedMenu))
                {
                    generatedMenu = mealGenerator.GenerateMeal(AvailableMeals[random.Next(0, AvailableMeals.Count)]);
                    i = PreviousMeals.Count - 1;
                }
            }            

            GeneratedRepast.Meal = generatedMenu;

            return GeneratedRepast;
        }

        public int GetUniqueCount(int uniquePercent, List<Meal> collection)
        {
            return collection.Count* uniquePercent / 100;
        }
    }
}
