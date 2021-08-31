using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Filter_App.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext() : base() { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}