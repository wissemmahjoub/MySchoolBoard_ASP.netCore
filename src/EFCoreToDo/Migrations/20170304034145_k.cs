using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreToDo.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classs",
                columns: table => new
                {
                    ClasssId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    NbreEtudiants = table.Column<int>(nullable: false),
                    Speciality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classs", x => x.ClasssId);
                });

            migrationBuilder.CreateTable(
                name: "Courss",
                columns: table => new
                {
                    id_cours = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courss", x => x.id_cours);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ModuleCoeif = table.Column<double>(nullable: false),
                    ModuleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    HomeworkId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    HomeworkContent = table.Column<string>(nullable: true),
                    HomeworkDescription = table.Column<string>(nullable: true),
                    ModuleeModuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.HomeworkId);
                    table.ForeignKey(
                        name: "FK_Homeworks_Modules_ModuleeModuleId",
                        column: x => x.ModuleeModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModulsClass",
                columns: table => new
                {
                    idModulsClass = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClasssId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulsClass", x => x.idModulsClass);
                    table.ForeignKey(
                        name: "FK_ModulsClass_Classs_ClasssId",
                        column: x => x.ClasssId,
                        principalTable: "Classs",
                        principalColumn: "ClasssId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulsClass_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModulsCours",
                columns: table => new
                {
                    idModulsCours = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ModuleId = table.Column<int>(nullable: false),
                    id_cours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulsCours", x => x.idModulsCours);
                    table.ForeignKey(
                        name: "FK_ModulsCours_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulsCours_Courss_id_cours",
                        column: x => x.id_cours,
                        principalTable: "Courss",
                        principalColumn: "id_cours",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    CIN = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Adress = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    E_mail = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    SecretCode = table.Column<string>(nullable: true),
                    classs1ClasssId = table.Column<int>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true),
                    ServiceCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.CIN);
                    table.ForeignKey(
                        name: "FK_users_Classs_classs1ClasssId",
                        column: x => x.classs1ClasssId,
                        principalTable: "Classs",
                        principalColumn: "ClasssId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MarkId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CC = table.Column<float>(nullable: false),
                    DS = table.Column<float>(nullable: false),
                    Exam = table.Column<float>(nullable: false),
                    ModuleeModuleId = table.Column<int>(nullable: true),
                    Moyenne = table.Column<float>(nullable: false),
                    sutdentsCIN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_Marks_Modules_ModuleeModuleId",
                        column: x => x.ModuleeModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marks_users_sutdentsCIN",
                        column: x => x.sutdentsCIN,
                        principalTable: "users",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModulsTeacher",
                columns: table => new
                {
                    idModulsTeacher = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Id_Teacher = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    TeachersCIN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulsTeacher", x => x.idModulsTeacher);
                    table.ForeignKey(
                        name: "FK_ModulsTeacher_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulsTeacher_users_TeachersCIN",
                        column: x => x.TeachersCIN,
                        principalTable: "users",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Content = table.Column<string>(nullable: true),
                    Publication_Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UsersCIN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_users_UsersCIN",
                        column: x => x.UsersCIN,
                        principalTable: "users",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Comment_Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    SubjectsSubjectId = table.Column<int>(nullable: true),
                    UsersCIN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Subjects_SubjectsSubjectId",
                        column: x => x.SubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_users_UsersCIN",
                        column: x => x.UsersCIN,
                        principalTable: "users",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SubjectsSubjectId",
                table: "Comments",
                column: "SubjectsSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UsersCIN",
                table: "Comments",
                column: "UsersCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_ModuleeModuleId",
                table: "Homeworks",
                column: "ModuleeModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ModuleeModuleId",
                table: "Marks",
                column: "ModuleeModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_sutdentsCIN",
                table: "Marks",
                column: "sutdentsCIN");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsClass_ClasssId",
                table: "ModulsClass",
                column: "ClasssId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsClass_ModuleId",
                table: "ModulsClass",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsCours_ModuleId",
                table: "ModulsCours",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsCours_id_cours",
                table: "ModulsCours",
                column: "id_cours");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsTeacher_ModuleId",
                table: "ModulsTeacher",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulsTeacher_TeachersCIN",
                table: "ModulsTeacher",
                column: "TeachersCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UsersCIN",
                table: "Subjects",
                column: "UsersCIN");

            migrationBuilder.CreateIndex(
                name: "IX_users_classs1ClasssId",
                table: "users",
                column: "classs1ClasssId");

            migrationBuilder.CreateIndex(
                name: "IX_users_ModuleId",
                table: "users",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "ModulsClass");

            migrationBuilder.DropTable(
                name: "ModulsCours");

            migrationBuilder.DropTable(
                name: "ModulsTeacher");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courss");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Classs");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
