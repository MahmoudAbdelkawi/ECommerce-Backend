using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserVerificationCodes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 13, 13, 10, 8, 881, DateTimeKind.Local).AddTicks(9607),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 12, 17, 10, 29, 231, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03b2c58c-4aa5-4670-9142-136bfb44adc7", null, "Admin", "ADMIN" },
                    { "21c6764f-6ca9-410b-b6df-1110f493470b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ExpirationDate",
                table: "UserVerificationCodes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserVerificationCodes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 12, 17, 10, 29, 231, DateTimeKind.Local).AddTicks(3050),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 4, 13, 13, 10, 8, 881, DateTimeKind.Local).AddTicks(9607));
        }
    }
}
