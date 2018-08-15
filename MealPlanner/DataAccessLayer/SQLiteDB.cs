using System.Data.SQLite;
using System.IO;

namespace MealPlanner.DataAccessLayer
{
    public class SQLiteDB
    {
        public readonly string ConnectionString;



        public SQLiteDB(string directory)
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = Path.Combine(directory, "MealPlanner.sqlite")
            }.ConnectionString;
        }
    }
}
