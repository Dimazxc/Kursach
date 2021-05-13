using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Addcomentrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentRating",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsLike = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CommentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentRating_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRating_CommentId",
                table: "CommentRating",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentRating");
        }
    }
}
