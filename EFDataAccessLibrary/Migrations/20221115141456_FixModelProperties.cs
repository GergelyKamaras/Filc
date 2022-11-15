using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FixModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Teacher_Lesson_LessonId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_School_SchoolId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_LessonId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_School_SchoolAdminId",
                table: "School");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SchoolAdminId",
                table: "School");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "SchoolClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "SchoolAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LessonTeacher",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTeacher", x => new { x.LessonsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_LessonTeacher_Lesson_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTeacher_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAdmin_SchoolId",
                table: "SchoolAdmin",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTeacher_TeachersId",
                table: "LessonTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_School_SchoolId",
                table: "Lesson",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolAdmin_School_SchoolId",
                table: "SchoolAdmin",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_School_SchoolId",
                table: "SchoolClasses",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_School_SchoolId",
                table: "Student",
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
                name: "FK_SchoolAdmin_School_SchoolId",
                table: "SchoolAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_School_SchoolId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_School_SchoolId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_School_SchoolId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "LessonTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SchoolAdmin_SchoolId",
                table: "SchoolAdmin");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "SchoolAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Teacher",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "SchoolClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SchoolAdminId",
                table: "School",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_LessonId",
                table: "Teacher",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_School_SchoolAdminId",
                table: "School",
                column: "SchoolAdminId");

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
                name: "FK_Teacher_Lesson_LessonId",
                table: "Teacher",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_School_SchoolId",
                table: "Teacher",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");
        }
    }
}
