using NUnit.Framework;
using System;
using S32X4L_HFT_2021221.Repository;
using Moq;
using S32X4L_HFT_2021221.Models;
using System.Linq;
using System.Collections.Generic;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Data;

namespace S32X4L_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        public CoursesLogic coursesLogic { get; set; }
        public StudentsLogic studentsLogic { get; set; }
        public SubjectsLogic subjectsLogic { get; set; }
        public TeacherLogic teacherLogic { get; set; }

        public CoursesCountFromSubjects coursesCountFrom { get; set; }

        public MaxCreditStudentFromAllCourses maxCreditStudentFromAllCourses { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<ICoursesRepository> mockedCoursesRepo = new Mock<ICoursesRepository>();
            Mock<ISubjectsRepository> mockedSubjectsRepo = new Mock<ISubjectsRepository>();
            Mock<IStudentsRepository> mockedStudentsRepo = new Mock<IStudentsRepository>();
            Mock<ITeacherRepository> mockedTeacherRepo = new Mock<ITeacherRepository>();


            mockedCoursesRepo.Setup(x => x.ReadOne(It.IsAny<int>())).Returns(
                new Courses()
                {
                    CourseID = 1,
                    CourseName = "hftcourse2",
                    SubjectID = 1,
                    TeacherID = 1


                }); ;
            mockedTeacherRepo.Setup(x => x.ReadOne(It.IsAny<int>())).Returns(
               new Teacher()
               {
                   TeacherID = 1,
                   Age = 20,
                   Name = "Kovács András"

               });

            mockedStudentsRepo.Setup(x => x.ReadOne(It.IsAny<string>())).Returns(
              new Students()
              {
                  NeptunCode = "IMGAY2",
                  Name = "FERENC2",
                  Age = 22,
                  JoinedCourseID = 2,
                  AcquiredCredtis = 210

              });

            mockedSubjectsRepo.Setup(x => x.ReadOne(It.IsAny<int>())).Returns(
             new Subjects()
             {
                 SubjectID = 1,
                 Name = "Analízis 2",
                 Credit = 6

             });

            mockedCoursesRepo.Setup(x => x.GetAll()).Returns(this.FakeCoursesObjects);
            mockedSubjectsRepo.Setup(x => x.GetAll()).Returns(this.FakeSubjectsObjects);
            mockedStudentsRepo.Setup(x => x.GetAll()).Returns(this.FakeStudentsObjects);
            mockedTeacherRepo.Setup(x => x.GetAll()).Returns(this.FakeTeacherObjects);

            this.coursesLogic = new CoursesLogic(mockedCoursesRepo.Object);
            this.subjectsLogic = new SubjectsLogic(mockedSubjectsRepo.Object);
            this.studentsLogic = new StudentsLogic(mockedStudentsRepo.Object);
            this.teacherLogic = new TeacherLogic(mockedTeacherRepo.Object);



        }

        [Test]
        [TestCase("Kovács András")]
        public void Test_FirstTeacher_IsRight_InDatabase(string name)
        {
            var firstteacher = teacherLogic.ReadOneTeacher(1);

            Assert.That(firstteacher.Name, Is.EqualTo(name));
        } //1
        [Test]
        
        [TestCase("asdasdasd")]
    
        public void Delete_Student_Throws_Exception(string id)
        {
       
            Assert.That(() => studentsLogic.DeleteStudent(id), Throws.TypeOf<Exception>());

        }        //2

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        
        public void Test_TeacherCourses_Count_IsRight(int count)
        {

            Assert.That(teacherLogic.TeacherCoursesCount(count).Count(), Is.EqualTo(1));
        }      //3

        [Test]
        
        public void GetAll_Method_Is_Reading_All_Objects()
        {

            Assert.That(studentsLogic.ReadAll().Count() == 4);
        }           //4

        [Test]    
        public void AgeUpdate_AtStudents_IsWorking()
        {
  
           Assert.That(this.studentsLogic.GetMaxCreditStudent().ToList().Count, Is.EqualTo(1));        
        }                   //5

        [Test]
        [TestCase(1,7)]
      
        public void Update_Credit_For_Subjects(int id, int credit)
        {
           

            Assert.That(()=> subjectsLogic.UpdateCredit(id,credit), Throws.TypeOf<ArgumentException>());
        }   //6

        [Test]
        public void Read_One_Subject_IsWorking()
        {
            Assert.That(subjectsLogic.ReadOneSubject(1).SubjectID, Is.EqualTo(1));
            Assert.That(subjectsLogic.ReadOneSubject(1).Credit, Is.EqualTo(6));
        }

        [Test]
        public void Teacher_Courses_Count()
        {
            var readed = subjectsLogic.GetCoursesCountFromSubjects();
            List<CoursesCountFromSubjects> subjects = new List<CoursesCountFromSubjects>();
            foreach (var subject in readed)
            {
                subjects.Add(subject);   
            }

            Assert.That(subjects.Count(), Is.EqualTo(0));

        }




        private IQueryable<Courses> FakeCoursesObjects()
        {
            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 20, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 23, Name = "Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 50, Name = "Vajda István" };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse2", SubjectID = hft.SubjectID, TeacherID = teacher.TeacherID };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse1", SubjectID = hft.SubjectID, TeacherID = teacher2.TeacherID };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };

            Students vassbenceanal2 = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, AcquiredCredtis = 30 };
            Students vassbencehft = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 19, JoinedCourseID = hftcourse1.CourseID, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "IMGAY", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 20 };
            Students ferike2 = new Students() { NeptunCode = "IMGAY2", Name = "FERENC2", Age = 22, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 210 };


            List<Courses> courses = new List<Courses>();
            courses.Add(hftcourse1);
            courses.Add(hftcourse2);
            courses.Add(anal2course1);
            courses.Add(anal2course2);

            return courses.AsQueryable();
        }
        private IQueryable<Teacher> FakeTeacherObjects()
        {
            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 20, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 23, Name = "Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 50, Name = "Vajda István" };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse2", SubjectID = hft.SubjectID, TeacherID = teacher.TeacherID };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse1", SubjectID = hft.SubjectID, TeacherID = teacher2.TeacherID };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };


            Students vassbenceanal2 = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, AcquiredCredtis = 30 };
            Students vassbencehft = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 19, JoinedCourseID = hftcourse1.CourseID, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "IMGAY", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 20 };
            Students ferike2 = new Students() { NeptunCode = "IMGAY2", Name = "FERENC2", Age = 22, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 210 };

            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(teacher);
            teachers.Add(teacher2);
            teachers.Add(teacher3);
            return teachers.AsQueryable();
        }
        private IQueryable<Subjects> FakeSubjectsObjects()
        {
            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 20, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 23, Name = "Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 50, Name = "Vajda István" };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse2", SubjectID = hft.SubjectID, TeacherID = teacher.TeacherID };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse1", SubjectID = hft.SubjectID, TeacherID = teacher2.TeacherID };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };

            Students vassbenceanal2 = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, AcquiredCredtis = 30 };
            Students vassbencehft = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 19, JoinedCourseID = hftcourse1.CourseID, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "IMGAY", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 20 };
            Students ferike2 = new Students() { NeptunCode = "IMGAY2", Name = "FERENC2", Age = 22, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 210 };


            List<Subjects> subjects = new List<Subjects>();
            subjects.Add(anal2);
            subjects.Add(hft);


            return subjects.AsQueryable();
        }
        private IQueryable<Students> FakeStudentsObjects()
        {
            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 20, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 23, Name = "Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 50, Name = "Vajda István" };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse2", SubjectID = hft.SubjectID, TeacherID = teacher.TeacherID };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse1", SubjectID = hft.SubjectID, TeacherID = teacher2.TeacherID };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, TeacherID = teacher3.TeacherID };


            Students vassbenceanal2 = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, AcquiredCredtis = 30 };
            Students vassbencehft = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 19, JoinedCourseID = hftcourse1.CourseID, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "IMGAY", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 20 };
            Students ferike2 = new Students() { NeptunCode = "IMGAY2", Name = "FERENC2", Age = 22, JoinedCourseID = hftcourse2.CourseID, AcquiredCredtis = 210 };

            List<Students> students = new List<Students>();
            students.Add(vassbenceanal2);
            students.Add(vassbencehft);
            students.Add(ferike);
            students.Add(ferike2);

            return students.AsQueryable();
        }
    }
}
