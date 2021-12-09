using Moq;
using NUnit.Framework;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;

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

        public string maxCreditStudentFromAllCourses { get; set; }

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
                  NeptunCode = "ASDASD",
                  Name = "FERENC2",
                  Age = 22,
                  JoinedCourseID = 2,
                  AcquiredCredtis = 210

              });

            mockedSubjectsRepo.Setup(x => x.ReadOne(It.IsAny<int>())).Returns(
             new Subjects()
             {
                 SubjectID = 1,
                 Name = "Analízis2",
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
        }

        [Test]
        public void HeldCoursesByTeachers_method_returns_with_all_values()
        {

            var readed = coursesLogic.HeldCoursesByTeachers();
            List<TeacherCourses> heldcourses = new List<TeacherCourses>();
            foreach (var courses in readed)
            {
                heldcourses.Add(courses);
            }

            Assert.That(heldcourses.Count(), Is.EqualTo(4));

        }

        [Test]
        public void GetCreditPerCourses_returns_right_amount_of_values()
        {
            var readed = coursesLogic.GetCreditPerCourses();
            List<CourseCredit> coursescredit = new List<CourseCredit>();
            foreach (var courses in readed)
            {
                coursescredit.Add(courses);
            }

            Assert.That(coursescredit.Count(), Is.EqualTo(4));

        }

        [Test]
        public void ReadAllStudents_Is_Reading_Every_Objects()
        {

            Assert.That(studentsLogic.ReadAllStudents().Count() == 6);
            ;
        }

        [Test]
        [TestCase(1)]
        public void GetMaxCredit_Count_Is_One(int count)
        {


            Assert.That(studentsLogic.GetMaxCreditStudent().ToList().Count, Is.EqualTo(count));
        }

        [Test]
        [TestCase(1)]

        public void Delete_Subject_not_throws_exception(int id)
        {
            Assert.That(() => subjectsLogic.DeleteSubject(id), Throws.Nothing);
        }

        [Test]
        [TestCase(1)]
        public void Test_ReadOne_Is_Not_Return_With_null(int id)
        {

            Assert.That(subjectsLogic.ReadOneSubject(id), Is.Not.Null);
        }

        [Test]
        public void Read_One_Subject_Is_Reading_Right_Values()
        {
            Assert.That(subjectsLogic.ReadOneSubject(1).SubjectID, Is.EqualTo(1));
            Assert.That(subjectsLogic.ReadOneSubject(1).Credit, Is.EqualTo(6));

        }

        [Test]
        public void ReadOneSubject_Not_Returns_False_Values()
        {
            Assert.That(subjectsLogic.ReadOneSubject(1).SubjectID, Is.Not.EqualTo(2));
            Assert.That(subjectsLogic.ReadOneSubject(1).Credit, Is.Not.EqualTo(7));



        }

        [Test]
        public void ReadAllSubjects_Working()
        {
            var readed = subjectsLogic.ReadAllSubjects();         
            Assert.That(readed.Count(), Is.EqualTo(2));
        }

        [Test]
        public void TestMaxCreditStudent_Returns_Rigth_Value()
        {
            var result = studentsLogic.GetMaxCreditStudent();

            Assert.That(result.ToList()[0], Is.EqualTo("Bogi"));

        }

        private IQueryable<Courses> FakeCoursesObjects()
        {
            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 30, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 30, Name = "Sipos Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 47, Name = "Vajda István", };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse1", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher.TeacherID, Teacher = teacher };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse2", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher2.TeacherID, Teacher = teacher2 };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };

            teacher.HeldCourses.Add(hftcourse1);
            teacher2.HeldCourses.Add(hftcourse2);
            teacher3.HeldCourses.Add(anal2course2);
            teacher3.HeldCourses.Add(anal2course1);

            anal2.SubjectCourses.Add(anal2course1);
            anal2.SubjectCourses.Add(anal2course2);
            hft.SubjectCourses.Add(hftcourse1);
            hft.SubjectCourses.Add(hftcourse2);


            Students bence = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, JoinedCourse = anal2course1, AcquiredCredtis = 30 };
            Students benceee = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 31, JoinedCourseID = hftcourse1.CourseID, JoinedCourse = hftcourse1, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "12SD23", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 20 };
            Students bogi = new Students() { NeptunCode = "SDA123", Name = "Bogi", Age = 19, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 210 };
            Students lilla = new Students() { NeptunCode = "ASD123", Name = "Lilla", Age = 23, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 200 };
            Students jozsef = new Students() { NeptunCode = "ASD112", Name = "József", Age = 24, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 140 };

            hftcourse1.Students.Add(benceee);
            hftcourse2.Students.Add(bogi);
            hftcourse2.Students.Add(lilla);
            hftcourse2.Students.Add(jozsef);
            hftcourse2.Students.Add(ferike);
            anal2course1.Students.Add(bence);





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

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 30, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 30, Name = "Sipos Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 47, Name = "Vajda István", };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse1", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher.TeacherID, Teacher = teacher };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse2", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher2.TeacherID, Teacher = teacher2 };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };

            teacher.HeldCourses.Add(hftcourse1);
            teacher2.HeldCourses.Add(hftcourse2);
            teacher3.HeldCourses.Add(anal2course2);
            teacher3.HeldCourses.Add(anal2course1);

            anal2.SubjectCourses.Add(anal2course1);
            anal2.SubjectCourses.Add(anal2course2);
            hft.SubjectCourses.Add(hftcourse1);
            hft.SubjectCourses.Add(hftcourse2);


            Students bence = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, JoinedCourse = anal2course1, AcquiredCredtis = 30 };
            Students benceee = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 31, JoinedCourseID = hftcourse1.CourseID, JoinedCourse = hftcourse1, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "12SD23", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 20 };
            Students bogi = new Students() { NeptunCode = "SDA123", Name = "Bogi", Age = 19, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 210 };
            Students lilla = new Students() { NeptunCode = "ASD123", Name = "Lilla", Age = 23, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 200 };
            Students jozsef = new Students() { NeptunCode = "ASD112", Name = "József", Age = 24, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 140 };

            hftcourse1.Students.Add(benceee);
            hftcourse2.Students.Add(bogi);
            hftcourse2.Students.Add(lilla);
            hftcourse2.Students.Add(jozsef);
            hftcourse2.Students.Add(ferike);
            anal2course1.Students.Add(bence);


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

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 30, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 30, Name = "Sipos Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 47, Name = "Vajda István", };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse1", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher.TeacherID, Teacher = teacher };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse2", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher2.TeacherID, Teacher = teacher2 };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };

            teacher.HeldCourses.Add(hftcourse1);
            teacher2.HeldCourses.Add(hftcourse2);
            teacher3.HeldCourses.Add(anal2course2);
            teacher3.HeldCourses.Add(anal2course1);

            anal2.SubjectCourses.Add(anal2course1);
            anal2.SubjectCourses.Add(anal2course2);
            hft.SubjectCourses.Add(hftcourse1);
            hft.SubjectCourses.Add(hftcourse2);


            Students bence = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, JoinedCourse = anal2course1, AcquiredCredtis = 30 };
            Students benceee = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 31, JoinedCourseID = hftcourse1.CourseID, JoinedCourse = hftcourse1, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "12SD23", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 20 };
            Students bogi = new Students() { NeptunCode = "SDA123", Name = "Bogi", Age = 19, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 210 };
            Students lilla = new Students() { NeptunCode = "ASD123", Name = "Lilla", Age = 23, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 200 };
            Students jozsef = new Students() { NeptunCode = "ASD112", Name = "József", Age = 24, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 140 };

            hftcourse1.Students.Add(benceee);
            hftcourse2.Students.Add(bogi);
            hftcourse2.Students.Add(lilla);
            hftcourse2.Students.Add(jozsef);
            hftcourse2.Students.Add(ferike);
            anal2course1.Students.Add(bence);




            List<Subjects> subjects = new List<Subjects>();
            subjects.Add(anal2);
            subjects.Add(hft);


            return subjects.AsQueryable();
        }
        private IQueryable<Students> FakeStudentsObjects()
        {
            Subjects anal2 = new Subjects() { SubjectID = 1, Name = "Analízis 2", Credit = 6 };
            Subjects hft = new Subjects() { SubjectID = 2, Name = "Haladó Fejlesztési Technikák", Credit = 3 };

            Teacher teacher = new Teacher() { TeacherID = 1, Age = 30, Name = "Kovács András" };
            Teacher teacher2 = new Teacher() { TeacherID = 2, Age = 30, Name = "Sipos Miklós" };
            Teacher teacher3 = new Teacher() { TeacherID = 3, Age = 47, Name = "Vajda István", };

            Courses hftcourse1 = new Courses() { CourseID = 1, CourseName = "hftcourse1", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher.TeacherID, Teacher = teacher };
            Courses hftcourse2 = new Courses() { CourseID = 2, CourseName = "hftcourse2", SubjectID = hft.SubjectID, Subjects = hft, TeacherID = teacher2.TeacherID, Teacher = teacher2 };
            Courses anal2course1 = new Courses() { CourseID = 3, CourseName = "anal2course1", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };
            Courses anal2course2 = new Courses() { CourseID = 4, CourseName = "anal2course2", SubjectID = anal2.SubjectID, Subjects = anal2, TeacherID = teacher3.TeacherID, Teacher = teacher3 };

            teacher.HeldCourses.Add(hftcourse1);
            teacher2.HeldCourses.Add(hftcourse2);
            teacher3.HeldCourses.Add(anal2course2);
            teacher3.HeldCourses.Add(anal2course1);

            anal2.SubjectCourses.Add(anal2course1);
            anal2.SubjectCourses.Add(anal2course2);
            hft.SubjectCourses.Add(hftcourse1);
            hft.SubjectCourses.Add(hftcourse2);


            Students bence = new Students() { NeptunCode = "S32X4L", Name = "BENCE", Age = 19, JoinedCourseID = anal2course1.CourseID, JoinedCourse = anal2course1, AcquiredCredtis = 30 };
            Students benceee = new Students() { NeptunCode = "S321AS", Name = "BENCEEE", Age = 31, JoinedCourseID = hftcourse1.CourseID, JoinedCourse = hftcourse1, AcquiredCredtis = 30 };
            Students ferike = new Students() { NeptunCode = "12SD23", Name = "FERENC", Age = 21, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 20 };
            Students bogi = new Students() { NeptunCode = "SDA123", Name = "Bogi", Age = 19, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 210 };
            Students lilla = new Students() { NeptunCode = "ASD123", Name = "Lilla", Age = 23, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 200 };
            Students jozsef = new Students() { NeptunCode = "ASD112", Name = "József", Age = 24, JoinedCourseID = hftcourse2.CourseID, JoinedCourse = hftcourse2, AcquiredCredtis = 140 };

            hftcourse1.Students.Add(benceee);
            hftcourse2.Students.Add(bogi);
            hftcourse2.Students.Add(lilla);
            hftcourse2.Students.Add(jozsef);
            hftcourse2.Students.Add(ferike);
            anal2course1.Students.Add(bence);



            List<Students> students = new List<Students>();
            students.Add(bence);
            students.Add(benceee);
            students.Add(ferike);
            students.Add(bogi);
            students.Add(lilla);
            students.Add(jozsef);

            return students.AsQueryable();
        }
    }
}
