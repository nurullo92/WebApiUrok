using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerPro.Contract.Models.TaskItem
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
