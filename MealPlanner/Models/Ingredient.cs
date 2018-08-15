using MealPlanner.MVVM;

namespace MealPlanner.Models
{
    public class Ingredient : ObservableObject
    {
        public int ID { get; }
        public string Name { get; set; }



        public Ingredient(int id, string ingredientName)
        {
            ID = id;
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
