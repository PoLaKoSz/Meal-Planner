using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class Day
    {
        public int ID { get; set; }
        public List<RepastForMenu> Repasts { get; protected set; }
        public DateTime Date { get; protected set; }



        public Day(List<RepastForMenu> repasts, int year, int month, int day)
            : this(repasts, new DateTime(year, month, day)) { }
        [JsonConstructor]
        public Day(List<RepastForMenu> repasts, DateTime date)
        {
            Repasts = repasts;
            Date = date;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Day anotherDay = (Day)obj;

            if (Date != anotherDay.Date)
                return false;

            if (Repasts.Count == 0 && anotherDay.Repasts.Count == 0)
                return true;

            if (Repasts != anotherDay.Repasts)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -132295298;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<RepastForMenu>>.Default.GetHashCode(Repasts);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
