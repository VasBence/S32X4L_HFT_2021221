using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    [Table("DVDRentals")]
    public class DVDrentals
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }      
        public int DVDID { get; set; }
        public string CustomerID { get; set; }
        public DateTime RentTime { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }

        public DVDrentals(int iD, int dVDID, string customerID, DateTime rentTime, DateTime dueDate)
        {
            ID = iD;
            DVDID = dVDID;
            CustomerID = customerID;
            RentTime = rentTime;
            DueDate = dueDate;          
            IsReturned = false;
        }

    }
}
