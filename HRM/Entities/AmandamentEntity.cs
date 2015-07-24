using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AmandamentEntity
    {
        public AmandamentEntity(CurrentJobDetailsEntity cjde)
        {
            this.ContractNumber = cjde.ContractNumber;
            this.EndDate = cjde.EndDate;
            this.FunctionalLevelId = cjde.FunctionalLevelId;
            this.FunctionalLevelTitle = cjde.FunctionalLevelTitle;
            this.GradeEntry = cjde.GradeEntry;
            this.GradeId = cjde.GradeId;
            this.GradeKCB = cjde.GradeKCB;
            this.GrossValue = cjde.GrossValue;
            this.JobCode = cjde.JobCode;
            this.JobTitle = cjde.JobTitle;
            this.OrganizationalUnitId = cjde.OrganizationalUnitId;
            this.OrganizationalUnitTitle = cjde.OrganizationalUnitTitle;
            this.StartDate = cjde.StartDate;
            this.Status = StatusEnum.Active;
            this.StepEntry = cjde.StepEntry;
            this.StepId = cjde.StepId;
            this.Type = cjde.IsWithoutEndDate;
        }

        public AmandamentEntity()
        {

        }

        private double _GradeKCB = 0;
        private double _GradeEntry = 0;
        private double _StepEntry = 0;

        public string ContractNumber { get; set; }
        public int AmandamentId { get; set; }
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

        public DateTime OfficiallyApprovedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ContractType Type { get; set; }
        public double GrossValue { get; set; }
        public StatusEnum Status { get; set; }

        //Content
        private AmandamentContentEntity _Content;
        public AmandamentContentEntity Content
        {
            get
            {
                if (_Content == null)
                {
                    _Content = new AmandamentContentEntity();
                }

                return _Content;
            }
            set
            {
                _Content = value;
            }
        }
    }
}
