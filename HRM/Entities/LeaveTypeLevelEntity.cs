using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class LeaveTypeLevelEntity
    {
        public int Id { get; set; }
        public int LeaveTypeId { get; set; }
        public int NoOfDays { get; set; }
        public double PaymentPercentage { get; set; }
        public LeaveNameType LeaveNameType { get; set; }
    }
}
