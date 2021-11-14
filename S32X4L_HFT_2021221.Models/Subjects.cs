using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
  

    [Table("targyak")]
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
