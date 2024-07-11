using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadyMadeATMBackend.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 5, 11, 15, 16, 20, 820, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 6, 11, 15, 16, 20, 820, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 6, 11, 15, 16, 20, 820, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 5, 11, 15, 16, 20, 820, DateTimeKind.Local).AddTicks(2492));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 5, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 6, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 6, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 5, 11, 13, 14, 11, 67, DateTimeKind.Local).AddTicks(6003));
        }
    }
}
