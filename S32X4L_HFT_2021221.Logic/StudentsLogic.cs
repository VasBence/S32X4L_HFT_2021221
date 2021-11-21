using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;
using S32X4L_HFT_2021221.Data;

namespace S32X4L_HFT_2021221.Logic
{
    public interface IStudentsLogic
    {
        void CreateStudent(Students students);
        void DeleteStudent(string id);
        IQueryable<Students> ReadAll();
        Students ReadOneStudent(string id);
        void UpdateStudentAge(string id, int age);
        void UpdateStudentName(string id, string name);
    }

    public class StudentsLogic : IStudentsLogic
    {
        IStudentsRepository studentsRepository;

        //CRUD METHODS
        public StudentsLogic(IStudentsRepository repo)
        {
            studentsRepository = repo;
        }
        public void CreateStudent(Students students)
        {
            studentsRepository.Create(students);
        }
        public Students ReadOneStudent(string id)
        {
            return studentsRepository.ReadOne(id);
        }
        public IQueryable<Students> ReadAll()
        {
            return studentsRepository.GetAll();
        }
        public void DeleteStudent(string id)
        {
            if (id.Length != 6)
            {
                throw new Exception("The Neptun code should be 6 characters long! :C ");
            }
            else
            studentsRepository.Delete(id);
        }
        public void UpdateStudentAge(string id, int age)
        {
            studentsRepository.UpdateAge(id, age);
        }
        public void UpdateStudentName(string id, string name)
        {
            studentsRepository.UpdateName(id, name);
        }



        //NONCRUD
        public IQueryable<MaxCreditStudentFromAllCourses> GetMaxCreditStudent()
        {
            var repoRead = studentsRepository.GetAll();

            var students2 =( from x in repoRead

                            orderby x.AcquiredCredtis descending


                            select new MaxCreditStudentFromAllCourses
                            {
                                NAME = x.Name,
                                CREDITS = x.AcquiredCredtis
                            }).Take(1);
                           




            return students2;
        } // JÓ


    }
}
