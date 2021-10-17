using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    public enum Genre
    {
        scifi,action,drama,thriller,horror,comedy,musical
    }

    [Table("DVDs")]
    public class DVD
    {
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        public int Length { get; set; }
        public Genre Genre { get; set; } 

        public virtual ICollection<CustomerInfo> CustomerWhoRentedID { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreID { get; set; }
        public virtual DVDstore Store { get; set; }

        public DVD()
        {
        CustomerWhoRentedID = new HashSet<CustomerInfo>();
        }

    }
}
