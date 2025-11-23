using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipsCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CoffeeProducts_CoffeeProductDBId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryCoffeeId",
                table: "CoffeeProducts");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeProducts_CategoryCoffeeId",
                table: "CoffeeProducts");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CoffeeProductDBId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryCoffeeId",
                table: "CoffeeProducts");

            migrationBuilder.DropColumn(
                name: "CoffeeProductDBId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryDBCoffeeProductDB",
                columns: table => new
                {
                    CoffeeProductsId = table.Column<int>(type: "integer", nullable: false),
                    CreatedCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDBCoffeeProductDB", x => new { x.CoffeeProductsId, x.CreatedCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryDBCoffeeProductDB_Categories_CreatedCategoryId",
                        column: x => x.CreatedCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryDBCoffeeProductDB_CoffeeProducts_CoffeeProductsId",
                        column: x => x.CoffeeProductsId,
                        principalTable: "CoffeeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDBCoffeeProductDB_CreatedCategoryId",
                table: "CategoryDBCoffeeProductDB",
                column: "CreatedCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryDBCoffeeProductDB");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCoffeeId",
                table: "CoffeeProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoffeeProductDBId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProducts_CategoryCoffeeId",
                table: "CoffeeProducts",
                column: "CategoryCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CoffeeProductDBId",
                table: "Categories",
                column: "CoffeeProductDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CoffeeProducts_CoffeeProductDBId",
                table: "Categories",
                column: "CoffeeProductDBId",
                principalTable: "CoffeeProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryCoffeeId",
                table: "CoffeeProducts",
                column: "CategoryCoffeeId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
