using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class Day
    {
        public List<Repast> Repasts { get; protected set; }
        public DateTime Date { get; protected set; }



        public Day(List<Repast> repasts, int year, int month, int day)
        {
            Repasts = repasts;
            Date = new DateTime(year, month, day);
        }
    }
}
