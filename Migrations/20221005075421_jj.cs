using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SI_Request.Migrations
{
    public partial class jj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskCategoryTbl",
                columns: table => new
                {
                    TaskCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskCategory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCategoryTbl", x => x.TaskCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TaskTbl",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentAssistanceId = table.Column<int>(nullable: false),
                    Statuse = table.Column<bool>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TaskCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTbl", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskTbl_StudentAssistanceTbl_StudentAssistanceId",
                        column: x => x.StudentAssistanceId,
                        principalTable: "StudentAssistanceTbl",
                        principalColumn: "StudentAssistanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTbl_TaskCategoryTbl_TaskCategoryId",
                        column: x => x.TaskCategoryId,
                        principalTable: "TaskCategoryTbl",
                        principalColumn: "TaskCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTbl_StudentAssistanceId",
                table: "TaskTbl",
                column: "StudentAssistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTbl_TaskCategoryId",
                table: "TaskTbl",
                column: "TaskCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTbl");

            migrationBuilder.DropTable(
                name: "TaskCategoryTbl");
        }
    }
}
