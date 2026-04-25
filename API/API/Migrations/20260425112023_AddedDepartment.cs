using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DeptNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DeptNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeptId",
                table: "Student",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DeptId",
                table: "Student",
                column: "DeptId",
                principalTable: "Department",
                principalColumn: "DeptNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DeptId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Student_DeptId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Student");
        }
    }
}
