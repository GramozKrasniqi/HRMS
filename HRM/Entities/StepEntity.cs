using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class StepEntity
    {
        public string Id { get; set; }
        public string GradeId { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
    }
}
