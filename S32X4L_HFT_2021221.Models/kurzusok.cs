using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    [Table("kurzusok")]
    public class kurzusok
    {
        [Key]
        public int KurzusID { get; set; }
        public string KurzusTanarok { get; set; }

        public virtual ICollection<tanulok> Tanulok { get; set; }

        [ForeignKey(nameof(Targyak))]
        public int TargyID { get; set; }
        public virtual targyak Targyak { get; set; }
        public kurzusok()
        {
            Tanulok = new HashSet<tanulok>();
        }


    }
}
