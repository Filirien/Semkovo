using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Semkovo.Data.Migrations
{
    public partial class UserEventsDbSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 14, 47, 18, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 36, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 14, 47, 19, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 38, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 14, 47, 8, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 27, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: true,
                defaultValue: new DateTime(2018, 1, 6, 19, 14, 46, 994, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 12, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 36, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 14, 47, 18, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 38, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 14, 47, 19, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 27, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 14, 47, 8, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: true,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 12, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 14, 46, 994, DateTimeKind.Local));
        }
    }
}
