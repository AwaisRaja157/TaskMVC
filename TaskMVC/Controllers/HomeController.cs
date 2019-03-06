using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMVC.Models;

namespace TaskMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Employee(int? ID)
        {
            ViewBag.M = Models.Employee.GetList();
            Employee employee = new Employee();
            if (ID != null)
            {
                employee = Models.Employee.Get((int)ID);
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
                Models.Employee.Insert(employee);
            }
            else
            {
                Models.Employee.Update(employee);
            }
            return RedirectToAction("Employee","Home");
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int ID)
        {
            Models.Employee.Delete(ID);
            return RedirectToAction("Employee", "Home");


        }
    }
}