using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Data.Queries
{
    public class UpdateTaskItemQuery
    {
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }

        public UpdateTaskItemQuery(string newTitle, string newDescription)
        {
            NewTitle = newTitle;
            NewDescription = newDescription;
            
        }
    }
}
