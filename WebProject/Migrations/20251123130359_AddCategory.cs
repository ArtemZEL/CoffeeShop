using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryDBId",
                table: "CoffeeProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProducts_CategoryDBId",
                table: "CoffeeProducts",
                column: "CategoryDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryDBId",
                table: "CoffeeProducts",
                column: "CategoryDBId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryDBId",
                table: "CoffeeProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeProducts_CategoryDBId",
                table: "CoffeeProducts");

            migrationBuilder.DropColumn(
                name: "CategoryDBId",
                table: "CoffeeProducts");
        }
    }
}
