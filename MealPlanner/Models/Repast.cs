using Newtonsoft.Json;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class Repast
    {
        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("meals")]
        public List<Meal> Meals { get; set; }


        
        public Repast(string repastName)
            : this(repastName, new List<Meal>()) { }
        [JsonConstructor]
        public Repast(string repastName, List<Meal> meals)
        {
            Name = repastName;

            if (meals == null) // fix deserialize error
                meals = new List<Meal>();

            Meals = meals;
        }
    }
}
