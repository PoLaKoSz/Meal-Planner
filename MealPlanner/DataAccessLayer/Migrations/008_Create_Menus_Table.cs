using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161507)]
    public class _008_Create_Menus_Table : Migration
    {
        public override void Up()
        {
            Create.Table("menus")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("day").AsDateTime();
        }

        public override void Down()
        {
            Delete.Table("menus");
        }
    }
}
