using Meal_Planner_UnitTests.Helpers;
using MealPlanner.Workers.IngredientTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meal_Planner_UnitTests.Workers.IngredientTableTests
{
    [TestClass]
    public class IngredientTableRowTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void Initialized_Row_Should_Not_Be_Able_To_Call_Container()
            {
                var table = new FakeIngredientTable();
                var currentRow = new IngredientTableRow(0, table);

                Assert.AreEqual(-1, table.SignaledRowIndex);
            }
        }

        [TestClass]
        public class SynchronizeMethod
        {
            private IngredientTable _table;



            [TestInitialize]
            public void TestInitialize()
            {
                _table = new IngredientTable();
            }



            [TestMethod]
            public void After_First_Cell_Of_The_First_Row_Filled_Should_Be_Able_To_Call_Container()
            {
                var table = new FakeIngredientTable();
                var currentRow = new IngredientTableRow(7, table);

                var firstCell = currentRow.Cells[0];
                firstCell.Quantity = 2;
                firstCell.QuantityName = "cup";
                firstCell.Name = "Tea";

                Assert.AreEqual(0, table.SignaledRowIndex);
            }

            [TestMethod]
            public void After_First_Cell_Of_The_First_Row_Is_Filled_Correctly_New_Column_Should_Appear_In_The_Same_Row()
            {
                FillFirstRowFirstCell();

                Assert.AreEqual(2, _table.IngredientRows[0].Cells.Count, "Table should contain 2 cell in the first row!");
            }

            [TestMethod]
            public void After_First_Cell_Of_The_First_Row_Is_Filled_Correctly_New_Row_Should_Appear()
            {
                FillFirstRowFirstCell();

                Assert.AreEqual(2, _table.IngredientRows.Count, "Table should contain 2 rows!");
                Assert.AreEqual(1, _table.IngredientRows[1].Cells.Count, "Table should contain 1 cell in the second row!");
            }

            [TestMethod]
            public void After_First_Cell_Of_The_First_Row_Is_Filled_Correctly_The_Second_Row_Should_Contain_A_Cell()
            {
                FillFirstRowFirstCell();

                Assert.AreEqual(2, _table.IngredientRows.Count, "Table should contain 2 rows!");
                Assert.AreEqual(1, _table.IngredientRows[1].Cells.Count, "Table should contain 1 cell in the second row!");
            }

            [TestMethod]
            public void After_The_First_Two_Cell_Of_The_First_Row_Filled_Should_Contain_Three_Cell()
            {
                FillFirstRowFirstCell();
                FillFirstRowSecondCell();

                Assert.AreEqual(3, _table.IngredientRows[0].Cells.Count, "The table first row should contain 3 cell!");
            }

            [TestMethod]
            public void After_The_First_Two_Cell_Of_The_First_Row_Filled_Should_Contain_One_Cell_In_The_Second_Row()
            {
                FillFirstRowFirstCell();
                FillFirstRowSecondCell();

                Assert.AreEqual(1, _table.IngredientRows[1].Cells.Count, "The table second row should contain 1 cell!");
            }

            [TestMethod]
            public void First_Two_Cell_Of_The_First_Two_Row_Filled_Should_Contain_Three_Row()
            {
                FillFirstRowFirstCell();  FillFirstRowSecondCell();

                FillSecondRowFirstCell(); FillSecondRowSecondCell();

                Assert.AreEqual(3, _table.IngredientRows.Count, "The table should contain 3 row!");
            }

            [TestMethod]
            public void First_Two_Cell_Of_The_First_Two_Row_Filled_Should_Contain_Three_Cell_In_The_First_Two_Row()
            {
                FillFirstRowFirstCell();  FillFirstRowSecondCell();

                FillSecondRowFirstCell(); FillSecondRowSecondCell();

                Assert.AreEqual(3, _table.IngredientRows[0].Cells.Count, "The table first row should contain 3 cell!");
                Assert.AreEqual(3, _table.IngredientRows[1].Cells.Count, "The table second row should contain 3 cell!");
            }

            private void FillFirstRowFirstCell()
            {
                FillCell(_table.IngredientRows[0].Cells[0]);
            }

            private void FillFirstRowSecondCell()
            {
                FillCell(_table.IngredientRows[0].Cells[1]);
            }

            private void FillSecondRowFirstCell()
            {
                FillCell(_table.IngredientRows[1].Cells[0]);
            }

            private void FillSecondRowSecondCell()
            {
                FillCell(_table.IngredientRows[1].Cells[1]);
            }

            private void FillCell(IngredientTableCell cell)
            {
                cell.Name = "Bread";
                cell.Quantity = 4;
                cell.QuantityName = "slice";
            }
        }        
    }
}
