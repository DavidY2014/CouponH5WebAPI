using Microsoft.EntityFrameworkCore.Migrations;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Coupons");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId",
                table: "Coupons",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Coupons",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Coupons",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Coupons");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coupons",
                newName: "EnrollmentId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Coupons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Coupons",
                nullable: false,
                defaultValue: 0);
        }
    }
}
