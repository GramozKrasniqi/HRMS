using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AmandamentContentEntity 
    {
        public string ContractNumber { get; set; }
        public int AmandamentId { get; set; }
        public int LanguageId { get; set; }
        public string Content { get; set; }
    }
}
