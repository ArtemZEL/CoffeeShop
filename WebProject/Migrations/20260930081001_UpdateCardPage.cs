using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCardPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryId",
                table: "CoffeeProducts");
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CoffeeProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CoffeeGrinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeGrinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoffeeProductId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    GrindId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeProductVariants_CoffeeGrinds_GrindId",
                        column: x => x.GrindId,
                        principalTable: "CoffeeGrinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoffeeProductVariants_CoffeeProducts_CoffeeProductId",
                        column: x => x.CoffeeProductId,
                        principalTable: "CoffeeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProductVariants_CoffeeProductId",
                table: "CoffeeProductVariants",
                column: "CoffeeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeProductVariants_GrindId",
                table: "CoffeeProductVariants",
                column: "GrindId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryId",
                table: "CoffeeProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryId",
                table: "CoffeeProducts");

            migrationBuilder.DropTable(
                name: "CoffeeProductVariants");

            migrationBuilder.DropTable(
                name: "CoffeeGrinds");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CoffeeProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeProducts_Categories_CategoryId",
                table: "CoffeeProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
