using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using System;
using System.Linq;
using S32X4L_HFT_2021221.Repository;
using S32X4L_HFT_2021221.Logic;


namespace S32X4L_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {

            UniDbContext dbcontext = new UniDbContext();

            StudentsRepository tan = new StudentsRepository(dbcontext);
            StudentsLogic studentsLogic = new StudentsLogic(tan);

            SubjectsRepository subjectsRepo = new SubjectsRepository(dbcontext);
            SubjectsLogic subjectsLogic = new SubjectsLogic(subjectsRepo);


            CoursesRepository courses = new CoursesRepository(dbcontext);
            CoursesLogic coursesLogic = new CoursesLogic(courses);

            TeacherRepository teacher = new TeacherRepository(dbcontext);
            TeacherLogic teacherLogic = new TeacherLogic(teacher);


            tan.UpdateAge("S32X4L", 15);
            var Readall = tan.GetAll();
            var onecoursefromrepo = courses.ReadOne(1);
            
            var onecourse = coursesLogic.ReadOneCourse(1);
            var readallcourses = coursesLogic.GetAllCourses();

            var studentreporeadone = tan.ReadOne("S32X4L");
            var readallStudents = studentsLogic.ReadAllStudents();
            var readoneStudent = studentsLogic.ReadOneStudent("S32X4L");
            
       
            var getcoursescountfromsubjects = subjectsLogic.GetCoursesCountFromSubjects(); //JÓ
           
            var coursesteacher = teacherLogic.TeacherCoursesCount(1); //JÓ

          
            var studentsds = studentsLogic.GetMaxCreditStudent(); //JÓ

            var hftcourses = coursesLogic.GetCourses("Haladó Fejlesztési Technikák"); //JÓ

            var coursehigherthan = coursesLogic.GetCoursesHigherThanCredit(5); //JÓ
            
            ;
            


           

                   
            Console.ReadKey();

        }
    }
}
