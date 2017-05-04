using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulsCours",
                table: "ModulsCours");

            migrationBuilder.DropColumn(
                name: "idModulsCours",
                table: "ModulsCours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulsCours",
                table: "ModulsCours",
                columns: new[] { "id_cours", "ModuleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulsCours",
                table: "ModulsCours");

            migrationBuilder.AddColumn<int>(
                name: "idModulsCours",
                table: "ModulsCours",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulsCours",
                table: "ModulsCours",
                column: "idModulsCours");
        }
    }
}
