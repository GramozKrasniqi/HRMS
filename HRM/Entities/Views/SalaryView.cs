using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class SalaryView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Currency { get; set; }
        /// <summary>
        /// This field will be used only when the salary will be listed for the specific job title
        /// </summary>
        public double GrossValue { get; set; }
        public StatusEnum Status { get; set; }
    }
}
