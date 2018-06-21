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



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Repast anotherRepast = (Repast)obj;

            if (!Name.Equals(anotherRepast.Name))
                return false;

            if (Meals != anotherRepast.Meals)
                return false;

            return true;
        }
    }
}
