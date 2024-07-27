using WebApp_MVC_D2.Models;

namespace WebApp_MVC_D2.Repository
{
    public interface IDepartmentRepository
    {
        string Id { get; set; }

        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department obj);
        void Update(Department obj);
        void Delete(int id);
        void Save();
    }
}
