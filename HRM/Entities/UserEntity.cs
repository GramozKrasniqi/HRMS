using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class UserEntity
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ApplicationId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
