using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRS.Data.Migrations
{
    public partial class crs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Old = table.Column<int>(type: "int", nullable: false),
                    New = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarChangeLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarChangeLogs");
        }
    }
}
