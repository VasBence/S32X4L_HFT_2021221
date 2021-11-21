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

        public virtual ICollection<Courses> HoldedCourses { get; set; }

        public Teacher()
        {
            HoldedCourses = new HashSet<Courses>();
        }
    }
}
