using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class LeaveRequestView
    {
        public int Id { get; set; }
        public string LeaveType { get; set; }
        public LeaveNameType LeaveNameType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsHalfDay { get; set; }
        public string Notes { get; set; }
        public string Employee { get; set; }
        public string AlternateEmployee { get; set; }
        public string ManagerEmployee { get; set; }
        public RequestsEnum LeaveStatus { get; set; }
    }
}
