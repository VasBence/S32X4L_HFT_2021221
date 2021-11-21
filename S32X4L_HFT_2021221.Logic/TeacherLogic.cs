using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Repository;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Data;

namespace S32X4L_HFT_2021221.Logic
{
    public class TeacherLogic
    {
        ITeacherRepository TeacherRepository;
        public TeacherLogic(ITeacherRepository repo)
        {
            TeacherRepository = repo;
        }
        public void CreateTeacher(Teacher teacher)
        {
            TeacherRepository.Create(teacher);
        }
        public Teacher ReadOneTeacher(int id)
        {
            return TeacherRepository.ReadOne(id);
        }
        public IQueryable<Teacher> ReadAll()
        {
            return TeacherRepository.GetAll();
        }
        public void DeleteStudent(string id)
        {
            TeacherRepository.Delete(id);
        }
        public void UpdateTeacherAge(int id, int age)
        {
            TeacherRepository.UpdateAge(id, age);
        }
        public void UpdateTeacherName(int id, string name)
        {
            TeacherRepository.UpdateName(id, name);
        }

        public IEnumerable<TeacherCoursesCount> TeacherCoursesCount(int id) //JÓ
        {
  
            var courses2 = from x in TeacherRepository.GetAll().Where(X=>X.TeacherID == id)
                           where x.HoldedCourses != null

                           select new TeacherCoursesCount
                           {
                               NAME = x.Name,
                               COUNT = x.HoldedCourses.Count
                           };
            return courses2;
        }

    }
}
