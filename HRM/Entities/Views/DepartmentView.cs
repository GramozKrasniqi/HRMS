using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class DepartmentView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Division { get; set; }
        public int EmployeesCount { get; set; }
        public StatusEnum Status { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
