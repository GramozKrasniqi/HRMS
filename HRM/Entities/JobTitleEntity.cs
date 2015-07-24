using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class JobTitleEntity
    {
        public string JobCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrganizationalUnitId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
