using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S32X4L_HFT_2021221.Models
{
    [Table("teachers")]
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

}
