using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161506)]
    public class _007_Create_Menu_Repasts_Table : Migration
    {
        public override void Up()
        {
            Create.Table("menu_repasts")
                .WithColumn("menu_id").AsInt64()
                .WithColumn("repast_meal_id").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("menu_repasts");
        }
    }
}
