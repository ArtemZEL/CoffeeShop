using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryDBId",
                table: "CoffeeProducts");

            migrationBuilder.RenameColumn(
                name: "CategoryDBId",
                table: "CoffeeProducts",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeProducts_CategoryDBId",
                table: "CoffeeProducts",
                newName: "IX_CoffeeProducts_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryId",
                table: "CoffeeProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryId",
                table: "CoffeeProducts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CoffeeProducts",
                newName: "CategoryDBId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeProducts_CategoryId",
                table: "CoffeeProducts",
                newName: "IX_CoffeeProducts_CategoryDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryDBId",
                table: "CoffeeProducts",
                column: "CategoryDBId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
