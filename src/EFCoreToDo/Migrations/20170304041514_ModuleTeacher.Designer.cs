using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreToDo.Models;

namespace EFCoreToDo.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20170304041514_ModuleTeacher")]
    partial class ModuleTeacher
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.2");

            modelBuilder.Entity("EFCoreToDo.Models.Classs", b =>
                {
                    b.Property<int>("ClasssId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NbreEtudiants");

                    b.Property<string>("Speciality");

                    b.HasKey("ClasssId");

                    b.ToTable("Classs");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Comment_Date");

                    b.Property<string>("Content");

                    b.Property<int?>("SubjectsSubjectId");

                    b.Property<int?>("UsersCIN");

                    b.HasKey("CommentId");

                    b.HasIndex("SubjectsSubjectId");

                    b.HasIndex("UsersCIN");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Courss", b =>
                {
                    b.Property<int>("id_cours")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.HasKey("id_cours");

                    b.ToTable("Courss");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Homework", b =>
                {
                    b.Property<int>("HomeworkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HomeworkContent");

                    b.Property<string>("HomeworkDescription");

                    b.Property<int?>("ModuleeModuleId");

                    b.HasKey("HomeworkId");

                    b.HasIndex("ModuleeModuleId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("CC");

                    b.Property<float>("DS");

                    b.Property<float>("Exam");

                    b.Property<int?>("ModuleeModuleId");

                    b.Property<float>("Moyenne");

                    b.Property<int?>("sutdentsCIN");

                    b.HasKey("MarkId");

                    b.HasIndex("ModuleeModuleId");

                    b.HasIndex("sutdentsCIN");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ModuleCoeif");

                    b.Property<string>("ModuleName");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("EFCoreToDo.Models.ModulsClass", b =>
                {
                    b.Property<int>("ClasssId");

                    b.Property<int>("ModuleId");

                    b.HasKey("ClasssId", "ModuleId");

                    b.HasIndex("ClasssId");

                    b.HasIndex("ModuleId");

                    b.ToTable("ModulsClass");
                });

            modelBuilder.Entity("EFCoreToDo.Models.ModulsCours", b =>
                {
                    b.Property<int>("id_cours");

                    b.Property<int>("ModuleId");

                    b.HasKey("id_cours", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("id_cours");

                    b.ToTable("ModulsCours");
                });

            modelBuilder.Entity("EFCoreToDo.Models.ModulsTeacher", b =>
                {
                    b.Property<int>("Id_Teacher");

                    b.Property<int>("ModuleId");

                    b.HasKey("Id_Teacher", "ModuleId");

                    b.HasIndex("Id_Teacher");

                    b.HasIndex("ModuleId");

                    b.ToTable("ModulsTeacher");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Publication_Date");

                    b.Property<string>("Title");

                    b.Property<int?>("UsersCIN");

                    b.HasKey("SubjectId");

                    b.HasIndex("UsersCIN");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Test", b =>
                {
                    b.Property<int>("idTest")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<string>("nom");

                    b.HasKey("idTest");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("EFCoreToDo.Models.User", b =>
                {
                    b.Property<int>("CIN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("E_mail")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("CIN");

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("EFCoreToDo.ToDoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Parent", b =>
                {
                    b.HasBaseType("EFCoreToDo.Models.User");

                    b.Property<string>("Job");

                    b.ToTable("Parent");

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Student", b =>
                {
                    b.HasBaseType("EFCoreToDo.Models.User");

                    b.Property<string>("SecretCode");

                    b.Property<int?>("classs1ClasssId");

                    b.HasIndex("classs1ClasssId");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Teacher", b =>
                {
                    b.HasBaseType("EFCoreToDo.Models.User");

                    b.Property<string>("Grade");

                    b.Property<int?>("ModuleId");

                    b.Property<int>("ServiceCode");

                    b.HasIndex("ModuleId");

                    b.ToTable("Teacher");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Comment", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Subject", "Subjects")
                        .WithMany("Comments")
                        .HasForeignKey("SubjectsSubjectId");

                    b.HasOne("EFCoreToDo.Models.User", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UsersCIN");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Homework", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Module", "Modulee")
                        .WithMany("Homeworks")
                        .HasForeignKey("ModuleeModuleId");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Mark", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Module", "Modulee")
                        .WithMany("Marks")
                        .HasForeignKey("ModuleeModuleId");

                    b.HasOne("EFCoreToDo.Models.Student", "sutdents")
                        .WithMany("Marks")
                        .HasForeignKey("sutdentsCIN");
                });

            modelBuilder.Entity("EFCoreToDo.Models.ModulsClass", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Classs", "Classss")
                        .WithMany("ModulsClasss")
                        .HasForeignKey("ClasssId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreToDo.Models.Module", "Modulee")
                        .WithMany("ModulsClasss")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreToDo.Models.ModulsCours", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Module", "Modulee")
                        .WithMany("ModulsCoursss")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreToDo.Models.Courss", "Coursss")
                        .WithMany("ModulsCoursss")
                        .HasForeignKey("id_cours")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreToDo.Models.ModulsTeacher", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Teacher", "Teachers")
                        .WithMany("ModulsTeachers")
                        .HasForeignKey("Id_Teacher")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreToDo.Models.Module", "Modulee")
                        .WithMany("ModulsTeachers")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreToDo.Models.Subject", b =>
                {
                    b.HasOne("EFCoreToDo.Models.User", "Users")
                        .WithMany("Subjects")
                        .HasForeignKey("UsersCIN");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Student", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Classs", "classs1")
                        .WithMany("Students")
                        .HasForeignKey("classs1ClasssId");
                });

            modelBuilder.Entity("EFCoreToDo.Models.Teacher", b =>
                {
                    b.HasOne("EFCoreToDo.Models.Module")
                        .WithMany("Teachers")
                        .HasForeignKey("ModuleId");
                });
        }
    }
}
