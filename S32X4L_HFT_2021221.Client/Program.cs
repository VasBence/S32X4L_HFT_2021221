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

            StudentsRepository tan = new StudentsRepository();
           
            Courses courses = new Courses();
            CoursesLogic coursesLogic = new CoursesLogic();

            tan.UpdateAge("S32X4L", 15);
            co.ReadOne(courses.CourseID =1);
       
            foreach (Students student in coursesLogic.GetAllStudents())
                Console.WriteLine(student.Name);
            ;


           

                   
            Console.ReadKey();

        }
    }
}
