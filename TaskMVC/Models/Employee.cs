using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMVC.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        //[RegularExpression("/^[A-Z]+$/i")]
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