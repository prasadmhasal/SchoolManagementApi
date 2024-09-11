using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class labadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Librarian",
                columns: table => new
                {
                    LibararianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibrarianUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Librarianpass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibrarianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<long>(type: "bigint", nullable: false),
                    Joindate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarian", x => x.LibararianId);
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Librarian");

           
        }
    }
}
