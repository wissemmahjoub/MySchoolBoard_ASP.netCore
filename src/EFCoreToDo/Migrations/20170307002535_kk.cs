using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Modules_ModuleeModuleId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_ModuleeModuleId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "ModuleeModuleId",
                table: "Homeworks");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_idmodule",
                table: "Homeworks",
                column: "idmodule");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Modules_idmodule",
                table: "Homeworks",
                column: "idmodule",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Modules_idmodule",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_idmodule",
                table: "Homeworks");

            migrationBuilder.AddColumn<int>(
                name: "ModuleeModuleId",
                table: "Homeworks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_ModuleeModuleId",
                table: "Homeworks",
                column: "ModuleeModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Modules_ModuleeModuleId",
                table: "Homeworks",
                column: "ModuleeModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
