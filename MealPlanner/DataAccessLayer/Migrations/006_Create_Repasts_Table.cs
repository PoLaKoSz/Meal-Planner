using FluentMigrator;

namespace MealPlanner.DataAccessLayer.Migrations
{
    [Migration(20180815161505)]
    public class _006_Create_Repasts_Table : Migration
    {
        public override void Up()
        {
            Create.Table("repasts")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("name").AsString()
                .WithColumn("order").AsInt16();
        }

        public override void Down()
        {
            Delete.Table("repasts");
        }
    }
}
