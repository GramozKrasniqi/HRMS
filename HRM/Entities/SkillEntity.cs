using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class SkillEntity
    {
        public int EmployeeId { get; set; }
        public string SkillName { get; set; }

        public override string ToString()
        {
            return SkillName;
        }
    }
}
