using Meal_Planner_UnitTests.Helpers;
using MealPlanner.Models;
using MealPlanner.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Meal_Planner_UnitTests.Workers
{
    [TestClass]
    public class MenuGeneratorTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Constructor__PassNullRepastList__ShouldReturnArgumentNullException()
            {
                new MenuGenerator(null);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Constructor__PassNullDayList__ShouldReturnArgumentNullException()
            {
                new MenuGenerator(new List<Repast>(), null);
            }
        }

        [TestClass]
        public class SetDateRangeMethod
        {
            private MenuGenerator _menuGenerator { get; set; }
            


            [TestInitialize]
            public void TestInitialize()
            {
                _menuGenerator = new MenuGenerator(new List<Repast>());
            }



            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void SetDateRange__StartDateBiggerThanEndDate__ShouldThrowArgumentExceptionException()
            {
                _menuGenerator.ChangeDateRange(new DateTime(2018, 6, 17), new DateTime(2018, 5, 20));
            }                      

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void SetDateRange__StartDateIsNotInicialized__ShouldThrowArgumentNullException()
            {
                _menuGenerator.ChangeDateRange(default(DateTime), new DateTime(2018, 5, 20));
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void SetDateRange__EndDateIsNotInicialized__ShouldThrowArgumentNullException()
            {
                _menuGenerator.ChangeDateRange(new DateTime(2018, 5, 16), default(DateTime));
            }

            [TestMethod]
            public void SetDateRange__StartDateAndEndDateIsTheSameDay__ShouldReturnOneDayTheStartDate()
            {
                List<Day> expected = new List<Day>()
                {
                    new Day(new List<RepastForMenu>(), 2018, 6, 17)
                };

                _menuGenerator.ChangeDateRange(new DateTime(2018, 06, 17), new DateTime(2018, 06, 17));

                CollectionAssert.AreEqual(expected, _menuGenerator.Days);
            }

            [TestMethod]
            public void SetDateRange__StartDateAndEndDateFollowEachOther__ShouldReturnTwoDay()
            {
                List<Day> expected = new List<Day>()
                {
                    new Day(new List<RepastForMenu>(), 2018, 6, 17),
                    new Day(new List<RepastForMenu>(), 2018, 6, 18)
                };

                _menuGenerator.ChangeDateRange(new DateTime(2018, 06, 17), new DateTime(2018, 06, 18));

                CollectionAssert.AreEqual(expected, _menuGenerator.Days);
            }
        }

        [TestClass]
        public class ResetMenuMethod
        {
            [TestMethod]
            public void ResetMenu__ShouldRemoveEveryItemFromDayList()
            {
                MenuGenerator menuGenerator = new MenuGenerator(new List<Repast>()
                {
                    new Repast(""),
                });

                menuGenerator.ResetMenu();

                Assert.AreEqual(0, menuGenerator.Days.Count);
            }
        }

        [TestClass]
        public class CanBeAddedMethod
        {

        }
    }
}
