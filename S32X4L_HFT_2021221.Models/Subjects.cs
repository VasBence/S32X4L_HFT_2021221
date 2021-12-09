using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S32X4L_HFT_2021221.Models
{


    [Table("subjects")]
    public class Subjects
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int Credit { get; set; }

        public virtual ICollection<Courses> SubjectCourses { get; set; }

        public Subjects()
        {
            SubjectCourses = new HashSet<Courses>();
        }
    }
}
