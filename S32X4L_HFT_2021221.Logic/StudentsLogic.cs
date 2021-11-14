using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;

namespace S32X4L_HFT_2021221.Logic
{
    public class StudentsLogic
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
        public List<Students> ReadAll()
        {
            return studentsRepository.ReadAll().ToList();
        }
        public void DeleteStudent(string id)
        {
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
    }
}
