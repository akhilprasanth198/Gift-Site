using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gift_Site.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "OrderId", "ProductId", "Quantity", "TotalPrice" },
                values: new object[] { 1, 1, 1, 1, 25.99m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "Status", "TotalRate", "UserId" },
                values: new object[] { 1, new DateTime(2024, 12, 2, 19, 50, 14, 136, DateTimeKind.Local).AddTicks(7379), "Pending", 41.98m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ProductName", "Quantity", "Rate" },
                values: new object[,]
                {
                    { 1, 0, "A beautiful gift basket", "Gift Basket", 10, 25.99m },
                    { 2, 0, "Delicious birthday cake", "Birthday Cake", 5, 15.99m },
                    { 3, 0, "Soft teddy bear for all ages", "Teddy Bear", 8, 19.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);
        }
    }
}
