using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161501)]
    public class _002_Create_Meal_Ingredients_Table : Migration
    {
        public override void Up()
        {
            Create.Table("meal_ingredients")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("mail_id").AsInt64()
                .WithColumn("quantity").AsInt32()
                .WithColumn("quantity_name").AsString()
                .WithColumn("name").AsString();
        }

        public override void Down()
        {
            Delete.Table("meal_ingredients");
        }
    }
}
