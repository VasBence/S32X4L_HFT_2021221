using Microsoft.EntityFrameworkCore;
using S32X4L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Data
{
    public class UniDbContext : DbContext
    {
        public virtual DbSet<Students> students { get; set; }
        public virtual DbSet<Subjects> subjects { get; set; }
        public virtual DbSet<Courses> courses { get; set; }

        public UniDbContext()
        {
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subjects>(entity =>
            {
                entity
                .HasMany(subjects => subjects.SubjectCourses)
                .WithOne(courses => courses.Subjects)
                .HasForeignKey(subjects => subjects.CourseID)
                .OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity
                .HasOne(students => students.JoinedCourse)
                .WithMany(courses => courses.Students)
                .HasForeignKey(students => students.JoinedCourseID);
                


            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity
                .HasMany(courses => courses.Students)
                .WithOne(students => students.JoinedCourse);
                
                

                entity
                .HasOne(courses => courses.Subjects)
                .WithMany(subjects => subjects.SubjectCourses)
                .HasForeignKey(courses => courses.SubjectID)
                .OnDelete(DeleteBehavior.Restrict);

            });

            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 6 };

            Courses htcourse1 = new Courses() { CourseID = 1, Teacher = "Sipos Miklós", SubjectID = 2 };
            Courses hftcourse2 = new Courses() { CourseID = 2, Teacher = "Kovács András", SubjectID = 2 };

            Students vassbence = new Students() { NeptunCode = "S32X4L", Name = "Vass Bence", Age = 19, JoinedCourseID = 1};




            modelBuilder.Entity<Courses>().HasData(htcourse1, hftcourse2);
            modelBuilder.Entity<Subjects>().HasData(anal2, hft);
            modelBuilder.Entity<Students>().HasData(vassbence);

            



        }


    }
}
