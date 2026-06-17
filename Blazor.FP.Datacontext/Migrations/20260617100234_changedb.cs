using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.FP.Datacontext.Migrations
{
    /// <inheritdoc />
    public partial class changedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_in",
                table: "ForgotPasswordResponces");

            migrationBuilder.DropColumn(
                name: "Offset",
                table: "ForgotPasswordResponces");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_in",
                table: "ForgotPasswordRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Offset",
                table: "ForgotPasswordRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_in",
                table: "ForgotPasswordRequests");

            migrationBuilder.DropColumn(
                name: "Offset",
                table: "ForgotPasswordRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_in",
                table: "ForgotPasswordResponces",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Offset",
                table: "ForgotPasswordResponces",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
