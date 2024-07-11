using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadyMadeATMBackend.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AtmNumber", "Balance", "Name", "Pin" },
                values: new object[,]
                {
                    { 1, "1234567890", 1000.0, "Alice", 1234 },
                    { 2, "1234567891", 2000.0, "Bob", 1234 },
                    { 3, "1234567892", 3000.0, "Charlie", 1234 },
                    { 4, "1234567893", 4000.0, "Diana", 1234 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CurrentBalance", "Description", "ReceiverId", "SenderId", "Timestamp", "Type" },
                values: new object[,]
                {
                    { 1, 500.0, 1500.0, null, null, 1, new DateTime(2024, 5, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(5917), "Deposit" },
                    { 2, 200.0, 1300.0, null, null, 1, new DateTime(2024, 6, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(5945), "Withdraw" },
                    { 3, 1000.0, 3000.0, null, null, 2, new DateTime(2024, 6, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(5974), "Deposit" },
                    { 4, 500.0, 2500.0, null, null, 2, new DateTime(2024, 5, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(6003), "Withdraw" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
