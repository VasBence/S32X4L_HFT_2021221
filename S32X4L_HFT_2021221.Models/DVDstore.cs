using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    [Table("DVDStores")]
    public class DVDstore
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(50)]
        public string StoreName { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }     
        public int WorkerCount { get; set; } 
        public virtual ICollection<DVD> DVDs {  get; set;}
        public DVDstore()
        {
            DVDs = new HashSet<DVD>();
          

        }


    }
}
