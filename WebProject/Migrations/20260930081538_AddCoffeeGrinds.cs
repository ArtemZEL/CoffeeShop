using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCoffeeGrinds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "CoffeeGrinds",
            columns: new[] { "Name" },
            values: new object[,]
            {
                { "In grains" },
                { "Average" },
                { "Fine" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
            DELETE FROM "CoffeeGrinds"
             WHERE "Name" IN ('In grains', 'Average', 'Fine');
            """);
        }
    }
}
