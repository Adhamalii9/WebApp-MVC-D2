using Microsoft.AspNetCore.Mvc;
using WebApp_MVC_D2.Models;
using WebApp_MVC_D2.ViewModels;

namespace WebApp_MVC_D2.Controllers
{
    public class TraineeController : Controller
    {
        ITIDbContext context = new ITIDbContext();

        public IActionResult AllTrainees()
        {
            List<Trainee> trainees = context.Trainees.ToList();

            List<Department> departments = context.Departments.ToList();

            List<TraineesWithDeptName> traineesVm = new List<TraineesWithDeptName>();

            foreach (var trainee in trainees)
            {
                var department = departments.FirstOrDefault(d => d.Id == trainee.DeptId);

                var traineeVm = new TraineesWithDeptName
                {

                    Id = trainee.Id,
                    Name = trainee.Name,
                    Address = trainee.Address,
                    Image = trainee.Image,
                    DeptId = trainee.DeptId,
                    DepartmentName = department?.Name
                };

                traineesVm.Add(traineeVm);
            }

            return View("AllTrainees", traineesVm);
        }

        public IActionResult ShowResult(int id, int crsId)
        {
            var traineeVM = new TraineeWithCourseNameAndDegreeViewModel();
            var trainee = context.Trainees.FirstOrDefault(t => t.Id == id);
            var course = context.Courses.FirstOrDefault(c => c.Id == crsId);
            var courseResult = context.CrsResults.FirstOrDefault(c => c.TraineeId == id);

            if (trainee != null && course != null && courseResult != null)
            {
                traineeVM.Id = id;
                traineeVM.Name = trainee.Name;
                traineeVM.CourseName = course.Name;
                traineeVM.CourseDegree = course.Degree;
                traineeVM.CourseMinDegree = course.MinDegree;
                traineeVM.TraineeDegree = courseResult.Degree;
                traineeVM.SuccOrFail = courseResult.Degree >= course.MinDegree;
            }
            else
            {
                return NotFound();
            }

            return View("traineeResult", traineeVM);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // Retrieve the trainee and associated department and courses from the database
            var trainee = context.Trainees
                .Where(t => t.Id == id)
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.Image,
                    t.Address,
                    DepartmentName = t.Dept.Name,
                    Courses = t.CrsResults
                        .Select(cr => new
                        {
                            cr.Crs.Id, // Assuming Crs has an Id property
                            cr.Crs.Name
                        })
                        .ToList()
                })
                .SingleOrDefault();

            if (trainee == null)
            {
                return NotFound(); // Return a 404 if the trainee is not found
            }

            // Map to the view model
            var traineeVM = new TraineeWithCourses
            {
                Id = trainee.Id,
                Name = trainee.Name,
                Image = trainee.Image,
                Address = trainee.Address,
                Department = trainee.DepartmentName,
                Courses = trainee.Courses.Select(c => new CourseWithNameAndIDViewModel
                {
                    CourseId = c.Id,
                    CourseName = c.Name
                }).ToList()
            };

            return View("TraineeDetails", traineeVM);
        }



        [HttpGet]
        public IActionResult TraineeSearch(string name)
        {
            var trainees = context.Trainees.ToList();

            var departments = context.Departments.ToList();

            var filteredTrainees = trainees.Where(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            List<TraineesWithDeptName> traineesVm = new List<TraineesWithDeptName>();

            foreach (var trainee in filteredTrainees)
            {
                var department = departments.FirstOrDefault(d => d.Id == trainee.DeptId);

                var traineeVm = new TraineesWithDeptName
                {
                    Id = trainee.Id,
                    Address = trainee.Address,
                    Image = trainee.Image,
                    Name = trainee.Name,
                    DeptId = trainee.DeptId,
                    DepartmentName = department?.Name,
                    
                    
                };

                traineesVm.Add(traineeVm);
            }
            return View("AllTrainees", traineesVm);
        }

    }
}
