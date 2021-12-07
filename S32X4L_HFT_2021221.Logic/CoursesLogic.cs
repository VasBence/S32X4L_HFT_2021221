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

        IQueryable<Courses> GetAllCourses();
        void DeleteCourse(int id);
        Courses ReadOneCourse(int id);
        void CreateCourse(Courses course);

        void UdpateCourseName(Courses courses);

        IEnumerable<TeacherCourses> HeldCoursesByTeachers();
        public IEnumerable<CourseCredit> GetCreditPerCourses();

       

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
        void ICoursesLogic.UdpateCourseName(Courses courses)
        {
            courseRepo.UdpateCourseName(courses);
        }
        public IEnumerable<CourseCredit> GetCreditPerCourses()
        {


            var credit = from x in courseRepo.GetAll()
                         where x.SubjectID == x.Subjects.SubjectID
                         select new CourseCredit
                         {
                             NAME = x.CourseName,
                             CREDIT = x.Subjects.Credit
                         };


            return credit;

        }
        public IEnumerable<TeacherCourses> HeldCoursesByTeachers() 
        {

            var courses2 = (from x in courseRepo.GetAll()
                            where x.TeacherID == x.Teacher.TeacherID
                            select new TeacherCourses
                            {
                                NAME = x.Teacher.Name,
                                CNAME = x.CourseName

                            }).Distinct();



            return courses2;
        }
    }
  

}
