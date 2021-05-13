using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Fixuserbonustable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "UserBonus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBonus_CompanyId",
                table: "UserBonus",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBonus_Company_CompanyId",
                table: "UserBonus",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBonus_Company_CompanyId",
                table: "UserBonus");

            migrationBuilder.DropIndex(
                name: "IX_UserBonus_CompanyId",
                table: "UserBonus");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UserBonus");
        }
    }
}
