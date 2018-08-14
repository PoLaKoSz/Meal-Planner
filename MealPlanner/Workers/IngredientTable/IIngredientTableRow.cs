using System;

namespace MealPlanner.Workers.IngredientTable
{
    public interface IIngredientTableRow
    {
        int RowIndex { get; }


        void Synchronize(IIngredientTableCell cell);
    }
}