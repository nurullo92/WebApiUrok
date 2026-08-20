using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro.Data
{
    public class ContextTaskManager : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }


        public ContextTaskManager(DbContextOptions<ContextTaskManager> options) : base(options) 
        {
            Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<TaskItem>().ToTable("TaskItem");
        }
    }
}
