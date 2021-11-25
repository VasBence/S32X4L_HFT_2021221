using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;

namespace S32X4L_HFT_2021221.Logic
{
    public interface ISubjectsLogic
    {
        void CreateSubject(Subjects subject);
        void DeleteSubject(int id);
        IQueryable<Subjects> ReadAllSubjects();
        Subjects ReadOneSubject(int id);
        void UpdateCredit(int id, int credit);
        void UpdateSubjectName(int id, string name);
    }

    public class SubjectsLogic : ISubjectsLogic
    {
        ISubjectsRepository subjectsRepo;

        public SubjectsLogic(ISubjectsRepository repo)
        {
            subjectsRepo = repo;
        }

        //CRUD METHODS
        public void CreateSubject(Subjects subject)
        {
            subjectsRepo.Create(subject);
        }
        public Subjects ReadOneSubject(int id)
        {
            return subjectsRepo.ReadOne(id);
        }
        public IQueryable<Subjects> ReadAllSubjects()
        {
            return subjectsRepo.GetAll();
        }
        public void DeleteSubject(int id)
        {
            subjectsRepo.Delete(id);
        }
        public void UpdateSubjectName(int id, string name)
        {
            subjectsRepo.UpdateSubjectName(id, name);
        }
        public void UpdateCredit(int id, int credit)
        {
            if (credit >6)
            {
                throw new ArgumentException("Credit need to be smaller or equal to 6");

            }
            else subjectsRepo.UpdateCredit(id, credit);

        }

        //non CRUD
        public IEnumerable<CoursesCountFromSubjects> GetCoursesCountFromSubjects()
        {
            var readedRepo = subjectsRepo.GetAll();
            var coursescount = readedRepo.Where(x => x.SubjectCourses.Count != 0).Select(x => new CoursesCountFromSubjects
            {
                NAME = x.SubjectCourses,
                SUBJECT = x.Name
            }); 
               
            

           
                               
            return coursescount;
        } //JÓ
    }
}
