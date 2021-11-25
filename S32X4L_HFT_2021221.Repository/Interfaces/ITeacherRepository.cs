using S32X4L_HFT_2021221.Models;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public interface ITeacherRepository
    {
        void Create(Teacher teacher);
        void Delete(int id);
        IQueryable<Teacher> GetAll();
        Teacher ReadOne(int id);
        void UpdateAge(int id, int Age);
        void UpdateName(int id, string Name);
    }
}