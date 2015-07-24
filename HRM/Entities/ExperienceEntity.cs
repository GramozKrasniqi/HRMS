using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ExperienceEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string PositionHeld { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeContact { get; set; }
        public string BusinessType { get; set; }

        public override string ToString()
        {
            return PositionHeld + " - " + EmployeeName;
        }

    }
}
