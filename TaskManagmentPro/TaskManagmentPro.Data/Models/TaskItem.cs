using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentPro.Data.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TasksStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid EmployeeId { get; set; }    
        public Employee Employee { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
