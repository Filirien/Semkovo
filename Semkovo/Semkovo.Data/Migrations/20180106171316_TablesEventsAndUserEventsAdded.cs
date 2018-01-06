using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Semkovo.Data.Migrations
{
    public partial class TablesEventsAndUserEventsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UsernameIndex",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "NormalizedUsername",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 36, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 374, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 27, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 365, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: true,
                defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 12, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 349, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Limit = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 38, DateTimeKind.Local))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.EventId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_UserEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_ParticipantId",
                table: "UserEvents",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                newName: "NormalizedUsername");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 374, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 36, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 365, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 27, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: true,
                defaultValue: new DateTime(2018, 1, 6, 13, 53, 53, 349, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 1, 6, 19, 13, 15, 12, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "UsernameIndex",
                table: "AspNetUsers",
                column: "NormalizedUsername",
                unique: true,
                filter: "[NormalizedUsername] IS NOT NULL");
        }
    }
}
