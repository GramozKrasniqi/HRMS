using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ComplaintEntity
    {
        public string ComplaintNr { get; set; }
        public int ComplainterId { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public RequestsEnum Status { get; set; }
        public List<int> AgainstEmployeesId { get; set; }
    }
}
