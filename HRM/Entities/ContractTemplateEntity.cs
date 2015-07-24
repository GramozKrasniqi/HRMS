using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ContractTemplateEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Preffix { get; set; }
        public int LanguageId { get; set; }
        public string Content { get; set; }
        public double LeaveDaysPerMonth { get; set; }
        public double LeaveDaysPerYearExperience { get; set; }
        public double DaysCarriedForwardPerYear { get; set; }
        public StatusEnum Status { get; set; }
    }
}
