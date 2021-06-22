using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;
namespace CodeTheWay.Web.Ui.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentsService StudentService;
        private string FirstName;
        private string lastName;
        private int age;

        public StudentsController(IStudentsService studentsService)
        {
            this.StudentService = studentsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await StudentService.GetStudents());
        }

        public async Task<IActionResult> Create()
        {
            return View(new StudentRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                if (model.age > 0 && model.age <= 18)
                {
                    {
                        Student listofStudents = new Student()
                        {

                            Id = model.Id,
                            LastName = model.lastName,
                            FirstMidName = model.firstName

                        };

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
                
                    return View("model");
                
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            StudentRegistrationViewModel students = new StudentRegistrationViewModel()
            {
                Id = student.Id,
                lastName = student.LastName,
                firstName = student.FirstMidName,
                age = 0,
            };
            return View(students);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(Student model)
        {
            if (ModelState.IsValid)
            {
                if (model.Age > 0 && model.Age <= 18)
                {
                    Student list = new Student()
                    {
                        Id = model.Id,
                        LastName = model.LastName,
                        FirstMidName = model.FirstMidName
                    };
                    var student = await StudentService.Update(list);
                }


                return RedirectToAction("Index");
                
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            StudentRegistrationViewModel listOfStudents = new StudentRegistrationViewModel();
            return View(listOfStudents.Id);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            await StudentService.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
