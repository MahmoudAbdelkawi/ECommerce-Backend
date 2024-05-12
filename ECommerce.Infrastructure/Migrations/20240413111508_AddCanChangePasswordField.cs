using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCanChangePasswordField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03b2c58c-4aa5-4670-9142-136bfb44adc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21c6764f-6ca9-410b-b6df-1110f493470b");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 13, 13, 15, 7, 900, DateTimeKind.Local).AddTicks(3753),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 4, 13, 13, 10, 8, 881, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.AddColumn<bool>(
                name: "CanChangePassword",
                table: "UserVerificationCodes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanChangePasswordAvailability",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c80504e-8fd4-452f-8b90-73404ce8ffd2", null, "Admin", "ADMIN" },
                    { "7092cb58-97e8-442e-bd0b-e7386ac8fd46", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c80504e-8fd4-452f-8b90-73404ce8ffd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7092cb58-97e8-442e-bd0b-e7386ac8fd46");

            migrationBuilder.DropColumn(
                name: "CanChangePassword",
                table: "UserVerificationCodes");

            migrationBuilder.DropColumn(
                name: "CanChangePasswordAvailability",
                table: "UserVerificationCodes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 13, 13, 10, 8, 881, DateTimeKind.Local).AddTicks(9607),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 4, 13, 13, 15, 7, 900, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03b2c58c-4aa5-4670-9142-136bfb44adc7", null, "Admin", "ADMIN" },
                    { "21c6764f-6ca9-410b-b6df-1110f493470b", null, "User", "USER" }
                });
        }
    }
}
