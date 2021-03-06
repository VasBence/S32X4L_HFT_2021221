using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S32X4L_HFT_2021221.Logic
{
    public interface IStudentsLogic
    {
        void CreateStudent(Students students);
        void DeleteStudent(string id);
        IQueryable<Students> ReadAllStudents();
        Students ReadOneStudent(string id);

        void UpdateStudentProps(Students students);

        public IEnumerable<string> GetMaxCreditStudent();

        public IEnumerable<GetEachStudentFor> SortStudentsWithTheirCourses();

        public IEnumerable<StudentsWithTheLongestNameByEachCourse> StudentsNameSortedByLengthDescByCourses();

        public IEnumerable<StudentsOnCoursesCount> StudentsOnCoursesCount();

    }

    public class StudentsLogic : IStudentsLogic
    {
        IStudentsRepository studentsRepository;



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
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else return studentsRepository.ReadOne(id);
        }
        public IQueryable<Students> ReadAllStudents()
        {
            return studentsRepository.GetAll();
        }
        public void DeleteStudent(string id)
        {
            if (id == null|| id =="")
            {
                throw new ArgumentNullException();
            }
            else studentsRepository.Delete(id);
        }

        public void UpdateStudentProps(Students students)
        {
            studentsRepository.UpdateStudentProps(students);
        }




        public IEnumerable<string> GetMaxCreditStudent()
        {
            var repoRead = studentsRepository.GetAll();

            var students2 = (from x in repoRead

                             orderby x.AcquiredCredtis descending

                             select x.Name).ToList().Take(1);

            return students2;
        }



        public IEnumerable<GetEachStudentFor> SortStudentsWithTheirCourses()
        {

            var oder = from x in studentsRepository.GetAll()
                       where x.JoinedCourseID == x.JoinedCourse.TeacherID
                       select new GetEachStudentFor
                       {
                           StudentName = x.Name,
                           TeacherName = x.JoinedCourse.Teacher.Name
                       };

            return oder;
        }


        public IEnumerable<StudentsWithTheLongestNameByEachCourse> StudentsNameSortedByLengthDescByCourses()
        {

            var longest = (from x in studentsRepository.GetAll()
                           where x.JoinedCourseID == x.JoinedCourse.CourseID
                           orderby x.Name.Length descending
                           select new StudentsWithTheLongestNameByEachCourse
                           {
                               CourseName = x.JoinedCourse.CourseName,
                               StudentName = x.Name
                           });

            return longest;


        }

        public IEnumerable<StudentsOnCoursesCount> StudentsOnCoursesCount()
        {
            var joined = from x in studentsRepository.GetAll()
                         group x by x.JoinedCourse.CourseName into g
                         select new StudentsOnCoursesCount
                         {
                             Name = g.Key,
                             Count = g.Count()
                         };

            return joined;
        }
    }




}
