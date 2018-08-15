using MealPlanner.MVVM;
using System;

namespace MealPlanner.Models
{
    public class Ingredient : ObservableObject
    {
        public int ID { get; protected set; }
        public string Name { get; set; }



        public Ingredient(string ingredientName)
            : this(-1, ingredientName) { }
        public Ingredient(int id, string ingredientName)
        {
            ID = id;
            Name = ingredientName;
        }



        /// <summary>
        /// Update the entity ID from the DB
        /// </summary>
        /// <param name="newID">ID in the table</param>
        public void SetID(int newID)
        {
            if (ID != -1)
                throw new ArgumentException($"Entity ID ({ID}) can't be changed because it's not a new entity!");

            ID = newID;
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
