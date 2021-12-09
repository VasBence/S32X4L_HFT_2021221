using S32X4L_HFT_2021221.Models;
using S32X4L_HFT_2021221.Repository;
using System.Linq;

namespace S32X4L_HFT_2021221.Logic
{
    public interface ITeacherLogic
    {
        void CreateTeacher(Teacher teacher);
        void DeleteTeacher(int id);
        IQueryable<Teacher> ReadAllTeacher();
        Teacher ReadOneTeacher(int id);
        void UpdateTeacherProps(Teacher teacher);
    }
    public class TeacherLogic : ITeacherLogic
    {
        ITeacherRepository TeacherRepository;
        public TeacherLogic(ITeacherRepository repo)
        {
            TeacherRepository = repo;
        }
        public void CreateTeacher(Teacher teacher)
        {
            TeacherRepository.Create(teacher);
        }
        public Teacher ReadOneTeacher(int id)
        {
            return TeacherRepository.ReadOne(id);
        }
        public IQueryable<Teacher> ReadAllTeacher()
        {
            return TeacherRepository.GetAll();
        }
        public void DeleteTeacher(int id)
        {
            TeacherRepository.Delete(id);
        }
        public void UpdateTeacherProps(Teacher teacher)
        {
            TeacherRepository.UpdateProps(teacher);
        }

    }

}
