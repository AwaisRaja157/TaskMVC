﻿using System;
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
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Employee is Not valid";
            }
            else
            {
                if (employee.ID == 0)
                {
                    this.EmpRepo.Insert(employee);
                }
                else
                {
                    this.EmpRepo.Update(employee);
                }
            }
            
            return RedirectToAction("Employee","Home");
        }


        [HttpPost]
        public ActionResult DeleteEmployee(int ID)
        {
            this.EmpRepo.Delete(ID);
            return RedirectToAction("Employee", "Home");
        }
    }
}