using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Addcoltocomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Comment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Comment");
        }
    }
}
