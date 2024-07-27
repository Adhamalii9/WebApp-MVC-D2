using WebApp_MVC_D2.Models;

namespace WebApp_MVC_D2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        ITIDbContext context;    
        public string Id { get ; set ; }

        public DepartmentRepository(ITIDbContext context)
        {
            this.context = context; 
        }
    

        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department obj)
        {
             context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            context.Update(obj);
        }
    }
}
