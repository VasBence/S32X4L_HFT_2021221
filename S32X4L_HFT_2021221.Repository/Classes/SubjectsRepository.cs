using System;
using System.Linq;
using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;

namespace S32X4L_HFT_2021221.Repository
{
    public class SubjectsRepository : ISubjectsRepository
    {
        UniDbContext db;
        public SubjectsRepository(UniDbContext db)
        {
            this.db = db;
        }
        public void Create(Subjects targy)
        {
            db.subjects.Add(targy);
            db.SaveChanges();
        }
        public Subjects ReadOne(int id)
        {
            return db.subjects.FirstOrDefault(x => x.SubjectID == id);
        }
        public IQueryable<Subjects> GetAll()
        {
            return db.subjects;
        }
        public void Delete(int id)
        {
            db.Remove(ReadOne(id));
            db.SaveChanges();
        }
        public void UpdateSubjectProps(Subjects subjects)
        {
            var oldSubject = ReadOne(subjects.SubjectID);
            oldSubject.Name = subjects.Name;
            oldSubject.Credit = oldSubject.Credit;
            

            db.SaveChanges();
        }
       
    }
}
