using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC_D2.Models;
using WebApp_MVC_D2.ViewModels;

namespace WebApp_MVC_D2.Controllers
{
    public class CourseController : Controller
    {
        ITIDbContext context = new ITIDbContext();
        public IActionResult Index()
        {
            var courses = context.Courses
                .Join(context.Departments,
                course => course.DeptId,
                Department => Department.Id,
                (course,department) => new CourseWithDeptNameViewModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Degree = course.Degree,
                    MinDegree = course.MinDegree,
                    Hours = course.Hours,
                })
                .ToList();
            return View("allCourses" , courses);
        }


        public IActionResult add()
        {
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");

            return View("addcourse");
        }


        [HttpPost]
        public IActionResult saveAdd(CourseWithDeptNameViewModel crsFromReq)
        {

            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Name = crsFromReq.Name,
                    Degree = crsFromReq.Degree,
                    MinDegree = crsFromReq.MinDegree,
                    Hours = crsFromReq.Hours,
                    DeptId = crsFromReq.DepartmentId
                };
                context.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");
            return View("addcourse", crsFromReq);
        }

        public IActionResult VerifyHours(int hours)
        {
            if (hours % 3 == 0)
            {
                return Json(true);
            }
            return Json("Hours must be divisble by 3");
        }

        


        public IActionResult edit(int id)
        {
            var departments = context.Departments.ToList();
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            var courseVM = new CourseWithDeptNameViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                Hours = course.Hours,
                DepartmentId = course.DeptId
            };
            ViewBag.Departments = new SelectList( context.Departments.ToList(), "Id", "Name", courseVM.DepartmentId);

            return View("editCourse", courseVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(CourseWithDeptNameViewModel courseVM)
        {
            if (courseVM.Name != null)
            {
                var course = context.Courses.FirstOrDefault(c => c.Id == courseVM.Id);

                
                course.Name = courseVM.Name;
                course.Degree = courseVM.Degree;
                course.MinDegree = courseVM.MinDegree;
                course.Hours = courseVM.Hours;
                course.DeptId = courseVM.DepartmentId;

                context.Update(course);
                context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Name", "Name", courseVM.DepartmentId);
            return View("EditCourse", courseVM);
        }

        public IActionResult Delete(int id)
        {

            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction("index");

            
        }
            
    }
}
