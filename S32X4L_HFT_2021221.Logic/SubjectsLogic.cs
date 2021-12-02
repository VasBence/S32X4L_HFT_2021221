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
        
        void UpdateSubjectProps(Subjects subjects);

        public IEnumerable<CoursesCountFromSubjects> GetCoursesFromSubjects();
    }

    public class SubjectsLogic : ISubjectsLogic
    {
        ISubjectsRepository subjectsRepo;

        public SubjectsLogic(ISubjectsRepository repo)
        {
            subjectsRepo = repo;
        }


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
        public void UpdateSubjectProps(Subjects subjects)
        {
            subjectsRepo.UpdateSubjectProps(subjects);
        }
       

 
        public IEnumerable<CoursesCountFromSubjects> GetCoursesFromSubjects() 
        {
            var readedRepo = subjectsRepo.GetAll();
            var coursescount = readedRepo.Where(x => x.SubjectCourses.Count != 0).Select(x => new CoursesCountFromSubjects
            {
                COUNT = x.SubjectCourses.Count,
                SUBJECT = x.Name
            }); 
               
            

           
                               
            return coursescount;
        } 

        
    }
}
