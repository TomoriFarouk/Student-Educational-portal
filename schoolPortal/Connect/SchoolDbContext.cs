using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using schoolPortal.Models;

namespace schoolPortal.Connect
{
    public class SchoolDbContext : DbContext
    {        
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Courses>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<StudentCourses>()
                .HasKey(x => new { x.StudentId, x.CoursesId });
            modelBuilder.Entity<StudentCourses>()
                .HasOne(x => x.Student)
                .WithMany(m => m.Courses)
                .HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<StudentCourses>()
                .HasOne(x => x.Courses)
                .WithMany(e => e.Students)
                .HasForeignKey(x => x.CoursesId);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<StudentCourses> Studentcourse { get; set; }
    }
}
