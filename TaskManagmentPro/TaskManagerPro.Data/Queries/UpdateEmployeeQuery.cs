
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Data.Queries
{
    public class UpdateEmployeeQuery
    {
        public string NewName { get; set; }
        public string NewEmail { get; set; }

        public UpdateEmployeeQuery(string newName, string newEmail)
        {
            NewName = newName;
            NewEmail = newEmail;
        }
    }
}
