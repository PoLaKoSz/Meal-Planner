using MealPlanner.Workers.IngredientTable;

namespace Meal_Planner_UnitTests.Helpers
{
    internal class FakeIngredientTable : IIngredientTable
    {
        /// <summary>
        /// <c>-1</c> if no <see cref="IIngredientTableRow"/>
        /// signaled to
        /// the table, <c>0</c> otherwise
        /// </summary>
        public int SignaledRowIndex { get; private set; }



        public FakeIngredientTable()
        {
            SignaledRowIndex = -1;
        }



        /// <summary>
        /// Receive a filled line signal from a <see cref="IIngredientTableRow"/>
        /// </summary>
        /// <param name="tablerow"><see cref="IIngredientTableRow"/>
        /// which pinged this table</param>
        public void Synchronize()
        {
            SignaledRowIndex = 0;
        }
    }
}
