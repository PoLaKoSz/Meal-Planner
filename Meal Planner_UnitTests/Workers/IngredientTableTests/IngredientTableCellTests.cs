using Meal_Planner_UnitTests.Helpers;
using MealPlanner.Workers.IngredientTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meal_Planner_UnitTests.Workers.IngredientTableTests
{
    [TestClass]
    public class IngredientTableCellTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Freshly_Initialized_Cell_Should_Not_Be_Valid()
            {
                var row = new FakeIngredientTableRow();
                var cell = new IngredientTableCell(4, row);

                Assert.IsFalse(cell.IsValid());
            }
        }

        [TestClass]
        public class IsValidMethod
        {
            private IngredientTableCell _cell;



            [TestInitialize]
            public void TestInitialize()
            {
                _cell = new IngredientTableCell(4, new FakeIngredientTableRow());
            }



            [TestMethod]
            public void Empty_Name_Property_Should_Be_Invalid()
            {
                _cell.Quantity = 4;
                _cell.QuantityName = "g";

                Assert.IsFalse(_cell.IsValid());
            }

            [TestMethod]
            public void Empty_QuantityName_Property_Should_Be_Invalid()
            {
                _cell.Quantity = 4;
                _cell.Name = "Meat";

                Assert.IsFalse(_cell.IsValid());
            }

            [TestMethod]
            public void Default_Quantity_Property_Should_Be_Invalid()
            {
                _cell.Name = "Meat";
                _cell.QuantityName = "g";

                Assert.IsFalse(_cell.IsValid());
            }

            [TestMethod]
            public void Filled_Cell_Should_Be_Valid()
            {
                _cell.Name = "Meat";
                _cell.Quantity = 3;
                _cell.QuantityName = "g";

                Assert.IsTrue(_cell.IsValid());
            }
        }

        [TestClass]
        public class SignalToContainerMethod
        {
            private FakeIngredientTableRow _container;
            private IngredientTableCell _cell;



            [TestInitialize]
            public void TestInitialize()
            {
                _container = new FakeIngredientTableRow();
                _cell = new IngredientTableCell(4, _container);
            }



            [TestMethod]
            public void Invalid_Cell_Should_Not_Be_Able_To_Signal_To_The_Container()
            {
                _cell.SignalToContainer();

                Assert.AreEqual(-1, _container.SignaledCellIndex);
            }

            [TestMethod]
            public void Valid_Cell_Should_Be_Able_To_Signal_To_The_Container()
            {
                _cell.Name = "Meat";
                _cell.Quantity = 3;
                _cell.QuantityName = "g";

                _cell.SignalToContainer();

                Assert.AreEqual(4, _container.SignaledCellIndex);
            }
        }
    }
}
