using api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("LatihanAPIMVC")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}