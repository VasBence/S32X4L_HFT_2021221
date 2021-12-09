namespace S32X4L_HFT_2021221.Models
{
    public class CourseCredit
    {
        public string Name { get; set; }
        public int Credit { get; set; }
    }
    public class TeacherCourses
    {
        public string Name { get; set; }
        public string CourseName { get; set; }
    }
    public class StudentsWithTheLongestNameByEachCourse
    {
        public string CourseName { get; set; }
        public string StudentName { get; set; }
    }

    public class GetEachStudentFor
    {
        public string TeacherName { get; set; }
        public string StudentName { get; set; }
    }
    public class CoursesCountFromSubjects
    {
        public string Name{get; set; }

        public int Count { get; set; }
    }

    public class StudentsOnCoursesCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

}
