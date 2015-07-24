using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class FormEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool IsNavVisible { get; set; }
        public int ParentId { get; set; }
        public int Priority { get; set; }
        public bool IsChecked { get; set; }
        public StatusEnum Status { get; set; }
        public int ApplicationId { get; set; }
    }
}
