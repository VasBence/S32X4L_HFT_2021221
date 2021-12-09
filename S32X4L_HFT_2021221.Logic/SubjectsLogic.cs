using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;
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


    }
}
