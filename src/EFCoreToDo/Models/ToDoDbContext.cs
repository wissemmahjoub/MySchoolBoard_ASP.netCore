
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Linq;

namespace EFCoreToDo.Models
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Classs> Classs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Courss> Courss { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }



        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasPostgresExtension("uuid-ossp");

            //************** class d'association ModulsCours *******
            builder.Entity<ModulsCours>()
           .HasKey(t => new { t.id_cours, t.ModuleId });

            builder.Entity<ModulsCours>()
                .HasOne(pt => pt.Coursss)
                .WithMany(p => p.ModulsCoursss)
                .HasForeignKey(pt => pt.id_cours);

            builder.Entity<ModulsCours>()
                .HasOne(pt => pt.Modulee)
                .WithMany(t => t.ModulsCoursss)
                .HasForeignKey(pt => pt.ModuleId);

            //*******************************************


            //************** class d'association ModulsClass *******
            builder.Entity<ModulsClass>()
           .HasKey(t => new { t.ClasssId, t.ModuleId });

            builder.Entity<ModulsClass>()
                .HasOne(pt => pt.Classss)
                .WithMany(p => p.ModulsClasss)
                .HasForeignKey(pt => pt.ClasssId);

            builder.Entity<ModulsClass>()
                .HasOne(pt => pt.Modulee)
                .WithMany(t => t.ModulsClasss)
                .HasForeignKey(pt => pt.ModuleId);

            //*******************************************

            //************** class d'association ModulsTeacher *******
            builder.Entity<ModulsTeacher>()
           .HasKey(t => new { t.Id_Teacher, t.ModuleId });

            builder.Entity<ModulsTeacher>()
                .HasOne(pt => pt.Teachers)
                .WithMany(p => p.ModulsTeachers)
                .HasForeignKey(pt => pt.Id_Teacher);

            builder.Entity<ModulsTeacher>()
                .HasOne(pt => pt.Modulee)
                .WithMany(t => t.ModulsTeachers)
                .HasForeignKey(pt => pt.ModuleId);

            // //********************************************

            builder.Entity<Mark>()
              .HasOne(pt => pt.sutdents)
              .WithMany(t => t.Marks);








        }

        internal void PopulateDatabase()
        {
            if (!ToDoItems.Any())
            {
                ToDoItems.Add(new ToDoItem { Text = "First ToDo" });
                ToDoItems.Add(new ToDoItem { Text = "Second ToDo" });
                ToDoItems.Add(new ToDoItem { Text = "Third ToDo" });
                SaveChanges();
            }
        }
    }
}
