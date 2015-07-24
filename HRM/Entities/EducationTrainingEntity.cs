using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class EducationTrainingEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationContact { get; set; }
        public string QualificationAwarded { get; set; }
        public EducationTrainingLevelEnum Level { get; set; }

        public override string ToString()
        {
            return QualificationAwarded;
        }
    }
}
