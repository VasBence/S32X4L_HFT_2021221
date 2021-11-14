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
            CoursesRepository courses = new CoursesRepository(dbcontext);
           
            
            CoursesLogic coursesLogic = new CoursesLogic();

            tan.UpdateAge("S32X4L", 15);
            var Readall = tan.GetAll();
            var readallcourses = courses.GetAll();
            ;
            


           

                   
            Console.ReadKey();

        }
    }
}
