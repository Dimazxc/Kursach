using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Fixphototable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Photo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
