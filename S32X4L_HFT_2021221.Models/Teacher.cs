using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    [Table("TEACHER")]
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Courses> HeldCourses { get; set; }

        public Teacher()
        {
            HeldCourses = new HashSet<Courses>();
        }
    }
    public class CourseCredit
    {
        public string NAME { get; set; }
        public int CREDIT { get; set; }
    }
    public class TeacherCourses
    {
        public string NAME { get; set; }
        public string CNAME { get; set; }
    }
}
