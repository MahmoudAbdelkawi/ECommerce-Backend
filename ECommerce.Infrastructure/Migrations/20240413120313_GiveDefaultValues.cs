using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GiveDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c80504e-8fd4-452f-8b90-73404ce8ffd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7092cb58-97e8-442e-bd0b-e7386ac8fd46");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 13, 14, 8, 12, 484, DateTimeKind.Local).AddTicks(4700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 4, 13, 13, 15, 7, 900, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.AlterColumn<bool>(
                name: "CanChangePassword",
                table: "UserVerificationCodes",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0aba04b-a4a5-42a4-a39d-380ce1a0078d", null, "Admin", "ADMIN" },
                    { "edfd2401-14b7-4dca-aecc-f3cc96fbd849", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 13, 13, 15, 7, 900, DateTimeKind.Local).AddTicks(3753),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "CanChangePassword",
                table: "UserVerificationCodes",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c80504e-8fd4-452f-8b90-73404ce8ffd2", null, "Admin", "ADMIN" },
                    { "7092cb58-97e8-442e-bd0b-e7386ac8fd46", null, "User", "USER" }
                });
        }
    }
}
