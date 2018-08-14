using MealPlanner.Workers.IngredientTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meal_Planner_UnitTests.Workers.IngredientTableTests
{
    [TestClass]
    public class IngredientTableTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void Should_Inicialize_One_Row()
            {
                IngredientTable table = new IngredientTable();

                var actual = table.IngredientRows;

                Assert.AreEqual(1, table.IngredientRows.Count, "Table should have exactly 1 row!");
            }

            [TestMethod]
            public void Should_Inicialize_One_Cell_In_The_First_Row()
            {
                IngredientTable table = new IngredientTable();

                var actual = table.IngredientRows;

                Assert.AreEqual(1, table.IngredientRows.Count, "Table should have exactly 1 row!");
                Assert.AreEqual(1, table.IngredientRows[0].Cells.Count, "Table should have exactly 1 cell!");
            }
        }
    }
}
