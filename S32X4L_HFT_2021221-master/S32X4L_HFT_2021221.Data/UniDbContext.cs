using Microsoft.EntityFrameworkCore;
using S32X4L_HFT_2021221.Models;

namespace S32X4L_HFT_2021221.Data
{
    public class UniDbContext : DbContext
    {
        public virtual DbSet<Students> students { get; set; }
        public virtual DbSet<Subjects> subjects { get; set; }
        public virtual DbSet<Courses> courses { get; set; }
        public virtual DbSet<Teacher> teacher { get; set; }

        public UniDbContext()
        {
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Subjects.mdf; Integrated Security = True");
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
                .OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity
                .HasOne(students => students.JoinedCourse)
                .WithMany(courses => courses.Students)
                .HasForeignKey(students => students.JoinedCourseID)
                .OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity
                .HasMany(courses => courses.Students)
                .WithOne(students => students.JoinedCourse)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(courses => courses.Subjects)
                .WithMany(subjects => subjects.SubjectCourses)
                .HasForeignKey(courses => courses.SubjectID)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(courses => courses.Teacher)
                .WithMany(teacher => teacher.HeldCourses)
                .HasForeignKey(courses => courses.TeacherID)
                .OnDelete(DeleteBehavior.Restrict);

            });

            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 25, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 25, Name = "Sipos Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 47, Name = "Vajda István" };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse1", SubjectID = hft.SubjectID, TeacherID = teacher.TeacherID };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse2", SubjectID = hft.SubjectID, TeacherID = teacher2.TeacherID };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };




            Students bence = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, AcquiredCredtis = 30 };
            Students benceee = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 31, JoinedCourseID = hftcourse1.CourseID, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "12SD23", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 20 };
            Students bogi = new Students() { NeptunCode = "SDA123", Name = "Bogi", Age = 19, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 210 };
            Students lilla = new Students() { NeptunCode = "ASD123", Name = "Lilla", Age = 23, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 200 };
            Students jozsef = new Students() { NeptunCode = "ASD112", Name = "József", Age = 24, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 140 };





            modelBuilder.Entity<Courses>().HasData(hftcourse1, hftcourse2, anal2course1, anal2course2);
            modelBuilder.Entity<Subjects>().HasData(anal2, hft);
            modelBuilder.Entity<Students>().HasData(benceee, ferike, bence, bogi, lilla, jozsef);
            modelBuilder.Entity<Teacher>().HasData(teacher, teacher2, teacher3);





        }


    }
}
