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
                name: "CategoryCoffeeId",
                table: "CoffeeProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CoffeeProductDBId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CoffeeProducts_CoffeeProductDBId",
                        column: x => x.CoffeeProductDBId,
                        principalTable: "CoffeeProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProducts_CategoryCoffeeId",
                table: "CoffeeProducts",
                column: "CategoryCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CoffeeProductDBId",
                table: "Categories",
                column: "CoffeeProductDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryCoffeeId",
                table: "CoffeeProducts",
                column: "CategoryCoffeeId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryCoffeeId",
                table: "CoffeeProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeProducts_CategoryCoffeeId",
                table: "CoffeeProducts");

            migrationBuilder.DropColumn(
                name: "CategoryCoffeeId",
                table: "CoffeeProducts");
        }
    }
}
