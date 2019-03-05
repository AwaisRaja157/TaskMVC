using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMVC.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Salary { get; set; }
        public int? PocketMoney { get; set; }
        public double GPA { get; set; }
        public double? NDouble { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String UrduName { get; set; }

       
    }
}