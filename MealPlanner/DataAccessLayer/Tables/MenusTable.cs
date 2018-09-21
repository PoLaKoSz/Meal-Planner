using Dapper;
using MealPlanner.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MealPlanner.DataAccessLayer.Tables
{
    public class MenusTable
    {
        private readonly string _connectionString;
        private readonly string _tableName;



        public MenusTable(string connectionString)
        {
            _connectionString = connectionString;
            _tableName = "menus";
        }




        /// <summary>
        /// Add a new <see cref="Day"/> to the table
        /// </summary>
        /// <param name="menu">New entity</param>
        public void Insert(Day menu)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute($"INSERT INTO {_tableName} (name) VALUES (@Name)", menu);
            }
        }

        /// <summary>
        /// Get every <see cref="Day"/> from the table
        /// </summary>
        /// <returns>Collection of <see cref="Day"/></returns>
        public List<Day> All()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Day>($"SELECT * FROM {_tableName}").ToList();
            }
        }

        public void Update(Day menu)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute($"UPDATE {_tableName} (name) VALUES (@Name)", menu);
            }
        }
    }
}
