using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC_D2.Models;
using WebApp_MVC_D2.ViewModels;

namespace WebApp_MVC_D2.Controllers
{
    public class InstructorController : Controller
    {

        ITIDbContext context = new ITIDbContext();
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            return View("AllInstructors", instructors);

        }

        public IActionResult Details(int id)
        {
            var instructor = context.Instructors.SingleOrDefault(x => x.Id == id);
            return View("Instructor",instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new InstructorWithCourseAndDeptViewModel();
            viewModel.Courses = context.Courses.ToList();
            viewModel.Departments = context.Departments.ToList();
            return View("AddInstructor", viewModel);
        }

        [HttpPost]
        public IActionResult SaveAdd(InstructorWithCourseAndDeptViewModel InsFromReq)
        {
            if (InsFromReq.Name != null)
            {
                var instructor = new Instructor
                {
                    Name = InsFromReq.Name,
                    Image = InsFromReq.Image,
                    Salary = InsFromReq.Salary,
                    Address = InsFromReq.Address,
                    DeptId = InsFromReq.DeptId,
                    CrsId = InsFromReq.CrsId
                };

                context.Add(instructor);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            InsFromReq.Courses = context.Courses.ToList();
            InsFromReq.Departments = context.Departments.ToList();
            return View("AddInstructor", InsFromReq);

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            
            Instructor inst = context.Instructors.FirstOrDefault(i => i.Id == Id);
            var instVM = new InstructorWithCourseAndDeptViewModel();
            instVM.Id = inst.Id;
            instVM.Name = inst.Name;
            instVM.Image = inst.Image;
            instVM.Address = inst.Address;
            instVM.Salary = inst.Salary;
            instVM.CrsId = inst.CrsId;
            instVM.DeptId = inst.DeptId;

            instVM.Departments = context.Departments.ToList();
            instVM.Courses = context.Courses.ToList();

            return View("EditInstructor", instVM);



        }

        [HttpPost]
        public IActionResult SaveEdit(InstructorWithCourseAndDeptViewModel InsFromReq)
        {
            if (InsFromReq.Name != null)
            {

                var instructor = context.Instructors.FirstOrDefault(i => i.Id == InsFromReq.Id);
                if (instructor != null)
                {
                    instructor.Name = InsFromReq.Name;
                    instructor.Image = InsFromReq.Image;
                    instructor.Address = InsFromReq.Address;
                    instructor.Salary = InsFromReq.Salary;
                    instructor.CrsId = InsFromReq.CrsId;
                    instructor.DeptId = InsFromReq.DeptId;

                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            

            InsFromReq.Courses = context.Courses.ToList();
            InsFromReq.Departments = context.Departments.ToList();
            return View("EditInstructor", InsFromReq);
        }
            
    }
}
