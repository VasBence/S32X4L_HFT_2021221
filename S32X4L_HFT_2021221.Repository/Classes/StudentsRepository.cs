using S32X4L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Data;

namespace S32X4L_HFT_2021221.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        UniDbContext db = new UniDbContext();
        public void Create(Students student)
        {
            db.students.Add(student);
            db.SaveChanges();
        }
        public void Delete(string id)
        {
            db.Remove(id);
            db.SaveChanges();
        }
        public Students ReadOne(string id)
        {
            return db.students.Find(id);

        }
        public IQueryable<Students> ReadAll()
        {
            return db.students;
        }
        public void UpdateAge(string neptunCode, int Age)
        {
            var regitanulo = ReadOne(neptunCode);
            ;
         
            regitanulo.Age = Age;
          
            db.SaveChanges();

        }
        public void UpdateName(string neptunCode, string Name)
        {
            var oldStudent = ReadOne(neptunCode);
            oldStudent.Name = Name;
        }

     
    }
}
