using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161503)]
    public class _004_Create_Ready_Meals_Table : Migration
    {
        public override void Up()
        {
            Create.Table("ready_meals")
                .WithColumn("meal_id").AsInt64()
                .WithColumn("meal_ingredient_id").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("ready_meals");
        }
    }
}
