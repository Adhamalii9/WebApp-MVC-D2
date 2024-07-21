using Microsoft.AspNetCore.Cors.Infrastructure;

namespace WebApp_MVC_D2.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Degree { get; set; }

        public int MinDegree { get; set; }

        public int Hours { get; set; }

        public int DeptId { get; set; }
        public Department Dept { get; set; }

        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<CrsResult> CrsResults { get; set; }


    }
}
