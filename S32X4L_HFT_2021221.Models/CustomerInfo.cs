﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Models
{
    [Table("CustomerInfo")]
    public class CustomerInfo
    {
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public DateTime JoinDate { get; set; }
        public CustomerInfo(int iD, string name, DateTime joinDate)
        {
            ID = iD;
            Name = name;
            JoinDate = joinDate;
        }

    }
}
