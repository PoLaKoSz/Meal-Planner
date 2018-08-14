using MealPlanner.Workers.IngredientTable;

namespace Meal_Planner_UnitTests.Helpers
{
    internal class FakeIngredientTableRow : IIngredientTableRow
    {
        /// <summary>
        /// <c>-1</c> if no <see cref="IIngredientTableCell"/> signaled to
        /// this row, or contains the last signaled
        /// <see cref="IIngredientTableCell"/> ColumnIndex
        /// </summary>
        public int SignaledCellIndex { get; private set; }
        
        /// <summary>
        /// This will allways return 0
        /// </summary>
        public int RowIndex { get; }



        public FakeIngredientTableRow()
        {
            SignaledCellIndex = -1;
            RowIndex = 0;
        }



        public void Synchronize(IIngredientTableCell cell)
        {
            SignaledCellIndex = cell.ColumnIndex;
        }
    }
}
