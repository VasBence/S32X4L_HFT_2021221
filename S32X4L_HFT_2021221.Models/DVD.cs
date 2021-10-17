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
        public DateTime Length {  get; set; }
        [MaxLength(50)]
        [Required]
        public string Director {  get; set; }    
        public Genre Genre { get; set; }
        [Required]
        public int RentCost { get; set; }     
        public int LateFee { get; set; }
        public DVD(int iD, string title, DateTime length, string director, Genre genre, int rentCost, int lateFee)
        {
            ID = iD;
            Title = title;
            Length = length;
            Director = director;
            Genre = genre;
            RentCost = rentCost;
            LateFee = lateFee;
        }

    }
}
