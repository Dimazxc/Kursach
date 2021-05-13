using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Changeuserbonustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBonus_Company_CompanyId",
                table: "UserBonus");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "UserBonus");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserBonus");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "UserBonus",
                newName: "BonusId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBonus_CompanyId",
                table: "UserBonus",
                newName: "IX_UserBonus_BonusId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBonus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBonus_Bonus_BonusId",
                table: "UserBonus",
                column: "BonusId",
                principalTable: "Bonus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBonus_Bonus_BonusId",
                table: "UserBonus");

            migrationBuilder.RenameColumn(
                name: "BonusId",
                table: "UserBonus",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBonus_BonusId",
                table: "UserBonus",
                newName: "IX_UserBonus_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBonus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PurchasePrice",
                table: "UserBonus",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserBonus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBonus_Company_CompanyId",
                table: "UserBonus",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
