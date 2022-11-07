using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithADO_DAL.Models;

namespace WebAppWithADO_DAL.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer _dal;
        List<Student> listOfStudents = null;
        public StudentController(StudentDataAccessLayer dal)
        {
            _dal = dal;

        }
        public IActionResult Index()
        {
            listOfStudents = _dal.GetStudents();
            
            return View(listOfStudents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
           int flag=  _dal.Create(student);

            return RedirectToAction("Index");

        }
    }
}
