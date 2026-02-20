using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cointhi.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    transaction_type = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    transaction_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    category_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_categories_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaction_categories_transactions_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_categories_category_id",
                table: "transaction_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_categories_transaction_id",
                table: "transaction_categories",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction_categories");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
