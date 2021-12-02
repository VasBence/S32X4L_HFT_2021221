using S32X4L_HFT_2021221.Models;
using System.Linq;

namespace S32X4L_HFT_2021221.Repository
{
    public interface ISubjectsRepository
    {
        void Create(Subjects subject);
        void Delete(int id);
        Subjects ReadOne(int id);
        IQueryable<Subjects> GetAll();
        void UpdateSubjectProps(Subjects subjects);
     
    }
}