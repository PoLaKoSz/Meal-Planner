using MealPlanner.DataAccessLayer.Tables;
using System.Data.SQLite;
using System.IO;

namespace MealPlanner.DataAccessLayer
{
    public class SQLiteDB
    {
        private readonly IngredientTable _ingredientsTable;
        private readonly MealsTable _mealsTable;
        private readonly MenusTable _menusTable;
        private readonly RepastsTable _repastsTable;


        public readonly string ConnectionString;



        public SQLiteDB(string directory)
        {
            _ingredientsTable = new IngredientTable(ConnectionString);
            _mealsTable = new MealsTable(ConnectionString);
            _menusTable = new MenusTable(ConnectionString);
            _repastsTable = new RepastsTable(ConnectionString);

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

        public MenusTable Menu()
        {
            return _menusTable;
        }

        public RepastsTable Repast()
        {
            return _repastsTable;
        }
    }
}
