using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class WarningView
    {
        public int Id { get; set; }
        public string Warner { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return Warner + " / " + Subject;
        }
    }
}
