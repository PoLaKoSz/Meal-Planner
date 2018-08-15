using FluentMigrator.Runner;
using MealPlanner.DataAccessLayer.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MealPlanner.DataAccessLayer
{
    public class SQLiteMigrator
    {
        private readonly IServiceProvider _migrationService;



        public SQLiteMigrator(SQLiteDB db)
        {
            _migrationService = new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSQLite()
                    // Set the connection string
                    .WithGlobalConnectionString(db.ConnectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(_001_Create_Ingredients_Table).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }



        public void UpdateDatabase()
        {
            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = _migrationService.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Update the database
        /// </sumamry>
        private void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
