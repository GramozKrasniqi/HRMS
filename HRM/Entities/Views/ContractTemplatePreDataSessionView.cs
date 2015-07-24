using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class ContractTemplatePreDataSessionView
    {
        public ContractTemplatePreDataSessionView()
        {
            LeaveDaysPerMonth = 0;
            LeaveDaysPerYearExperience = 0;
            DaysCarriedForward = 0;
            HolidayGroups = new List<HolidayGroupEntity>();
            Languages = new List<LanguageEntity>();
        }

        public double LeaveDaysPerMonth { get; set; }
        public double LeaveDaysPerYearExperience { get; set; }
        public double DaysCarriedForward { get; set; }
        public List<HolidayGroupEntity> HolidayGroups { get; set; }
        public List<LanguageEntity> Languages { get; set; }
    }
}
