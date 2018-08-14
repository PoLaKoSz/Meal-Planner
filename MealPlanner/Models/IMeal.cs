using MealPlanner.Workers.IngredientTable;
using System.Collections.ObjectModel;

namespace MealPlanner.Models
{
    public interface IMeal
    {
        string Name { get; }
        ObservableCollection<IngredientTableRow> Ingredients { get; }
    }
}
