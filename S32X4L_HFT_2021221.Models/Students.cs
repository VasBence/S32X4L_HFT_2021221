using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace S32X4L_HFT_2021221.Models
{
    [Table("students")]
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

}
