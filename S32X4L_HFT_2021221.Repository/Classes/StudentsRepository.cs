using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        UniDbContext db;
        public StudentsRepository(UniDbContext db)
        {
            this.db = new UniDbContext();
        }
        public void Create(Students student)
        {
            db.students.Add(student);
            db.SaveChanges();
        }
        public void Delete(string id)
        {
            db.Remove(ReadOne(id));
            db.SaveChanges();
        }
        public Students ReadOne(string id)
        {
            return db.students.Find(id);

        }
        public IQueryable<Students> GetAll()
        {
            return db.students;
        }

        public void UpdateStudentProps(Students students)
        {
            var oldStudent = ReadOne(students.NeptunCode);
            oldStudent.Name = students.Name;
            oldStudent.Age = students.Age;
            oldStudent.AcquiredCredtis = students.AcquiredCredtis;
            db.SaveChanges();

        }



    }
}
