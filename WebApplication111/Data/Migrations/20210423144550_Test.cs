using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CurruentBalance",
                table: "Company",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Company",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Company",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Company",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Company",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlVideo",
                table: "Company",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurruentBalance",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "UrlVideo",
                table: "Company");
        }
    }
}
