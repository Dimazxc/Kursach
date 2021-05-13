using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Aboba3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "TestCom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "TestCom",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Dislikes = table.Column<float>(type: "real", nullable: false),
            //        Likes = table.Column<long>(type: "bigint", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TestCom", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TestCom_Company_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Company",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_TestCom_CompanyId",
            //    table: "TestCom",
            //    column: "CompanyId");
        }
    }
}
