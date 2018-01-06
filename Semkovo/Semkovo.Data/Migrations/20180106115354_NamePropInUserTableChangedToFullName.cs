using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Semkovo.Data.Migrations
{
    public partial class NamePropInUserTableChangedToFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 374, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 3, 22, 34, 45, 754, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 365, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 3, 22, 34, 45, 743, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: true,
                defaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 349, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 1, 3, 22, 34, 45, 722, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 3, 22, 34, 45, 754, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 374, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 3, 22, 34, 45, 743, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 365, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: true,
                defaultValue: new DateTime(2018, 1, 3, 22, 34, 45, 722, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 349, DateTimeKind.Local));
        }
    }
}
