using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
       protected UniDbContext db;
        public CoursesRepository(UniDbContext db)
        {
           this.db = db;

        }

        public void Create(Courses course)
        {
            db.courses.Add(course);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(id);
            db.SaveChanges();
        }

        public Courses ReadOne(int id)
        {
            return db.courses.SingleOrDefault(x => x.CourseID == id);

        }

        public IQueryable<Courses> GetAll()
        {
            return db.courses;
        }

        public void UpdateTeacherName(int id, string name)
        {
            var oldCourse = ReadOne(id);
            oldCourse.Teacher = name;
            db.SaveChanges();
        }
    }
}
