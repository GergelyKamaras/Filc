using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class AddIndentityForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Users_userId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SchoolAdmin");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "SchoolAdmin");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "SchoolAdmin");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "GovermentAdmin");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "GovermentAdmin");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "GovermentAdmin");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Teacher",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Student",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "SchoolAdmin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Parent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "GovermentAdmin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Student_userId",
                table: "Student",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAdmin_userId",
                table: "SchoolAdmin",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_userId",
                table: "Parent",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_GovermentAdmin_userId",
                table: "GovermentAdmin",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_GovermentAdmin_Users_userId",
                table: "GovermentAdmin",
                column: "userId",
                principalSchema: "Authetication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_Users_userId",
                table: "Parent",
                column: "userId",
                principalSchema: "Authetication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolAdmin_Users_userId",
                table: "SchoolAdmin",
                column: "userId",
                principalSchema: "Authetication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Users_userId",
                table: "Student",
                column: "userId",
                principalSchema: "Authetication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Users_userId",
                table: "Teacher",
                column: "userId",
                principalSchema: "Authetication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GovermentAdmin_Users_userId",
                table: "GovermentAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Parent_Users_userId",
                table: "Parent");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolAdmin_Users_userId",
                table: "SchoolAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Users_userId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Users_userId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_userId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_SchoolAdmin_userId",
                table: "SchoolAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Parent_userId",
                table: "Parent");

            migrationBuilder.DropIndex(
                name: "IX_GovermentAdmin_userId",
                table: "GovermentAdmin");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "SchoolAdmin");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "GovermentAdmin");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Teacher",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Student",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Student",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SchoolAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "SchoolAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "SchoolAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GovermentAdmin",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "GovermentAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "GovermentAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Users_userId",
                table: "Teacher",
                column: "userId",
                principalSchema: "Authetication",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
