using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class HomewrokMigraion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeworkContent",
                table: "Homeworks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLimit",
                table: "Homeworks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Homeworks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "difficulty",
                table: "Homeworks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateLimit",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "difficulty",
                table: "Homeworks");

            migrationBuilder.AddColumn<string>(
                name: "HomeworkContent",
                table: "Homeworks",
                nullable: true);
        }
    }
}
