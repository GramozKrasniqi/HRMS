using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Views;

namespace Entities
{
    public class ContractEntity
    {

        public ContractEntity(CurrentJobDetailsEntity cjde, EmployeeView empl)
        {
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

            this.EmployeeId = empl.Id;
            this.EmployeeFirstname = empl.Firstname;
            this.EmployeeLastname = empl.Lastname;
            this.EmployeeNo = empl.EmployeeNo;
            this.EmployeePersonalNumber = empl.PersonalNumber;
        }

        public ContractEntity()
        {

        }

        private double _GradeKCB = 0;
        private double _GradeEntry = 0;
        private double _StepEntry = 0;

        public string ContractNumber { get; set; }
        public string ContractTemplateTitle { get; set; }
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
        public string EmployeeNo { get; set; }
        public string EmployeeFirstname { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeePersonalNumber { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public string NextContractNumber { get; set; }
        public int EmployeeId { get; set; }
        public StatusEnum Status { get; set; }

        //Content
        private ContractContentEntity _Content;
        public ContractContentEntity Content 
        {
            get
            {
                if (_Content == null)
                {
                    _Content = new ContractContentEntity();
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
