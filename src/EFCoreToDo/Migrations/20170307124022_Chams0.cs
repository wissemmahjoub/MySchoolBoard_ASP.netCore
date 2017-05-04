using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class Chams0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Classs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "Classs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "Classs");
        }
    }
}
