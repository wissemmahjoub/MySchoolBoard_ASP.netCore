using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class ModuleClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulsClass",
                table: "ModulsClass");

            migrationBuilder.DropColumn(
                name: "idModulsClass",
                table: "ModulsClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulsClass",
                table: "ModulsClass",
                columns: new[] { "ClasssId", "ModuleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulsClass",
                table: "ModulsClass");

            migrationBuilder.AddColumn<int>(
                name: "idModulsClass",
                table: "ModulsClass",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulsClass",
                table: "ModulsClass",
                column: "idModulsClass");
        }
    }
}
