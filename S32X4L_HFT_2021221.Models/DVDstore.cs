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
        public string BusinessHours { get; set; }
        [MaxLength(50)]
        public string ManagerName {  get; set; }
        public int WorkerCount { get; set; }
        public DVDstore(int iD, string storeName, string location, string businessHours, string managerName, int workerCount)
        {
            ID = iD;
            StoreName = storeName;
            Location = location;
            BusinessHours = businessHours;
            ManagerName = managerName;
            WorkerCount = workerCount;
        }


    }
}
