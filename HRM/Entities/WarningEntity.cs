using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class WarningEntity
    {
        public int Id { get; set; }
        public int WarnerId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
    }
}
