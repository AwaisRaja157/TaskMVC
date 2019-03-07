using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMVC.Models;
using TaskMVC.Repositories;

namespace TaskMVC.Controllers
{
    public class HomeController : Controller
    {
        public EmployeeRepository EmpRepo { get; set; }

        public HomeController()
        {
            this.EmpRepo = new EmployeeRepository();
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Employee(int? ID)
        {
            ViewBag.M = EmpRepo.GetList();
            Employee employee = new Employee();
            if (ID != null)
            {
                employee = EmpRepo.Get((int)ID);
            }
            else
            {
                employee = new Employee();
            }
            ViewBag.Employee = employee;
            return View();
        }

        [HttpPost]
        public ActionResult Employee(Employee employee)
        {
            if(employee.ID == 0)
            {
                EmpRepo.Insert(employee);
            }
            else
            {
                EmpRepo.Update(employee);
            }
            return RedirectToAction("Employee","Home");
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int ID)
        {
            EmpRepo.Delete(ID);
            return RedirectToAction("Employee", "Home");


        }
    }
}