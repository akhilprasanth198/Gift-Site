using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gift_Site.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 2, 22, 23, 45, 272, DateTimeKind.Local).AddTicks(8168));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 2, 22, 21, 22, 511, DateTimeKind.Local).AddTicks(9833));
        }
    }
}
