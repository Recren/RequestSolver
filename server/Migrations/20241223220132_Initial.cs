using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    user_type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    level_of_severity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    assigned_to_user_id = table.Column<int>(type: "int", nullable: false),
                    assigned_by_user_id = table.Column<int>(type: "int", nullable: false),
                    date_assigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_due = table.Column<DateTime>(type: "datetime2", nullable: false),
                    request_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    request_status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_Requests_Users_assigned_by_user_id",
                        column: x => x.assigned_by_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Users_assigned_to_user_id",
                        column: x => x.assigned_to_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_assigned_by_user_id",
                table: "Requests",
                column: "assigned_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_assigned_to_user_id",
                table: "Requests",
                column: "assigned_to_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
