using ConsoleTools;
using S32X4L_HFT_2021221.Models;
using System;

namespace S32X4L_HFT_2021221.Client
{

    class Program
    {
        static RestService rest = new RestService("http://localhost:5000");
        #region COURSESREGION
        static void GetCourses()
        {
            Console.WriteLine("Az összes kurzus:");
            var getcourses = rest.Get<Courses>("courses");
            getcourses.ForEach(x => Console.WriteLine("Kurzus neve: " + x.CourseName + "---" + "Kurzus ID:" + x.CourseID));

            Console.ReadKey();
        }
        static void ReadOneCourse()
        {
            Console.WriteLine("Írja be az egyik kurzus ID-t");
            int id = int.Parse(Console.ReadLine());
            string constring = "courses/" + Convert.ToString(id);
            var getonecourse = rest.GetSingle<Courses>(constring);

            Console.WriteLine("Kurzus neve: " + getonecourse.CourseName + "---" + "Kurzus ID: " + getonecourse.CourseID);
            Console.ReadKey();
        }
        static void DeleteCourse()
        {

            var getcourses = rest.Get<Courses>("courses");
            getcourses.ForEach(x => Console.WriteLine("Kurzus neve: " + x.CourseName + "---" + "Kurzus ID: " + x.CourseID));
            Console.WriteLine("Írja be annak a kurzusnak az ID-jét amelyiket törölni szeretni");
            int CourseID = int.Parse(Console.ReadLine());
            Console.WriteLine();


            rest.Delete(CourseID, "courses");

            Console.WriteLine("A kurzus sikeresen törölve lett az adatbázisból :)");

            Console.ReadKey();
        }
        static void AddCourse()
        {

            Console.WriteLine("A létező kurzusok");
            var getcourses = rest.Get<Courses>("courses");
            getcourses.ForEach(x => Console.WriteLine("Kurzus neve: " + x.CourseName + "---" + "Kurzus ID: " + x.CourseID));
            Courses newCourse = new Courses();

            Console.WriteLine("Adja meg a kurzus nevét");
            newCourse.CourseName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Adja meg annak a tárgynak az ID-jét amelyikhez tartozik a kurzus");
            var getsubject = rest.Get<Subjects>("subjects");
            getsubject.ForEach(x => Console.WriteLine("Tárgy neve: " + x.Name + "---" + "Tárgy ID: " + x.SubjectID));
            newCourse.SubjectID = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Adja meg annak a tanárnak az ID-jét amelyik az órát tartja");
            var getteachers = rest.Get<Teacher>("teacher");
            getteachers.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + "---" + "Tanár ID: " + x.TeacherID));
            newCourse.TeacherID = int.Parse(Console.ReadLine());

            rest.Post<Courses>(newCourse, "courses");
            Console.WriteLine("Sikeres hozzáadás");
            Console.ReadKey();
        }
        static void ChangeCourseName()
        {
            var getcourses = rest.Get<Courses>("courses");
            getcourses.ForEach(x => Console.WriteLine("Kurzus neve: " + x.CourseName + "---" + "Kurzus ID: " + x.CourseID));


            Console.WriteLine("Írja be annak a kurzusnak az ID-jét amelyik nevét át szeretné írni");
            int id = int.Parse(Console.ReadLine());
            var get = rest.GetByInt<Courses>(id, "courses");


            Console.WriteLine("Írja be mire szeretné átnevezni a " + get.CourseName + " nevű kurzust");
            var name = Console.ReadLine();
            get.CourseName = name;

            rest.Put<Courses>(get, "courses");

            Console.WriteLine("Át lett nevezve " + get.CourseName + "-re");
            Console.ReadKey();
        }
        static void GetCreditPerCourses()
        {
            var courses = rest.Get<CourseCredit>("stat/GetCreditPerCourses");
            courses.ForEach(x => Console.WriteLine(x.Name + " --- " + x.Credit));
            Console.ReadKey();
        }

        static void HeldCoursesByTeachers()
        {
            var courses = rest.Get<TeacherCourses>("stat/HeldCoursesByTeachers");
            courses.ForEach(x => Console.WriteLine(x.CourseName + " --- " + x.Name));
            Console.ReadKey();
        }

        static void StudentsOnCoursesCount()
        {
            var courses = rest.Get<StudentsOnCoursesCount>("stat/StudentsOnCoursesCount");
            courses.ForEach(x => Console.WriteLine(x.Name + " --- " + x.Count));
            Console.ReadKey();


        }


        #endregion
        #region SUBJECTSREGION
        static void GetSubjects()
        {
            Console.WriteLine("Az összes tárgy:");
            var getsubjects = rest.Get<Subjects>("subjects");
            getsubjects.ForEach(x => Console.WriteLine("Tárgy neve: " + x.Name + "---" + "Tárgy ID: " + x.SubjectID + "---" + "Kredit: " + x.Credit));
            Console.ReadKey();

        }
        static void ReadOneSubject()
        {
            Console.WriteLine("Írja be az egyik tárgy ID-t");
            int id = int.Parse(Console.ReadLine());
            string constring = "subjects/" + Convert.ToString(id);
            var getonesubject = rest.GetSingle<Subjects>(constring);

            Console.WriteLine("Tárgy neve: " + getonesubject.Name + "---" + "Tárgy ID: " + getonesubject.SubjectID + "---" + "Kredit: " + getonesubject.Credit);
            Console.ReadKey();

        }
        static void DeleteSubject()
        {

            var getsubject = rest.Get<Subjects>("subjects");
            getsubject.ForEach(x => Console.WriteLine("Tárgy neve: " + x.Name + " --- " + "Tárgy ID: " + x.SubjectID));
            Console.WriteLine("Írja be annak a tárgynak az ID-jét amelyiket törölni szeretni");
            int SubjectID = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var subject = rest.GetByInt<Subjects>(SubjectID, "subjects");
            if (subject == null)
            {
                throw new Exception();
            }
            else
            {
                rest.Delete(SubjectID, "subjects");

                Console.WriteLine("A tárgy sikeresen törölve lett az adatbázisból :)");
            }
            Console.ReadKey();
        }
        static void AddSubject()
        {

            Console.WriteLine("A  tárgyak");
            var getSubjects = rest.Get<Subjects>("subjects");
            getSubjects.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + "---" + "kredit : " + x.Credit));
            Subjects newSubject = new Subjects();

            Console.WriteLine("Adja meg a tárgy nevét");
            newSubject.Name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Adja meg a kreditet");
            newSubject.Credit = int.Parse(Console.ReadLine());


            rest.Post<Subjects>(newSubject, "subjects");

            Console.WriteLine("A tárgy sikeresen hozzáadva:) ");
            Console.ReadKey();
        }
        static void ChangeSubjectProps()
        {
            var getSubjects = rest.Get<Subjects>("subjects");
            getSubjects.ForEach(x => Console.WriteLine("Tárgy neve: " + x.Name + "---" + "Kurzus ID: " + x.SubjectID));


            Console.WriteLine("Írja be annak a tárgynak az ID-jét amelyik nevét át szeretné írni");
            int id = int.Parse(Console.ReadLine());
            var get = rest.GetByInt<Subjects>(id, "subjects");


            Console.WriteLine("Írja be mire szeretné átnevezni a " + get.Name + " nevű tárgyat");
            var name = Console.ReadLine();
            get.Name = name;

            Console.WriteLine("Írja be mire szeretné megváltoztatni a " + get.Name + " nevű tárgy kreditértékét");
            var credit = int.Parse(Console.ReadLine());

            rest.Put<Subjects>(get, "subjects");

            Console.WriteLine("A változtatás sikeres");
            Console.ReadKey();
        }

 


        #endregion
        #region STUDENTREGION
        static void GetStudents()
        {
            Console.WriteLine("Az összes Tanuló:");
            var getsutents = rest.Get<Students>("students");
            getsutents.ForEach(x => Console.WriteLine("Tanuló neve " + x.Name + " --- " + "elért kredit: " + x.AcquiredCredtis + " --- " + "kor: " + x.Age));
            Console.ReadKey();

        }
        static void ReadOneStudent()
        {

            var getStudents = rest.Get<Students>("students");

            getStudents.ForEach(x => Console.WriteLine("Tanuló neve: " + x.Name + " --- " + "NEPTUN kód:" + x.NeptunCode));
            Console.WriteLine("Adja meg annak a tanulónak az ID-ját amelyiket be szeretné olvasni");
            string id = Console.ReadLine();

            string constring = "students/" + Convert.ToString(id);
            var getOneStudent = rest.GetSingle<Students>(constring);

            Console.WriteLine("Tanuló neve: " + getOneStudent.Name + " --- " + "elért kredit:" + getOneStudent.AcquiredCredtis + " --- " + "kor: " + getOneStudent.Age);
            Console.ReadKey();

        }
        static void DeleteStudent()
        {

            var getStudent = rest.Get<Students>("students");
            getStudent.ForEach(x => Console.WriteLine("Diák neve: " + x.Name + " --- " + "NEPTUNKÓD:" + x.NeptunCode));

            Console.WriteLine("Írja be annak a tanulónak a neptunkódját amelyiket törölni szeretné");
            string studentId = Console.ReadLine();
            Console.WriteLine();


            rest.Delete(studentId, "students");

            Console.WriteLine("A tanuló sikeresen törölve lett az adatbázisból :)");

            Console.ReadKey();
        }
        static void AddStudent()
        {

            Console.WriteLine("A diákok");
            var getstudents = rest.Get<Students>("students");
            getstudents.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + " --- " + "NEPTUN kód :" + x.NeptunCode + " --- " + "Kora :" + x.Age));
            Students newStudents = new Students();

            Console.WriteLine("Adja meg a diák neptunkódját");
            newStudents.NeptunCode = Console.ReadLine();
            Console.WriteLine("Adja meg a diák nevét");
            newStudents.Name = Console.ReadLine();

            Console.WriteLine("Adja meg az elért kreditjeit");
            newStudents.AcquiredCredtis = int.Parse(Console.ReadLine());



            Console.WriteLine();
            Console.WriteLine("Adja meg a diák életkorát");
            newStudents.Age = int.Parse(Console.ReadLine());

            var getCourses = rest.Get<Courses>("courses");
            getCourses.ForEach(x => Console.WriteLine("Kurzus neve: " + x.CourseName + " --- " + "Kurzus ID:" + x.CourseID));
            Console.WriteLine("Adjam meg melyik kurzushoz csatlakozott a diák");

            newStudents.JoinedCourseID = int.Parse(Console.ReadLine());


            rest.Post<Students>(newStudents, "students");

            Console.WriteLine("Sikeresen csatlakozott a diák :)");
            Console.ReadKey();
        }
        static void ChangeStudentProps()
        {
            var getStudents = rest.Get<Students>("students");
            getStudents.ForEach(x => Console.WriteLine("Tanuló neve: " + x.Name + " --- " + "Kurzus ID:" + x.NeptunCode));


            Console.WriteLine("Írja be annak a tanulónak a neptunkódját akinek a nevét át szeretné írni");
            string id = Console.ReadLine();
            var get = rest.GetByString<Students>(id, "students");


            Console.WriteLine("Írja be mire szeretné átnevezni a " + get.Name + " nevű diákot");
            var name = Console.ReadLine();
            get.Name = name;

            Console.WriteLine("Írja be mire szeretné megváltoztatni a " + get.Name + " életkorát");
            var age = int.Parse(Console.ReadLine());
            get.Age = age;

            Console.WriteLine("Írja be mire szeretné megváltoztatni a " + get.Name + " elért kreditjeit");
            var credits = int.Parse(Console.ReadLine());
            get.AcquiredCredtis = credits;

            rest.Put<Students>(get, "students");

            Console.WriteLine("A változtatás sikeres");
            Console.ReadKey();
        }
        static void StudentWithMostCredit()
        {
            var getstudent = rest.Get<string>("stat/getmaxcreditstudent");
            Console.WriteLine("A legtöbb kredittel rendelkező hallgató neve: ");
            getstudent.ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }

        static void StudentsNameSortedByLengthDescByCourses()
        {
            var get = rest.Get<StudentsWithTheLongestNameByEachCourse>("stat/StudentsWithTheLongestNameByEachCourse");
            get.ForEach(x => Console.WriteLine(x.StudentName + " --- " + x.CourseName));
            Console.ReadKey();
        }

        static void GetEachStudentForEachCoursesbyTeachers()
        {
            var get = rest.Get<GetEachStudentFor>("stat/GetEachStudentForEachCoursesbyTeachers");
            get.ForEach(x => Console.WriteLine(x.StudentName + " --- " + x.TeacherName));
            Console.ReadKey();

        }

        #endregion
        #region TEACHERREGION
        static void GetTeachers()
        {
            Console.WriteLine("Az összes tanár:");
            var getTeachers = rest.Get<Teacher>("teacher");
            getTeachers.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + " --- " + "Kora: " + x.Age));
            Console.ReadKey();

        }
        static void ReadOneTeacher()
        {
            Console.WriteLine("Írja be az egyik Tanár ID-t");
            int id = int.Parse(Console.ReadLine());
            string constring = "teacher/" + Convert.ToString(id);
            var getOneTeacher = rest.GetSingle<Teacher>(constring);

            Console.WriteLine("Tárgy neve: " + getOneTeacher.Name + " --- " + "Kora: " + getOneTeacher.Age);
            Console.ReadKey();

        }
        static void DeleteTeacher()
        {

            var getsubject = rest.Get<Teacher>("teacher");
            getsubject.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + " --- " + "Kora: " + x.Age + " --- " + "ID :" + x.TeacherID));
            Console.WriteLine("Írja be annak a tanárnak az ID-jét amelyiket törölni szeretni");
            int teacherId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var teacher = rest.GetByInt<Subjects>(teacherId, "teacher");
            if (teacher == null)
            {
                throw new Exception();
            }
            else
            {
                rest.Delete(teacherId, "teacher");

                Console.WriteLine("A tanár sikeresen törölve lett az adatbázisból :)");
            }
            Console.ReadKey();
        }
        static void ChangeTeacherProps()
        {
            var getTeacher = rest.Get<Teacher>("teacher");
            getTeacher.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + " --- " + "Tanár ID: " + x.TeacherID));


            Console.WriteLine("Írja be annak a tanulónak a neptunkódját akinek a nevét át szeretné írni");
            int id = int.Parse(Console.ReadLine());
            var get = rest.GetByInt<Teacher>(id, "teacher");


            Console.WriteLine("Írja be mire szeretné átnevezni a " + get.Name + " nevű Tanárt");
            var name = Console.ReadLine();
            get.Name = name;

            Console.WriteLine("Írja be mire szeretné megváltoztatni a " + get.Name + " életkorát");
            var age = int.Parse(Console.ReadLine());
            get.Age = age;

            rest.Put<Teacher>(get, "teacher");

            Console.WriteLine("A változtatás sikeres");
            Console.ReadKey();
        }
        static void AddTeacher()
        {

            Console.WriteLine("A  tanárok");
            var getTeacher = rest.Get<Teacher>("teacher");
            getTeacher.ForEach(x => Console.WriteLine("Tanár neve: " + x.Name + " --- " + "Kora :" + x.Age + " --- " + "ID :" + x.TeacherID));
            Teacher newTeacher = new Teacher();

            Console.WriteLine("Adja meg a tanár nevét");
            newTeacher.Name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Adja meg a tanár életkorát");
            newTeacher.Age = int.Parse(Console.ReadLine());


            rest.Post<Teacher>(newTeacher, "teacher");
            Console.WriteLine("Sikeresen hozzáadva");
            Console.ReadKey();
        }
        #endregion

        static void Main(string[] args)
        {

            System.Threading.Thread.Sleep(5000);


            ConsoleMenu coursesMenu = new ConsoleMenu(args, 1)
            .Add("Összes kurzus lekérdezése.", () => GetCourses())
            .Add("Egy kurzus beolvasása.", () => ReadOneCourse())
            .Add("Kurzus törlése", () => DeleteCourse())
            .Add("Kurzus hozzáadása.", () => AddCourse())
            .Add("Kurzus nevének változtatása.", () => ChangeCourseName())
            .Add("Kiírja a kurzusok kreditértékét.", () => GetCreditPerCourses())
            .Add("Melyik kurzust melyik tanár tartja?", () => HeldCoursesByTeachers())
            .Add("Kurzusonként hany diák csatlakozott?", () => StudentsOnCoursesCount())
            .Add("Vissza", ConsoleMenu.Close);


            ConsoleMenu subjectsMenu = new ConsoleMenu(args, 1)
           .Add("Összes tárgy lekérdezése.", () => GetSubjects())
           .Add("Egy tárgy beolvasása.", () => ReadOneSubject())
           .Add("tárgy törlése.", () => DeleteSubject())
           .Add("Tárgy hozzáadása.", () => AddSubject())
           .Add("Tárgy adatainak változtatása.", () => ChangeSubjectProps())
 
            .Add("Vissza", ConsoleMenu.Close);

            ConsoleMenu teacherMenu = new ConsoleMenu(args, 1)
           .Add("Összes tanár lekérdezése.", () => GetTeachers())
           .Add("Egy tanár beolvasása.", () => ReadOneTeacher())
           .Add("Tanár törlése.", () => DeleteTeacher())
           .Add("Tanár hozzáadása.", () => AddTeacher())
           .Add("Tanár nevének változtatása.", () => ChangeTeacherProps())
            .Add("Vissza", ConsoleMenu.Close);

            ConsoleMenu studentMenu = new ConsoleMenu(args, 1)
           .Add("Összes tanuló lekérdezése.", () => GetStudents())
           .Add("Egy tanuló beolvasása.", () => ReadOneStudent())
           .Add("Tanuló törlése.", () => DeleteStudent())
           .Add("Tanuló hozzáadása.", () => AddStudent())
           .Add("Tanuló adatainak változtatása.", () => ChangeStudentProps())
           .Add("A legtöbb kredittel rendelkező tanuló.", () => StudentWithMostCredit())
           .Add("Tanulók tanárai.", () => GetEachStudentForEachCoursesbyTeachers())
           .Add("Sorrendbe rendezett tanulók és kurzusaik.", () => StudentsNameSortedByLengthDescByCourses())
            .Add("Vissza", ConsoleMenu.Close);



            var mainMenu = new ConsoleMenu(args, 0)
           .Add("Kurzusok metódusai:", coursesMenu.Show)
           .Add("Tárgyak metódusai:", subjectsMenu.Show)
           .Add("Tanulók metódusai:", studentMenu.Show)
           .Add("Tanárok metódusai:", teacherMenu.Show);

            mainMenu.Show();

        }
    }
}

