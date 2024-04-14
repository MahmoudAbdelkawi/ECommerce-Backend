using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0aba04b-a4a5-42a4-a39d-380ce1a0078d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edfd2401-14b7-4dca-aecc-f3cc96fbd849");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 4, 13, 14, 8, 12, 484, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "786c6fda-7c11-4011-8e93-8883b9c1fe8e", null, "User", "USER" },
                    { "cbb12ac0-310f-48d7-ad75-52469c9a012f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "786c6fda-7c11-4011-8e93-8883b9c1fe8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbb12ac0-310f-48d7-ad75-52469c9a012f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 13, 14, 8, 12, 484, DateTimeKind.Local).AddTicks(4700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0aba04b-a4a5-42a4-a39d-380ce1a0078d", null, "Admin", "ADMIN" },
                    { "edfd2401-14b7-4dca-aecc-f3cc96fbd849", null, "User", "USER" }
                });
        }
    }
}
