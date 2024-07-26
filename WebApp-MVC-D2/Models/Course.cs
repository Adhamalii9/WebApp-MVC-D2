using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace WebApp_MVC_D2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20 , MinimumLength = 2)]
        [UniqueCourseName]
        public string Name { get; set; }

        [Required]
        [Range(50,100)]
        public int Degree { get; set; }


        [Required]
        [LessThan(nameof(Degree))]
        public int MinDegree { get; set; }


        [Required]
        [DivisibleByThree]
        public int Hours { get; set; }

        public int DeptId { get; set; }
        public Department Dept { get; set; }

        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<CrsResult> CrsResults { get; set; }


    }
}
