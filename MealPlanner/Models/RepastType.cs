using System;

namespace MealPlanner.Models
{
    public class RepastType
    {
        public string Name { get; }
        public bool IsCheched { get; set; }



        public RepastType(string repastName)
        {
            Name = repastName;
            IsCheched = false;
        }
    }
}
