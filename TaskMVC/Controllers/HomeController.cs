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
            List<Employee> k = new List<Employee>();
            String query = $@"
Select * From Employee";
            String Connectionstring = "Data Source=.;Initial Catalog=TaskMVC;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee e = new Employee();
                    e.ID = int.Parse(reader["ID"].ToString());
                    e.Name = reader["Name"].ToString();
                    e.Salary = int.Parse(reader["Salary"].ToString());
                    e.PocketMoney = int.Parse(reader["PocketMoney"].ToString());
                    e.GPA = double.Parse(reader["GPA"].ToString());
                    e.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                    e.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    e.NDouble = double.Parse(reader["NDouble"].ToString());
                    e.UrduName = reader["UrduName"].ToString();
                    k.Add(e);

                }
            }

           reader.Close();
            ViewBag.M = k;

            Employee employee = new Employee();
            if (ID != null)
            {
                query = $@"Select * From Employee Where ID = {ID}";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employee.ID = int.Parse(reader["ID"].ToString());
                        employee.Name = reader["Name"].ToString();
                        employee.Salary = int.Parse(reader["Salary"].ToString());
                        employee.PocketMoney = int.Parse(reader["PocketMoney"].ToString());
                        employee.GPA = double.Parse(reader["GPA"].ToString());
                        employee.TimeStamp = DateTime.Parse(reader["TimeStamp"].ToString());
                        employee.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                        employee.NDouble = double.Parse(reader["NDouble"].ToString());
                        employee.UrduName = reader["UrduName"].ToString();
                    }
                }
            }
            else
            {
                employee = new Employee();
            }

            ViewBag.Employee = employee;
            con.Close();
            return View();
        }

        [HttpPost]
        public ActionResult Employee(Employee employee)
        {
            String ConnectionString = "Data Source=.;Initial Catalog=TaskMVC;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            String query = string.Empty;

            if(employee.ID == 0)
            {
                query = $@"INSERT INTO [dbo].[Employee]
           ([Name]
           ,[Salary]
           ,[PocketMoney]
           ,[GPA]
           ,[NDouble]
           ,[TimeStamp]
           ,[DateOfBirth]
           ,[UrduName])
     VALUES
           (
            '{employee.Name}'
           ,'{employee.Salary}'
           ,'{employee.PocketMoney}'
           ,'{employee.GPA}'
           ,'{employee.NDouble}'
           ,'{employee.TimeStamp}'
           ,'{employee.DateOfBirth}'
           ,N'{employee.UrduName}'
)";
            }
            else
            {
               query = $@"
UPDATE [dbo].[Employee]
   SET [Name] = '{employee.Name}'
      ,[Salary] = '{employee.Salary}'
      ,[PocketMoney] = '{employee.PocketMoney}'
      ,[GPA] = '{employee.GPA}'
      ,[NDouble] = '{employee.NDouble}'
      ,[TimeStamp] = '{employee.TimeStamp}'
      ,[DateOfBirth] = '{employee.DateOfBirth}'
      ,[UrduName] = '{employee.UrduName}'
 WHERE ID = {employee.ID}";
     
            }

            
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Employee","Home");


        }

        [HttpPost]
        public ActionResult DeleteEmployee(int ID)
        {
            String ConnectionString = "Data Source=.;Initial Catalog=TaskMVC;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            String query = $@"DELETE FROM [dbo].[Employee] WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Employee", "Home");


        }
    }
}