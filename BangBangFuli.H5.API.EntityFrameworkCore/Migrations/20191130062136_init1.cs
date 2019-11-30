using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponId",
                table: "Orders",
                newName: "CouponCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryNumber",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryNumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Orders",
                newName: "CouponId");
        }
    }
}
