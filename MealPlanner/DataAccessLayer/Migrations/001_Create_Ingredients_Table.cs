using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161500)]
    public class _001_Create_Ingredients_Table : Migration
    {
        public override void Up()
        {
            Create.Table("ingredients").
                WithColumn("id").AsInt64().PrimaryKey().Identity().
                WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("ingredients");
        }
    }
}
