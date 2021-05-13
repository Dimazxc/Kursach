using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class Workplea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                  sql: "CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;",
                     suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON Company(Name, Description) KEY INDEX PK_Company;",
                          suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
