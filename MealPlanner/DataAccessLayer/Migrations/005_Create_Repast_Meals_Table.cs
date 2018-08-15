using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161504)]
    public class _005_Create_Repast_Meals_Table : Migration
    {
        public override void Up()
        {
            Create.Table("repast_meals")
                .WithColumn("repast_id").AsInt64()
                .WithColumn("ready_meal_id").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("repast_meals");
        }
    }
}
