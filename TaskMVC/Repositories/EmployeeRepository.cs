using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskMVC.Models;

namespace TaskMVC.Repositories
{
    public class EmployeeRepository : DBRepository
    {
        
        public  bool Insert(Employee employee)
        {
            SqlConnection con = new SqlConnection(Connectionstring);

            String query = $@"INSERT INTO [dbo].[Employee]
           ([Name]
           ,[Salary]
           ,[PocketMoney]
           ,[GPA]
           ,[NDouble]
           ,[DateOfBirth]
           ,[UrduName])
     VALUES
           (
            '{employee.Name}'
           ,'{employee.Salary}'
           ,'{employee.PocketMoney}'
           ,'{employee.GPA}'
           ,'{employee.NDouble}'
           ,'{employee.DateOfBirth?.ToString("yyyy-MM-dd")}'
           ,N'{employee.UrduName}'
); SELECT SCOPE_IDENTITY();";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            employee.ID = ID;
            con.Close();
            return true;
        }


        public  bool Update(Employee employee)
        {
            SqlConnection con = new SqlConnection(Connectionstring);

            String query = $@"
UPDATE [dbo].[Employee]
   SET [Name] = '{employee.Name}'
      ,[Salary] = '{employee.Salary}'
      ,[PocketMoney] = '{employee.PocketMoney}'
      ,[GPA] = '{employee.GPA}'
      ,[NDouble] = '{employee.NDouble}'
      ,[DateOfBirth] = '{employee.DateOfBirth}'
      ,[UrduName] = '{employee.UrduName}'
 WHERE ID = {employee.ID}";


            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }


        public  bool Delete(int ID)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            String query = $@"DELETE FROM [dbo].[Employee] WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }


        public  Employee Get(int ID)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string query = $@"Select * From Employee Where ID = {ID}";
            Employee employee = new Employee();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
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
            con.Close();
            return employee;

        }


        public List<Employee> GetList()
        {
            List<Employee> EmployeList = new List<Employee>();
            String query = $@"Select * From Employee";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
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
                    EmployeList.Add(e);

                }
            }
            return EmployeList;
        }
    }
}