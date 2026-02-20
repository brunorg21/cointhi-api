using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cointhi.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "datetime('now', 'utc')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "transactions",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "datetime('now', 'utc')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "transaction_categories",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "datetime('now', 'utc')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "categories",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "datetime('now', 'utc')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "GETUTCDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "datetime('now', 'utc')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "transactions",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "datetime('now', 'utc')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "transaction_categories",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "datetime('now', 'utc')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "categories",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "datetime('now', 'utc')");
        }
    }
}
