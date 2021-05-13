using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class TEST4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CurruentBalance",
            //    table: "Company");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "Company",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<float>(
            //    name: "Balance",
            //    table: "Company",
            //    nullable: false,
            //    defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Balance",
            //    table: "Company");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Company",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(string))
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<float>(
            //    name: "CurruentBalance",
            //    table: "Company",
            //    type: "real",
            //    nullable: false,
            //    defaultValue: 0f);
        }
    }
}
