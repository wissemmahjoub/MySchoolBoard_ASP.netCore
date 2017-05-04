using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class chams3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    TimeTableId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    filenamee = table.Column<string>(nullable: true),
                    idclassee = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.TimeTableId);
                    table.ForeignKey(
                        name: "FK_TimeTables_Classs_idclassee",
                        column: x => x.idclassee,
                        principalTable: "Classs",
                        principalColumn: "ClasssId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "ClassNamee",
                table: "Classs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niveaux",
                table: "Classs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_idclassee",
                table: "TimeTables",
                column: "idclassee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNamee",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Niveaux",
                table: "Classs");

            migrationBuilder.DropTable(
                name: "TimeTables");
        }
    }
}
