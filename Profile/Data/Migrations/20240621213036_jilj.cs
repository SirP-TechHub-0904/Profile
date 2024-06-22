using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profile.Data.Migrations
{
    /// <inheritdoc />
    public partial class jilj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationDateRange",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationDateRange",
                table: "Applications");
        }
    }
}
