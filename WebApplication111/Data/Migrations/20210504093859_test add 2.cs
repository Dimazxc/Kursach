using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class testadd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TestCom");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "TestCom",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "TestCom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "TestCom",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "TestCom");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "TestCom");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "TestCom");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "TestCom",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
