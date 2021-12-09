using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        UniDbContext db;
        public TeacherRepository(UniDbContext db)
        {
            this.db = new UniDbContext();
        }
        public void Create(Teacher teacher)
        {
            db.teacher.Add(teacher);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(ReadOne(id));
            db.SaveChanges();
        }
        public Teacher ReadOne(int id)
        {
            return db.teacher.Find(id);

        }
        public IQueryable<Teacher> GetAll()
        {
            return db.teacher;
        }


        public void UpdateProps(Teacher teacher)
        {
            var oldTeacher = ReadOne(teacher.TeacherID);
            oldTeacher.Name = teacher.Name;
            oldTeacher.Age = teacher.Age;

            db.SaveChanges();
        }
    }
}
