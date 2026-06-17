using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.FP.Datacontext.Migrations
{
    /// <inheritdoc />
    public partial class activated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ForgotPasswordRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ForgotPasswordRequests");
        }
    }
}
