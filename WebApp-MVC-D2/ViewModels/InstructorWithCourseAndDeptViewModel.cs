using WebApp_MVC_D2.Models;

namespace WebApp_MVC_D2.ViewModels
{
    public class InstructorWithCourseAndDeptViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public int Salary { get; set; }
        public string Address { get; set; }

        public int DeptId { get; set; }

        public Department Dept { get; set; }

        public int CrsId { get; set; }
        public Course Crs { get; set; }

        public List<Course> Courses { get; set; }

        public List<Department> Departments { get; set; }
    }
}
