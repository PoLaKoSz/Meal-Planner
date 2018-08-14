using System;

namespace MealPlanner.Workers.IngredientTable
{
    public interface IIngredientTableCell
    {
        int ColumnIndex { get; }
    }
}