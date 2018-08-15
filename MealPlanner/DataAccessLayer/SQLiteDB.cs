using MealPlanner.DataAccessLayer.Tables;
using System.Data.SQLite;
using System.IO;

namespace MealPlanner.DataAccessLayer
{
    public class SQLiteDB
    {
        private readonly IngredientTable _ingredientsTable;
        private readonly MealsTable _mealsTable;


        public readonly string ConnectionString;



        public SQLiteDB(string directory)
        {
            _ingredientsTable = new IngredientTable(ConnectionString);
            _mealsTable = new MealsTable(ConnectionString);

            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = Path.Combine(directory, "MealPlanner.sqlite")
            }.ConnectionString;
        }



        public IngredientTable Ingredient()
        {
            return _ingredientsTable;
        }

        public MealsTable Meal()
        {
            return _mealsTable;
        }
    }
}
