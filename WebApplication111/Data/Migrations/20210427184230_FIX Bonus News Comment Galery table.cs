using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication111.Data.Migrations
{
    public partial class FIXBonusNewsCommentGalerytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bonus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "News",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "News",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ImageGalery",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Bonus",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ImageGalery");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Bonus");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bonus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
