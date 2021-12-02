using Microsoft.AspNetCore.Mvc;
using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace S32X4L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICoursesLogic coursesLogic;
        IStudentsLogic studentsLogic;
        ISubjectsLogic subjectsLogic;
        ITeacherLogic teacherLogic;

        public StatController(ICoursesLogic coursesLogic, IStudentsLogic studentsLogic, ISubjectsLogic subjectsLogic, ITeacherLogic teacherLogic)
        {
            this.coursesLogic = coursesLogic;
            this.studentsLogic = studentsLogic;
            this.subjectsLogic = subjectsLogic;
            this.teacherLogic = teacherLogic;
        }

        [HttpGet]
        public IEnumerable<TeacherCourses> HeldCourses()
        {
            return coursesLogic.HeldCoursesByTeachers();
        }

        [HttpGet]
        public IEnumerable<CoursesCountFromSubjects> GetCoursesFromSubjects()
        {
            return subjectsLogic.GetCoursesFromSubjects();
        }
        [HttpGet]
        public IEnumerable<string> GetMaxCreditStudent()
        {
            return studentsLogic.GetMaxCreditStudent();
        }
        [HttpGet]
        public IEnumerable<GetEachStudentFor> GetEachStudentForEachCoursesbyTeachers()
        {
            return studentsLogic.SortStudentsWithTheirCourses();
        }
        [HttpGet]
        public IEnumerable<CourseCredit> GetCreditPerCourses()
        {
            return coursesLogic.GetCreditPerCourses();
        }
        [HttpGet]
        public IEnumerable<StudentsWithTheLongestNameByEachCourse> StudentsWithTheLongestNameByEachCourse()
        {
            return studentsLogic.StudentsNameSortedByLengthDescByCourses();
        }

        [HttpGet]
        public IEnumerable<TeacherCourses>HeldCoursesByTeachers()
        {
            return coursesLogic.HeldCoursesByTeachers();
        }
    }
}
