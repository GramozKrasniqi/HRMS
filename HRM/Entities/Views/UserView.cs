using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class UserView
    {
        public int EmployeeId { get; set; }
        public int ApplicationId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public StatusEnum Status { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
