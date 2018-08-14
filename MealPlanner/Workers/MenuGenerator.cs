using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MealPlanner.Workers
{
    public class MenuGenerator
    {
        private List<Repast> _inputRepasts { get; set; }


        public ObservableCollection<Day> Days { get; private set; }

        public List<RepastType> RepastTypes { get; set; }



        public MenuGenerator(List<Repast> repasts)
            : this(repasts, new ObservableCollection<Day>()) { }
        public MenuGenerator(List<Repast> repasts, ObservableCollection<Day> days)
        {
            _inputRepasts = repasts ?? throw new ArgumentNullException(nameof(repasts));
            Days = days ?? throw new ArgumentNullException(nameof(days));
            RepastTypes = new List<RepastType>();
        }



        /// <summary>
        /// Remove every day from the menu and generate empty days in the given range
        /// </summary>
        /// <param name="startDate">The first day of the generated menu</param>
        /// <param name="endDate">The last day of the generated menu</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void ChangeDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate == default(DateTime)) throw new ArgumentNullException(nameof(startDate) + " can not be the DateTime default");
            if (endDate == default(DateTime)) throw new ArgumentNullException(nameof(endDate) + " can not be the DateTime default");
            if (endDate.Ticks < startDate.Ticks) throw new ArgumentException(nameof(startDate) + " is bigger than " + nameof(endDate));

            ResetMenu();

            DateTime currentDate = startDate;
            do
            {
                Days.Add(new Day(new List<RepastForMenu>(), currentDate.Year, currentDate.Month, currentDate.Day));

                currentDate = currentDate.AddDays(1);
            } while (currentDate.CompareTo(endDate) <= 0);
        }

        /// <summary>
        /// Remove every day from the menu
        /// </summary>
        public void ResetMenu()
        {
            Days.Clear();
        }

        /// <summary>
        /// Generate the menu accordint to the repetition rate and to the comparer settings
        /// </summary>
        /// <param name="uniquePercent"></param>
        /// <param name="random"></param>
        /// <param name="comparer">This class help to prevent duplicated <see cref="Meal"/>s in a period of time</param>
        /// <returns></returns>
        public ObservableCollection<Day> GenerateMenu(int uniquePercent, IRandomGenerator random, IMealEqualComparer comparer)
        {
            for (int d = 0; d < Days.Count; d++)
            {
                for (int r = 0; r < RepastTypes.Count; r++)
                {
                    if (RepastTypes[r].IsCheched)
                    {
                        var repastGenerator = new RepastGenerator(RepastTypes[r], _inputRepasts);
                        
                        repastGenerator.CollectPreviousMeals(Days, 0, 0);

                        Days[d].Repasts.Add(repastGenerator.GenerateRepast(uniquePercent, random, comparer));
                    }
                }
            }

            return Days;
        }
    }
}
