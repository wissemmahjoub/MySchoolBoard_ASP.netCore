using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class ModuleTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModulsTeacher_users_TeachersCIN",
                table: "ModulsTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulsTeacher",
                table: "ModulsTeacher");

            migrationBuilder.DropIndex(
                name: "IX_ModulsTeacher_TeachersCIN",
                table: "ModulsTeacher");

            migrationBuilder.DropColumn(
                name: "idModulsTeacher",
                table: "ModulsTeacher");

            migrationBuilder.DropColumn(
                name: "TeachersCIN",
                table: "ModulsTeacher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulsTeacher",
                table: "ModulsTeacher",
                columns: new[] { "Id_Teacher", "ModuleId" });

            migrationBuilder.CreateIndex(
                name: "IX_ModulsTeacher_Id_Teacher",
                table: "ModulsTeacher",
                column: "Id_Teacher");

            migrationBuilder.AddForeignKey(
                name: "FK_ModulsTeacher_users_Id_Teacher",
                table: "ModulsTeacher",
                column: "Id_Teacher",
                principalTable: "users",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModulsTeacher_users_Id_Teacher",
                table: "ModulsTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModulsTeacher",
                table: "ModulsTeacher");

            migrationBuilder.DropIndex(
                name: "IX_ModulsTeacher_Id_Teacher",
                table: "ModulsTeacher");

            migrationBuilder.AddColumn<int>(
                name: "idModulsTeacher",
                table: "ModulsTeacher",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddColumn<int>(
                name: "TeachersCIN",
                table: "ModulsTeacher",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModulsTeacher",
                table: "ModulsTeacher",
                column: "idModulsTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsTeacher_TeachersCIN",
                table: "ModulsTeacher",
                column: "TeachersCIN");

            migrationBuilder.AddForeignKey(
                name: "FK_ModulsTeacher_users_TeachersCIN",
                table: "ModulsTeacher",
                column: "TeachersCIN",
                principalTable: "users",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
