using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class LeaveRequestEntity
    {
        public int Id { get; set; }
        public int LeaveTypeId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsHalfDay { get; set; }
        public string Notes { get; set; }
        public int EmployeeId { get; set; }
        public int AlternatePersonId { get; set; }
        public int? ManagerEmployeeId { get; set; }
        public RequestsEnum LeaveStatus { get; set; }

    }
}
