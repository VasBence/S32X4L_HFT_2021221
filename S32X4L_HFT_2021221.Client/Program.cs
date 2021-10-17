using S32X4L_HFT_2021221.Data;
using S32X4L_HFT_2021221.Models;
using System;
using System.Linq;

namespace S32X4L_HFT_2021221.Client
{
    internal class Program
    {
        static void Main(string[] args)      
        {

            DVDDbContext dbcontext = new DVDDbContext();
           
            var costumers = dbcontext.CustomerInfos.ToArray();
            var costumers1 = dbcontext.DVDs.ToArray();
            var costumers2 = dbcontext.DVDstore.ToArray();

        }
    }
}
