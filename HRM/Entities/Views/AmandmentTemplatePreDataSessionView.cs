using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class AmandmentTemplatePreDataSessionView
    {
        public AmandmentTemplatePreDataSessionView()
        {
            Languages = new List<LanguageEntity>();
        }
        public List<LanguageEntity> Languages { get; set; }
    }
}
