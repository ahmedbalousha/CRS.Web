using Microsoft.EntityFrameworkCore.Migrations;

namespace CRS.Data.Migrations
{
    public partial class crs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCompanies_CarCompanyId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarCompnyId",
                table: "Cars");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Contracts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "CarCompanyId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCompanies_CarCompanyId",
                table: "Cars",
                column: "CarCompanyId",
                principalTable: "CarCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCompanies_CarCompanyId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "CarCompanyId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarCompnyId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCompanies_CarCompanyId",
                table: "Cars",
                column: "CarCompanyId",
                principalTable: "CarCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
