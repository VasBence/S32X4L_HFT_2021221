using S32X4L_HFT_2021221.Repository;
using System.Collections.Generic;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Data;
using System;
using System.Linq;

namespace S32X4L_HFT_2021221.Logic
{
    public interface ICoursesLogic
    {
        
        public IQueryable<Courses> GetAllCourses();
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
        public IQueryable<Courses> GetAllCourses()
        {
            var courses = courseRepo.GetAll();

            return courses;
        }
        public void DeleteCourse(int id)
        {
            courseRepo.Delete(id);
        }
     

        // NON-CRUD METH
           
    
        public IEnumerable<string> GetCourses(string askedsubjectcourses)
        {
            var readedRepo = courseRepo.GetAll();
            var courses = from x in readedRepo                            
                             where x.Subjects.Name == askedsubjectcourses
                             select x.CourseName;

            return courses;
        } //JÓ

        public IEnumerable<CourseHigherThanCredit> GetCoursesHigherThanCredit(int creditthanhigher)
        {
            var readedRepo = courseRepo.GetAll();

            var higher = from x in readedRepo
                         where x.Subjects.Credit >= creditthanhigher
                         select new CourseHigherThanCredit
                         {
                             NAME = x.CourseName,
                             CREDIT = x.Subjects.Credit
                         };
                      
            return higher;

        }

    }
}
