using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApp_MVC_D2.Models;

namespace WebApp_MVC_D2.ViewModels
{
    public class CourseWithDeptNameViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [UniqueCourseName]
        public string Name { get; set; }

        [Required]
        [Range(50, 100)]
        public int Degree { get; set; }

        [Required]
        [LessThan(nameof(Degree))]
        public int MinDegree { get; set; }

        [Required]
        [Remote(action: "VerifyHours", controller: "Course")]
        //[DivisibleByThree]
        public int Hours { get; set; }

        public int DepartmentId { get; set; }
    }
}
