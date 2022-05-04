using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_categories_CategoryCatId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryCatId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryCatId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "categoriesCatId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_categoriesCatId",
                table: "Items",
                column: "categoriesCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_categories_categoriesCatId",
                table: "Items",
                column: "categoriesCatId",
                principalTable: "categories",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_categories_categoriesCatId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_categoriesCatId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "categoriesCatId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryCatId",
                table: "Items",
                column: "CategoryCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_categories_CategoryCatId",
                table: "Items",
                column: "CategoryCatId",
                principalTable: "categories",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
