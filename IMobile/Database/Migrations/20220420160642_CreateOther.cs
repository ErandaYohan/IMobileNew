using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class CreateOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDate = table.Column<DateTime>(nullable: false),
                    dateShipped = table.Column<string>(nullable: true),
                    customerName = table.Column<string>(nullable: true),
                    customerId = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    shippingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    PId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    PDes = table.Column<string>(nullable: true),
                    PPrice = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    CatId = table.Column<int>(nullable: false),
                    CategoryCatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.PId);
                    table.ForeignKey(
                        name: "FK_Items_categories_CategoryCatId",
                        column: x => x.CategoryCatId,
                        principalTable: "categories",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfo",
                columns: table => new
                {
                    shippingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shippingType = table.Column<string>(nullable: true),
                    shippingCost = table.Column<int>(nullable: false),
                    OrdersorderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfo", x => x.shippingId);
                    table.ForeignKey(
                        name: "FK_ShippingInfo_orders_OrdersorderId",
                        column: x => x.OrdersorderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    unitCost = table.Column<int>(nullable: false),
                    subTotal = table.Column<int>(nullable: false),
                    ItemsPId = table.Column<int>(nullable: true),
                    OrdersorderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemsPId",
                        column: x => x.ItemsPId,
                        principalTable: "Items",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_orders_OrdersorderId",
                        column: x => x.OrdersorderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryCatId",
                table: "Items",
                column: "CategoryCatId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemsPId",
                table: "OrderDetails",
                column: "ItemsPId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrdersorderId",
                table: "OrderDetails",
                column: "OrdersorderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInfo_OrdersorderId",
                table: "ShippingInfo",
                column: "OrdersorderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShippingInfo");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
