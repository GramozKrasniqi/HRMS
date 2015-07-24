using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ReminderEntity
    {
        public int Id { get; set; }
        public ReminderEnum ReminderType { get; set; }
        public string Url { get; set; }
        public string EntityPK { get; set; }
        public string EntityPKType { get; set; }
        public StatusEnum Status { get; set; }
    }
}
