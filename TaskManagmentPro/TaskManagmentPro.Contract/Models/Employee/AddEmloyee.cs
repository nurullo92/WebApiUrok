using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentPro.Contract.Models.Employee
{
    public class AddEmloyee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Role { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
