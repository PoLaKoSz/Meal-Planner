using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161502)]
    public class _003_Create_Meals_Table : Migration
    {
        public override void Up()
        {
            Create.Table("meals")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("name").AsString();
        }

        public override void Down()
        {
            Delete.Table("meals");
        }
    }
}
