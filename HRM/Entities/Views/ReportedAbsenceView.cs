using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class ReportedAbsenceView
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AbsenceEmployee { get; set; }
        public string Manager { get; set; }
        public string Notes { get; set; }
        public RequestsEnum Status { get; set; }
    }
}
