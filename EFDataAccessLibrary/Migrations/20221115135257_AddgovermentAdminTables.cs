using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddgovermentAdminTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Schools_SchoolId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Schools_SchoolId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SchoolAdmin_SchoolAdminId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Schools_SchoolId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Schools_SchoolId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Schools_SchoolId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_SchoolAdminId",
                table: "School",
                newName: "IX_School_SchoolAdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GovermentAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovermentAdmin", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_School_SchoolId",
                table: "Lesson",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_School_SchoolAdmin_SchoolAdminId",
                table: "School",
                column: "SchoolAdminId",
                principalTable: "SchoolAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_School_SchoolId",
                table: "SchoolClasses",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_School_SchoolId",
                table: "Student",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_School_SchoolId",
                table: "Subject",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_School_SchoolId",
                table: "Teacher",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_School_SchoolId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_School_SchoolAdmin_SchoolAdminId",
                table: "School");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_School_SchoolId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_School_SchoolId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_School_SchoolId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_School_SchoolId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "GovermentAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.RenameIndex(
                name: "IX_School_SchoolAdminId",
                table: "Schools",
                newName: "IX_Schools_SchoolAdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Schools_SchoolId",
                table: "Lesson",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Schools_SchoolId",
                table: "SchoolClasses",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SchoolAdmin_SchoolAdminId",
                table: "Schools",
                column: "SchoolAdminId",
                principalTable: "SchoolAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
