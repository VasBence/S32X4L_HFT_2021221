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
    [Table("tanulok")]
    public class Students
    {

        [Key]
        public string NeptunCode { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }
        public int AcquiredCredtis { get; set; }

        [ForeignKey(nameof(JoinedCourse))]
        public int JoinedCourseID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Courses JoinedCourse { get; set; }
        

      

    }
    public class StudentsWithTheLongestNameByEachCourse
    {
        public string CNAME { get; set; }
        public string SNAME { get; set; }
    }

    public class GetEachStudentFor
    {
        public string TNAME { get; set; }
        public string NAME { get; set; }
    }
    public class CoursesCountFromSubjects
    {
        public string SUBJECT { get; set; }

        public int COUNT { get; set; }
    }

    public class StudentsOnCoursesCount
    {
        public string NAME { get; set; }
        public int COUNT { get; set; }
    }
}
