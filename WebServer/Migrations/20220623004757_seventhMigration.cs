using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServer.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDateTime",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBegin",
                table: "Queries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Queries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateBegin",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Queries");

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserGuid",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
