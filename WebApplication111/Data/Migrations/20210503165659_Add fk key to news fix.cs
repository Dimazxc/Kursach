using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Addfkkeytonewsfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Company_CompanyId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "News",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Company_CompanyId",
                table: "News",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Company_CompanyId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "News",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Company_CompanyId",
                table: "News",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
