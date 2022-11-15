using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddConnetionsAddSchoolAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolClassId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchoolAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SchoolType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SchoolAdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolAdmin_SchoolAdminId",
                        column: x => x.SchoolAdminId,
                        principalTable: "SchoolAdmin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClasses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SchoolId",
                table: "Teacher",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SchoolId",
                table: "Subject",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolClassId",
                table: "Student",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolId",
                table: "Student",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SchoolId",
                table: "Lesson",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_SchoolId",
                table: "SchoolClasses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SchoolAdminId",
                table: "Schools",
                column: "SchoolAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Schools_SchoolId",
                table: "Lesson",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_SchoolClasses_SchoolClassId",
                table: "Student",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Schools_SchoolId",
                table: "Student",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Schools_SchoolId",
                table: "Subject",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Schools_SchoolId",
                table: "Teacher",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Schools_SchoolId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_SchoolClasses_SchoolClassId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Schools_SchoolId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Schools_SchoolId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Schools_SchoolId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "SchoolAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_SchoolId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Subject_SchoolId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Student_SchoolClassId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SchoolId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_SchoolId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Lesson");
        }
    }
}
