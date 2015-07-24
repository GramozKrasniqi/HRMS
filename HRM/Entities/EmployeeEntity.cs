using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityId { get; set; }
        public GenderEnum Gender { get; set; }
        public string PersonalNumber { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string MobilePhone { get; set; }
        public string WorkEmail { get; set; }
        public string OtherEmail { get; set; }
        public int BankId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime JoiningDate { get; set; }
        public StatusEnum Status { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public string VacancyAnnouncment { get; set; }
        public byte[] Image { get; set; }
    }
}
