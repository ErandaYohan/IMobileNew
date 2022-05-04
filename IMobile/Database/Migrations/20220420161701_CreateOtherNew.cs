using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class CreateOtherNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
