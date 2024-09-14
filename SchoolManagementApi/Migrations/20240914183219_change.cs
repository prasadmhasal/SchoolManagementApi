using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeacherLeaves");

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "TeacherLeaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Standard",
                table: "TeacherLeaves");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TeacherLeaves",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
