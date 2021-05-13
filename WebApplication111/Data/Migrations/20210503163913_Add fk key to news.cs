using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Addfkkeytonews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "News",
                newName: "CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_News_CompanyId",
                table: "News",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Company_CompanyId",
                table: "News",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Company_CompanyId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CompanyId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "News",
                newName: "CompanyID");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyID",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
