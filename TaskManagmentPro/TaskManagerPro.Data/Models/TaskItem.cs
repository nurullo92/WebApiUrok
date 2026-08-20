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

        // FK на таблицу TasksStatus
        public int StatusId { get; set; }
        public TasksStatus Status { get; set; }

        // FK на таблицу TaskPriority
        public int PriorityId { get; set; }
        public TaskPriority Priority { get; set; }

        public List<Employee> Employees { get; set; } = new();

        public DateTime CreatedAt { get; set; }
    }
}
