using S32X4L_HFT_2021221.Repository;
using System.Collections.Generic;
using S32X4L_HFT_2021221.Models;
using System;
using System.Linq;

namespace S32X4L_HFT_2021221.Logic
{
    public interface ICoursesLogic
    {
        public void ChangeTeacherName(int id, string name);
        public IList<Courses> GetAllCourses();
        public void DeleteCourse(int id);
        public Courses ReadOneCourse(int id);


    }

    public class CoursesLogic : ICoursesLogic
    {

        ICoursesRepository courseRepo;
        public CoursesLogic(ICoursesRepository repo)
        {
            courseRepo = repo;
        }
        public CoursesLogic()
        {

        }

        // CRUD METHODS
        public void CreateCourse(Courses course)
        {
            courseRepo.Create(course);
        }
        public Courses ReadOneCourse(int id)
        {
            return courseRepo.ReadOne(id);
        }
        public IList<Courses> GetAllCourses()
        {
            var courses = courseRepo.ReadAll();

            return courses;
        }
        public void DeleteCourse(int id)
        {
            courseRepo.Delete(id);
        }
        public void ChangeTeacherName(int id, string name)
        {
            courseRepo.UpdateTeacherName(id, name);
        }

        // NON-CRUD METH
           
        public IEnumerable<Students> GetAllStudents()
        {
            var repoRead = courseRepo.ReadAll();
            var students = repoRead.SelectMany(x => x.Students).Distinct().ToList();
            return students;
             
        }

    }
}
