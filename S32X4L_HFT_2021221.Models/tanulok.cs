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
    public class tanulok
    {

        [Key]
        public string Neptunkod { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nev { get; set; }

        public int Kor { get; set; }

        [ForeignKey(nameof(FelvettKurzusok))]
        public int FelvettKurzusID { get; set; }
        public virtual kurzusok FelvettKurzusok { get; set; }

      

    }
}
