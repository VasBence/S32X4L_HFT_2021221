using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
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
            db.Remove(ReadOne(id));
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
        public void UdpateCourseName(Courses courses)
        {
            var oldCourse = ReadOne(courses.CourseID);
            oldCourse.CourseName = courses.CourseName;

            db.SaveChanges();
        }
    }
}
