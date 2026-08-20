using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro.Contract.Models.TaskItem
{
    public class GetTaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
