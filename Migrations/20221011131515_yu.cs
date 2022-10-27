using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SI_Request.Migrations
{
    public partial class yu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "TaskTbl");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TaskTbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TaskTbl");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "TaskTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
