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
    public class targyak
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TargyID { get; set; }

        [MaxLength(50)]
        [Required]
        public string TargyNev { get; set; }

        public int Kredit { get; set; }

        public virtual ICollection<kurzusok> TargyKurzusok { get; set; }

        public targyak()
        {
            TargyKurzusok = new HashSet<kurzusok>();
        }
    }
}
