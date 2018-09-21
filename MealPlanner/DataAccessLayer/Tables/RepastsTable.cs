using Dapper;
using MealPlanner.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MealPlanner.DataAccessLayer.Tables
{
    public class RepastsTable
    {
        private readonly string _connectionString;
        private readonly string _tableName;



        public RepastsTable(string connectionString)
        {
            _connectionString = connectionString;
            _tableName = "repasts";
        }




        /// <summary>
        /// Add a new <see cref="Repast"/> to the table
        /// </summary>
        /// <param name="repast">New entity</param>
        public void Insert(Repast repast)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute($"INSERT INTO {_tableName} (name) VALUES (@Name)", repast);
            }
        }

        /// <summary>
        /// Get every <see cref="Repast"/> from the table
        /// </summary>
        /// <returns>Collection of <see cref="Repast"/></returns>
        public List<Repast> All()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Repast>($"SELECT * FROM {_tableName}").ToList();
            }
        }
    }
}
