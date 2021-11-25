using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    [Table("COURSES")]
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public virtual ICollection<Students> Students { get; set; }

        [ForeignKey(nameof(Subjects))]
        public int SubjectID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Subjects Subjects { get; set; }
        public Courses()
        {
            Students = new HashSet<Students>();
        }

        [ForeignKey(nameof(Teacher))]
        public int TeacherID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }


    }
}
