using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.FP.Datacontext.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForgotPasswordRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPasswordRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForgotPasswordResponces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    OTPCode = table.Column<string>(type: "TEXT", nullable: false),
                    Offset = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    RequestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPasswordResponces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForgotPasswordResponces_ForgotPasswordRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "ForgotPasswordRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForgotPasswordResponces_RequestId",
                table: "ForgotPasswordResponces",
                column: "RequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgotPasswordResponces");

            migrationBuilder.DropTable(
                name: "ForgotPasswordRequests");
        }
    }
}
