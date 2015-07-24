using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class PayScaleItemEntity
    {
        public string JobCode { get; set; }
        public int ContractTemplateId { get; set; }
        public string GradeId { get; set; }
        public double GradeKCB { get; set; }
        public double GradeEntry { get; set; }
        public string StepId { get; set; }
        public int StepEntry { get; set; }
    }
}
