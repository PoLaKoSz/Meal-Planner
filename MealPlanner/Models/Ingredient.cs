using System;

namespace MealPlanner.Models
{
    public class Ingredient
    {
        public string Name { get; set; }



        public Ingredient(string ingredientName)
        {
            Name = ingredientName;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Ingredient anotheIngredient = (Ingredient)obj;

            if (!Name.Equals(anotheIngredient.Name))
                return false;

            return true;
        }
    }
}
