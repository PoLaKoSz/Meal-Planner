using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(201808161300)]
    public class _009_Add_And_Remove_Column_Inside_Meal_Ingredient_Table : Migration
    {
        public override void Up()
        {
            Alter.Table("meal_ingredients")
                .AddColumn("ingredient_id").AsInt64().NotNullable();

            Rename.Column("mail_id")
                .OnTable("meal_ingredients")
                .To("meal_id");

            Delete.Column("name").
                FromTable("meal_ingredients");
        }

        public override void Down()
        {
            Delete.Column("ingredient_id").
                FromTable("meal_ingredients");

            Rename.Column("meal_id")
                .OnTable("meal_ingredients")
                .To("mail_id");

            Alter.Table("meal_ingredients")
                .AddColumn("name").AsString();
        }
    }
}
