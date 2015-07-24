using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class LeaveRespond
    {
        public int Id { get; set; }
        public int LeaveRequestId { get; set; }
        public RequestsEnum ResponseStatus { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Notes { get; set; }
        public int ResponderId { get; set; }
        public RequestsProcessedByEnum RequestProcessedBy { get; set; }
    }
}
