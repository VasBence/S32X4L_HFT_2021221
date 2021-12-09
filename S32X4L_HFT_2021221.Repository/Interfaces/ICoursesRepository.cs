using S32X4L_HFT_2021221.Models;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public interface ICoursesRepository
    {
        void Create(Courses course);
        void Delete(int id);
        Courses ReadOne(int id);
        IQueryable<Courses> GetAll();
        public void UdpateCourseName(Courses courses);


    }
}