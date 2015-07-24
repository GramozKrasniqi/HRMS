using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public enum StatusEnum
    {
        NotDefined = 0,
        Active = 1,
        Pasive = 2
    }

    public enum ReminderEnum
    {
        NotDefined = 0,
        ContractExpire = 1,
        EmployeeNoContract = 2,
        LeaveRequest = 3,
        Other = 4
    }

    public enum EducationTrainingLevelEnum
    {
        NotDefined = 0,
        PrimarySchool = 1,
        SecondarySchool = 6,
        Beachelor = 2,
        Master = 3,
        PhD = 4,
        Training = 5
    }

    public enum GenderEnum
    {
        NotDefined = 0,
        Male = 1,
        Female = 2
    }

    public enum AmandamentTypeEnum
    {
        NotDefined = 0,
        Extend = 1,
        Change = 2
    }

    public enum RequestsEnum
    {
        NotDefined = 0,
        Request = 1,
        Processed = 2,
        Declined = 3,
        Canceled = 4
    }

    public enum MaritalStatusEnum
    {
        NotDefined = 0,
        Married = 1,
        Single = 2,
        Divorced = 3,
        Widowed = 4
    }

    public enum RequestsProcessedByEnum
    {
        NotDefined = 0,
        Alternate = 1,
        Manager = 2,
        HRM = 3,
    }

    public enum ContractType
    {
        Limited = 0,
        Permanent = 1,
        Probation = 2,
        Special = 3
    }

    public enum ContractStatus
    {
        NotDefined = 0,
        Aproved = 1,
        Refused = 2,
        Pending = 3,
        Extended = 4,
        Changed = 5,
        Terminated = 6
    }

    public enum PayType
    {
        NotDefined = 0,
        AnnualSalary = 1,
        HourlyWage = 2,
        MonthlyPayment = 3,
        PaymentSchema = 4,
        NoPayment = 5
    }

    public enum WorkType
    {
        NotDefined = 0,
        FullTime = 1,
        PartTime = 2
    }

    /// <summary>
    /// Used in the table LeaveTypeLevel column NameType
    /// </summary>
    public enum LeaveNameType
    {
        NotDefined = 0,
        FullPayment = 1,
        PartialPayment = 2,
        NonPayment = 3
    }
}
