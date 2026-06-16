using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.FP.Datacontext.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ForgotPasswordResponces");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "ForgotPasswordResponces");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ForgotPasswordResponces",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "ForgotPasswordResponces",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
