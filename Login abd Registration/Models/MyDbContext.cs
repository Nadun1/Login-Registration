using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Login_abd_Registration.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Login")
        {

        }

        public DbSet<registration> Registrations { get; set; }
    }
}