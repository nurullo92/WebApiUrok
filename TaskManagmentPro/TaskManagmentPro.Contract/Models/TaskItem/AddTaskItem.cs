using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro.Contract.Models.TaskItem
{
    public class AddTaskItem
    {
        public string Title{ get; set; }
        public string Description{ get; set; }
        public TasksStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
