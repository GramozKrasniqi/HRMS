using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class ComplaintView
    {
        public string ComplaintNr { get; set; }
        public EmployeeView Complainter { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public RequestsEnum Status { get; set; }

        public List<EmployeeView> AgainstEmployees { get; set; }

        public override string ToString()
        {
            return Complainter.Firstname + " " + Complainter.Lastname + " / " + Subject;
        }
    }
}
