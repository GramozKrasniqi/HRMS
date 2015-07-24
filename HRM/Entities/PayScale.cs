using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class PayScaleGradeItemEntity
    {
        public string GradeId { get; set; }
        public double GradeKCB { get; set; }
        public double GradeEntry { get; set; }
    }

    public class PayScaleStepItemEntity
    {
        public string StepId { get; set; }
        public double StepEntry { get; set; }
    }
}
