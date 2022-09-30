using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkPlus_Orders_Assignment.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderPrice = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderName", "OrderPrice" },
                values: new object[] { 1, new DateTime(2022, 9, 29, 23, 8, 8, 15, DateTimeKind.Local).AddTicks(7906), "Order 1", 250 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderName", "OrderPrice" },
                values: new object[] { 2, new DateTime(2022, 9, 29, 23, 8, 8, 15, DateTimeKind.Local).AddTicks(7909), "Order 2", 550 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderName", "OrderPrice" },
                values: new object[] { 3, new DateTime(2022, 9, 29, 23, 8, 8, 15, DateTimeKind.Local).AddTicks(7913), "Order 2", 750 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
