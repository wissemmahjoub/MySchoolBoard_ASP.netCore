using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class chams4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNamee",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Niveaux",
                table: "Classs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassNamee",
                table: "Classs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niveaux",
                table: "Classs",
                nullable: true);
        }
    }
}
