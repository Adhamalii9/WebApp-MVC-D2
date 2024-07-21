namespace WebApp_MVC_D2.Models
{
    public class Instructor
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

    }
}
