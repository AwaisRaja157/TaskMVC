using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TaskMVC.Repositories
{
    public class DBRepository
    {
        public string Connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    }
}