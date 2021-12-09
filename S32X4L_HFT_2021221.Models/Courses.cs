using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace S32X4L_HFT_2021221.Models
{
    [Table("courses")]
    public class Courses
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
