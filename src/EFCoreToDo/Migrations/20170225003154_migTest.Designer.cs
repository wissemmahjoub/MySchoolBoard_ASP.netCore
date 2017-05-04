using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreToDo.Models;

namespace EFCoreToDo.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20170225003154_migTest")]
    partial class migTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.2");

            modelBuilder.Entity("EFCoreToDo.Models.Test", b =>
                {
                    b.Property<int>("idTest")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<string>("nom");

                    b.HasKey("idTest");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("EFCoreToDo.ToDoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");
                });
        }
    }
}
