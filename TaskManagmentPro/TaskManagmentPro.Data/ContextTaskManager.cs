using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro.Data
{
    public class ContextTaskManager
    {

        public DbSet<Employee> Employees { get; set; }
    }
}
