using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipCoffeeProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "CoffeeProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProducts_AuthorId",
                table: "CoffeeProducts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Users_AuthorId",
                table: "CoffeeProducts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Users_AuthorId",
                table: "CoffeeProducts");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeProducts_AuthorId",
                table: "CoffeeProducts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "CoffeeProducts");
        }
    }
}
