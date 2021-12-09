using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S32X4L_HFT_2021221.Logic
{
    public interface ISubjectsLogic
    {
        void CreateSubject(Subjects subject);
        void DeleteSubject(int id);
        IQueryable<Subjects> ReadAllSubjects();
        Subjects ReadOneSubject(int id);

        void UpdateSubjectProps(Subjects subjects);

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
      
        public IQueryable<Subjects> ReadAllSubjects()
        {
            return subjectsRepo.GetAll();
        }
        public Subjects ReadOneSubject(int id)
        {
            if (id == 0 || id > subjectsRepo.GetAll().Count())
            {
                throw new ArgumentOutOfRangeException();

            }
            return subjectsRepo.ReadOne(id);
        }
        public void DeleteSubject(int id)
        {
            if (id == 0 || id > subjectsRepo.GetAll().Count())
            {
                throw new ArgumentOutOfRangeException();

            }
            else subjectsRepo.Delete(id);       
         
        }
        public void UpdateSubjectProps(Subjects subjects)
        {
            subjectsRepo.UpdateSubjectProps(subjects);
        }


    }
}
