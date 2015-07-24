using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AmandamentTemplateEntity
    {
        public int AmandamentTemplateId { get; set; }
        public string Title { get; set; }
        public int LanguageId { get; set; }
        public string Content { get; set; }
        public StatusEnum Status { get; set; }
    }
}
