using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class ReminderView
    {
        public ReminderView()
        {
            Count = 0;
            Url = "";
        }
        public int Count { get; set; }
        public string Url { get; set; }
    }
}
