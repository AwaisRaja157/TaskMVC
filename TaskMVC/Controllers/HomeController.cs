using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
            ViewBag.M = this.EmpRepo.GetList();
            Employee employee = new Employee();
            if (ID != null)
            {
                employee = this.EmpRepo.Get((int)ID);
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
            if (IsValid(employee))
            {
            }


            if(employee.ID == 0)
            {
                this.EmpRepo.Insert(employee);
            }
            else
            {
                this.EmpRepo.Update(employee);
            }
            return RedirectToAction("Employee","Home");
        }

        private bool IsValid(Employee employee)
        {
            Regex regex = new Regex("/^[A-Z]+$/i");
            if (regex.Match(employee.Name).Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [HttpPost]
        public ActionResult DeleteEmployee(int ID)
        {
            this.EmpRepo.Delete(ID);
            return RedirectToAction("Employee", "Home");
        }
    }
}