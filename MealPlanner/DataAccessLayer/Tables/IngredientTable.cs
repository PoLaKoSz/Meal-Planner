using Dapper;
using MealPlanner.Exceptions;
using MealPlanner.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MealPlanner.DataAccessLayer.Tables
{
    public class IngredientTable
    {
        private readonly string _connectionString;
        private readonly string _tableName;



        public IngredientTable(string connectionString)
        {
            _connectionString = connectionString;
            _tableName = "ingredients";
        }




        /// <summary>
        /// Add a new <see cref="Ingredient"/> to the table
        /// </summary>
        /// <param name="ingredient">New entity</param>
        public void Insert(Ingredient ingredient)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute($"INSERT INTO {_tableName} (name) VALUES (@Name)", ingredient);
            }
        }

        /// <summary>
        /// Get every <see cref="Ingredient"/> from the table
        /// </summary>
        /// <returns>Collection of <see cref="Ingredient"/></returns>
        public List<Ingredient> All()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Ingredient>($"SELECT * FROM {_tableName}").ToList();
            }
        }
        
        /// <summary>
        /// Update only one <see cref="Ingredient"/> entity
        /// </summary>
        /// <param name="ingredient">Entity which should be updated</param>
        /// <exception cref="SqlCommandException">Occurs when the update affect more or less than 1 row</exception>
        public void Update(Ingredient ingredient)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int effectedRowsCount = db.Execute($"UPDATE {_tableName} SET name = @Name; WHERE id = @ID", ingredient);

                if (effectedRowsCount != 1)
                    throw new SqlCommandException($"{effectedRowsCount} rows effected instead of 1 when updating an Ingredient enity with ID = {ingredient.ID}");
            }
        }

        /// <summary>
        /// Update more rows at once
        /// </summary>
        /// <param name="ingredients"></param>
        public void Update(List<Ingredient> ingredients)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute($"UPDATE {_tableName} SET name = @Name; WHERE id = @ID", ingredients);
            }
        }
    }
}
