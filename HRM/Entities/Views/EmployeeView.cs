using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class EmployeeView
    {
        public EmployeeView()
        {
            CurrentJobDetails = new CurrentJobDetailsEntity();
        }

        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public GenderEnum Gender { get; set; }
        public string PersonalNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string MobilePhone { get; set; }
        public string WorkEmail { get; set; }
        public string OtherEmail { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public DateTime JoiningDate { get; set; }
        public StatusEnum Status { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public byte[] Image { get; set; }
        private CurrentJobDetailsEntity CurrentJobDetails { get; set; }
        public string Job 
        {
            get
            { return CurrentJobDetails.JobTitle; }
            set
            {
                CurrentJobDetails.JobTitle = value;
            }
        }

        public string OrganizationalUnit 
        {
            get
            { return CurrentJobDetails.OrganizationalUnitTitle; }
            set
            {
                CurrentJobDetails.OrganizationalUnitTitle = value;
            }
        }

        public override string ToString()
        {
            return Firstname + " " + Middlename + " " + Lastname;
        }
    }
}
