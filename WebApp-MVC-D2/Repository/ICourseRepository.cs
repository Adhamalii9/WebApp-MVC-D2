using WebApp_MVC_D2.Models;

namespace WebApp_MVC_D2.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetByDeptID(int deptID);
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course obj);
        void Update(Course obj);
        void Delete(int id);
        void Save();
    }
}
