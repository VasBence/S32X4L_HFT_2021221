using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;

namespace S32X4L_HFT_2021221.Logic
{
    public interface ISubjectsLogic
    {

    }
    public class SubjectsLogic
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
        public void ReadAllSubjects()
        {
            subjectsRepo.ReadAll().ToList();
        }      
        public void Delete(int id)
        {
            subjectsRepo.Delete(id);
        }
        public void UpdateSubjectName(int id, string name)
        {
            subjectsRepo.UpdateSubjectName(id, name);
        }
        public void UpdateCredit(int id, int credit)
        {
            subjectsRepo.UpdateCredit(id, credit);
        }

    }
}
