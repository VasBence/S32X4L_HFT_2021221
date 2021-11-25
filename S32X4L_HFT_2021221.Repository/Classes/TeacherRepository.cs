using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            db.Remove(id);
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
        public void UpdateAge(int id, int Age)
        {
            var oldTeacher = ReadOne(id);
            ;

            oldTeacher.Age = Age;

            db.SaveChanges();

        }
        public void UpdateName(int id, string Name)
        {
            var oldTeacher = ReadOne(id);
            oldTeacher.Name = Name;
        }
    }
}
