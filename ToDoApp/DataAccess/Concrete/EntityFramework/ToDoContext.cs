using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ToDoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost;" +
                " Database = ToDoAppDb; Username = postgres; Password = fikret0108");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
