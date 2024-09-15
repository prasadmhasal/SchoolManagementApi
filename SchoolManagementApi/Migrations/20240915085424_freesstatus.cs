using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class freesstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FessStatus",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FessStatus",
                table: "Student");
        }
    }
}
