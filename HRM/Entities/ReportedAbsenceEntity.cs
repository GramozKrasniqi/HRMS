using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ReportedAbsenceEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AbsenceEmployeeId { get; set; }
        public int ManagerEmployeeId { get; set; }
        public string Notes { get; set; }
        public int? LeaveRequestId { get; set; }
        public RequestsEnum Status { get; set; }
    }
}
