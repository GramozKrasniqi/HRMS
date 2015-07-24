using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class CurrentJobDetailsEntity
    {
        public int EmployeeId { get; set; }

        private double _GradeKCB = 0;
        private double _GradeEntry = 0;
        private double _StepEntry = 0;

        public string ContractNumber { get; set; }
        public int FunctionalLevelId { get; set; }
        public string FunctionalLevelTitle { get; set; }
        public int OrganizationalUnitId { get; set; }
        public string OrganizationalUnitTitle { get; set; }
        public string JobCode { get; set; }
        public string JobTitle { get; set; }
        public string GradeId { get; set; }

        public double GradeKCB
        {
            get
            { return _GradeKCB; }
            set
            {
                _GradeKCB = value;
            }
        }
        public double GradeEntry
        {
            get
            { return _GradeEntry; }
            set
            {
                _GradeEntry = value;
            }
        }

        public string StepId { get; set; }

        public double StepEntry
        {
            get
            { return _StepEntry; }
            set
            {
                _StepEntry = value;
            }
        }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ContractType IsWithoutEndDate { get; set; }
        public double GrossValue { get; set; }

        public DateTime JoiningDate { get; set; }

    }
}
