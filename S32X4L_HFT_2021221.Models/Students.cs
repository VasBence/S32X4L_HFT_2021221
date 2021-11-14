using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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

        [ForeignKey(nameof(JoinedCourse))]
        public int JoinedCourseID { get; set; }
        public virtual Courses JoinedCourse { get; set; }

      

    }
}
