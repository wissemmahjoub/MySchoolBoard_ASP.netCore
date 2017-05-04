using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class chemspesqfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClasseName",
                table: "Classs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Classs",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "Classs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClasseName",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Classs");


            migrationBuilder.AddColumn<string>(
              name: "ClassName",
              table: "Classs");

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "Classs");
        }
    }
}
