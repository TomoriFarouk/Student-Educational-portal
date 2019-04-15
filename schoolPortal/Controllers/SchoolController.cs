using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using schoolPortal.Interfaces;
using schoolPortal.Models;
using schoolPortal.Models.ViewModels;
using schoolPortal.Repositories;

namespace schoolPortal.Controllers
{
    public class SchoolController : Controller
    {
        public bool Status { get; private set; }
        private readonly IStudentRepository _studentRepo;
        private readonly IcoursesRepository _CoursesRepo;
        private readonly IDepartmentRepository _DepartmentRepo;
        public SchoolController(IStudentRepository studentRepo, IcoursesRepository coursesRepo, IDepartmentRepository departmentRepo)
        {
            _studentRepo = studentRepo;
            _CoursesRepo = coursesRepo;
            _DepartmentRepo = departmentRepo;
        }
        public IActionResult Index()
        {
            var dEntity = _DepartmentRepo.GetAll();

            var dvm = new DeptViewModel
            {
                Dept = dEntity
            };

            ViewBag.Dept = dvm;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(StudentViewModel student)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                var entity = new Student
                {
                    DepartmentId = student.DepartmentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    MatricNumber = student.MatricNumber,

                };
                _studentRepo.Add(entity);
                Status = true;
                //return RedirectToAction(nameof(Login));
            }
            else
            {
                message = "Invalid request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(student);
        }
        public IActionResult HomePage(StudentViewModel student)
        {
            return View(student);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(StudentViewModel student)
        {
            var query = _studentRepo.GetStudentByMatric(student.MatricNumber);
            var follow = new StudentViewModel()
            {
                FirstName = query.FirstName,
                Id = query.Id,
                LastName = query.LastName,
                MatricNumber = query.MatricNumber,
                DepartmentId = query.DepartmentId,
                DepartmentName = query.Department.DepartmentName
            };
            if (query == null)
            {
                return Json(new { success = true, message = "Doesn't exist" });
            }
            else
            {
                return View("HomePage", follow);
                //return RedirectToAction("HomePage", follow);
            }
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepo.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Register(int id, [FromQuery]int level, [FromQuery]int courseId)
        {
            var siri = _DepartmentRepo.GetCoursesbyLevel(level, courseId);

            var rvm = new RegisterViewModel
            {
                StudentId = id,
                Courses = siri,

            };

            return View(rvm);
        }




        [HttpPost]
        public IActionResult Register(RegisterViewModel rvm)
        {

            _studentRepo.AddStudentCourses(rvm.StudentId, rvm.courseIds);




            return RedirectToAction("Result","School", new
            {
                studentid = rvm.StudentId
            });
            //var a = _studentRepo.GetStudentCourseById(rvm.StudentId);
            //if (a == null)
            //{
            //    _studentRepo.AddStudentCourses(rvm.StudentId, rvm.courseIds);
            //    return View();
            //}
            //else
            //{
            //    return Json(new { success = false, message = "already registered" });
            //}
        }
        [HttpGet]
        public IActionResult Result(int studentid)
        {
            var a = _studentRepo.GetAllStudentCoursesById(studentid);

            return View(a);
        }
        

    }
}