using S32X4L_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public interface IStudentsRepository
    {
        void Create(Students student);
        void Delete(string id);
        Students ReadOne(string id);
        IQueryable<Students>GetAll();
        public void UpdateName(string neptunCode, string name);
        public void UpdateAge(string neptunCode, int Age);
    }
}