using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Addfktoalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Comment",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Bonus",
                newName: "CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Bonus",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CompanyId",
                table: "Photo",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CompanyId",
                table: "Comment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_CompanyId",
                table: "Bonus",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bonus_Company_CompanyId",
                table: "Bonus",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Company_CompanyId",
                table: "Comment",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Company_CompanyId",
                table: "Photo",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonus_Company_CompanyId",
                table: "Bonus");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Company_CompanyId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Company_CompanyId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_CompanyId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CompanyId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Bonus_CompanyId",
                table: "Bonus");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Comment",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Bonus",
                newName: "CompanyID");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyID",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyID",
                table: "Bonus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
