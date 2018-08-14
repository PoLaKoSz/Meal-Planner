using MealPlanner.MVVM;
using MealPlanner.Workers.IngredientTable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MealPlanner.Models
{
    public class MealWithRepastType : ObservableObject, IMeal
    {
        private IngredientTable _ingredientTable;

        public string Name { get; set; }
        public List<RepastType> RepastTypes { get; set; }
        public ObservableCollection<IngredientTableRow> Ingredients
        {
            get => _ingredientTable.IngredientRows;
            set
            {
                _ingredientTable.IngredientRows = value;
                NotifyPropertyChanged();
            }
        }



        public MealWithRepastType(List<RepastType> mealRepastTypes)
        {
            RepastTypes = mealRepastTypes;
            _ingredientTable = new IngredientTable();
        }
    }
}
