using Dapper;
using MealPlanner.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MealPlanner.DataAccessLayer.Tables
{
    public class MealsTable
    {
        private readonly string _connectionString;
        private readonly string _tableName;



        public MealsTable(string connectionString)
        {
            _connectionString = connectionString;
            _tableName = "meals";
        }



        public IList<MealWithRepastType> All()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<MealWithRepastType>($"SELECT * FROM {_tableName}").ToList();
            }
        }

        /// <summary>
        /// Update more rows at once
        /// </summary>
        /// <param name="meals"></param>
        public void Update(List<MealWithRepastType> meals)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute($"UPDATE {_tableName} SET name = @Name; WHERE id = @ID", meals);
            }
        }

        ///// <summary>
        ///// Update only one <see cref="Ingredient"/> entity
        ///// </summary>
        ///// <param name="ingredient">Entity which should be updated</param>
        ///// <exception cref="SqlCommandException">Occurs when the update affect more or less than 1 row</exception>
        //public void Update(Ingredient ingredient)
        //{
        //    using (IDbConnection db = new SqlConnection(_connectionString))
        //    {
        //        int effectedRowsCount = db.Execute($"UPDATE {_tableName} SET name = @Name; WHERE id = @ID", ingredient);

        //        if (effectedRowsCount != 1)
        //            throw new SqlCommandException($"{effectedRowsCount} rows effected instead of 1 when updating an Ingredient enity with ID = {ingredient.ID}");
        //    }
        //}


    }
}
