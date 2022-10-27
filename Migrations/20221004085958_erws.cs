using Microsoft.EntityFrameworkCore.Migrations;

namespace SI_Request.Migrations
{
    public partial class erws : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "statuse",
                table: "ComputerTbl",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statuse",
                table: "ComputerTbl");
        }
    }
}
