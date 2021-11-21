using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S32X4L_HFT_2021221.Models;

namespace S32X4L_HFT_2021221.Data
{
    public class CoursesCountFromSubjects
    {
        public string SUBJECT { get; set; }
        public ICollection<Courses> NAME { get; set; }

    }
}
