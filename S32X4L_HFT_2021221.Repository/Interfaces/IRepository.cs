using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
    }
}
