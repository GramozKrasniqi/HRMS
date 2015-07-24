using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using AjaxControlToolkit;
using Entities;
using DAL.Mapper;
using System.Collections.Specialized;
using Entities.Views;
using System.DirectoryServices.AccountManagement;

namespace HRM
{
    /// <summary>
    /// Summary description for HRMWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class HRMWebServices : System.Web.Services.WebService
    {

        public HRMWebServices()
        {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetNationalities(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<NationalityEntity> list = new NationalityMapper().List("");
            foreach (NationalityEntity ent in list)
            {
                CascadingDropDownNameValue cdnv;

                if (ent.Title == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                }
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetCountrie(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<CountryEntity> list = new CountryMapper().List("");
            foreach (CountryEntity ent in list)
            {
                CascadingDropDownNameValue cdnv;

                if (ent.Title == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetFunctionalLevels(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<FunctionalLevelEntity> list = new FunctionalLevelMapper().List("");
            foreach (FunctionalLevelEntity ent in list)
            {
                CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetOrganizationalUnitGroups(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<OrganizationalUnitGroupEntity> list = new OrganizationalUnitGroupMapper().List("");

            foreach (OrganizationalUnitGroupEntity ent in list)
            {
                CascadingDropDownNameValue cdnv;
                if (ent.Title == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString(), true);

                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                }
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetOrganizationalUnits(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<OrganizationalUnitView> list = new OrganizationalUnitMapper().List("");
            foreach (OrganizationalUnitView ent in list)
            {
                CascadingDropDownNameValue cdnv;
                if (ent.TitleAndOrganizationaUnitGroup == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(ent.TitleAndOrganizationaUnitGroup, ent.Id.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(ent.TitleAndOrganizationaUnitGroup, ent.Id.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetJobTitlesByOrganisationalUnit(string knownCategoryValues, string category, string contextKey)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            int organisationalId;
            if (!kv.ContainsKey("OrganizationalUnit") ||
            !Int32.TryParse(kv["OrganizationalUnit"], out organisationalId))
            {

                List<JobTitleView> list = new JobTitleMapper().ListByOrganisationalUnitId(null, "", StatusEnum.Active);
                foreach (JobTitleView ent in list)
                {
                    CascadingDropDownNameValue cdnv;
                    if (ent.Title == contextKey)
                    {
                        cdnv = new CascadingDropDownNameValue(ent.Title, ent.Code, true);
                        values.Add(cdnv);
                    }
                    else
                    {
                        cdnv = new CascadingDropDownNameValue(ent.Title, ent.Code);
                        values.Add(cdnv);
                    }
                }
            }
            else
            {

                List<JobTitleView> list = new JobTitleMapper().ListByOrganisationalUnitId(organisationalId, "", StatusEnum.Active);
                foreach (JobTitleView ent in list)
                {
                    CascadingDropDownNameValue cdnv;
                    if (ent.Title == contextKey)
                    {
                        cdnv = new CascadingDropDownNameValue(ent.Title, ent.Code, true);
                        values.Add(cdnv);
                    }
                    else
                    {
                        cdnv = new CascadingDropDownNameValue(ent.Title, ent.Code);
                        values.Add(cdnv);
                    }
                }
            }
            return values.ToArray();
        }


        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetPaymentTypesByLeaveType(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int leaveTypelId;
            if (!kv.ContainsKey("LeaveTypes") ||
            !Int32.TryParse(kv["LeaveTypes"], out leaveTypelId))
            {
                return null;
            }

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<LeaveTypeLevelEntity> list = new LeaveTypeLevelMapper().List(leaveTypelId);
            foreach (LeaveTypeLevelEntity ent in list)
            {
                CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(ent.LeaveNameType.ToString(), ent.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetEmployeesByOrganisationalUnit(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            int organisationalId;
            if (!kv.ContainsKey("OrganizationalUnit") ||
            !Int32.TryParse(kv["OrganizationalUnit"], out organisationalId))
            {
#warning change this code to get ur organisation unit and also do not display yourself
                //Get my organizational unit
                int myorganizationUnit = 20;
                List<EmployeeView> list = new EmployeeMapper().ListWithAdvancedFilter("", "", null, myorganizationUnit, null, StatusEnum.Active);
                foreach (EmployeeView ent in list)
                {
                    CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(ent.ToString(), ent.Id.ToString());
                    values.Add(cdnv);
                }
            }
            else
            {
                List<EmployeeView> list = new EmployeeMapper().ListWithAdvancedFilter("", "", null, organisationalId, null, StatusEnum.Active);
                foreach (EmployeeView ent in list)
                {
                    CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(ent.ToString(), ent.Id.ToString());
                    values.Add(cdnv);
                }
            }
            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetStepsByGradeId(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            string gradeId;
            if (!kv.ContainsKey("Grade"))
            {
                return null;
            }
            gradeId = kv["Grade"];

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<StepEntity> list = new StepMapper().ListByGradeId(gradeId);
            foreach (StepEntity ent in list)
            {
                string text = (ent.Id);
                CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(text, ent.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetGradesByJobCode(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            string jobCode;
            if (!kv.ContainsKey("JobTitle"))
            {
                return null;
            }
            jobCode = kv["JobTitle"];

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<GradeEntity> list = new GradeMapper().ListByJobeCode(jobCode);
            foreach (GradeEntity ent in list)
            {
                string text = ent.Id;
                CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(text, ent.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetContractsTemplates(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<ContractTemplateEntity> list = new ContractTemplateMapper().ListWithAdvancedFilter("", StatusEnum.Active);
            foreach (ContractTemplateEntity ent in list)
            {
                CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetBanks(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<BankEntity> list = new BankMapper().ListWithAdvancedFilter("", StatusEnum.Active);
            foreach (BankEntity ent in list)
            {
                CascadingDropDownNameValue cdnv;

                if (ent.Title == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                }
                values.Add(cdnv);
            }

            return values.ToArray();
        }


        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetContractTemplatesFromCurrentJobDetails(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            Dictionary<int, string> list = new ContractTemplateMapper().ListTemplateContractsFromCurrentJobDetails();
            foreach (KeyValuePair<int, string> kvp in list)
            {
                CascadingDropDownNameValue cdnv;

                cdnv = new CascadingDropDownNameValue(kvp.Value, kvp.Key.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetAmandamentTemplates(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<AmandamentTemplateEntity> list = new AmandamentTemplateMapper().ListWithAdvancedFilter("", StatusEnum.Active);
            foreach (AmandamentTemplateEntity entity in list)
            {
                CascadingDropDownNameValue cdnv;

                cdnv = new CascadingDropDownNameValue(entity.Title, entity.AmandamentTemplateId.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetWorkTypes(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            string[] workTypesNames = Enum.GetNames(typeof(WorkType));
            Array workTypesValues = Enum.GetValues(typeof(WorkType));

            CascadingDropDownNameValue cdnv;

            for (int i = 1; i <= workTypesNames.Length - 1; i++)
            {
                if (workTypesNames[i] == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(workTypesNames[i], i.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(workTypesNames[i], i.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }
        
        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetPayTypes(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            string[] payTypesNames = Enum.GetNames(typeof(PayType));
            Array payTypesValues = Enum.GetValues(typeof(PayType));

            CascadingDropDownNameValue cdnv;

            for (int i = 1; i <= payTypesNames.Length - 1; i++)
            {
                if (payTypesNames[i] == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(payTypesNames[i], i.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(payTypesNames[i], i.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetGenders(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            string[] genderNames = Enum.GetNames(typeof(GenderEnum));
            Array genderValues = Enum.GetValues(typeof(GenderEnum));

            CascadingDropDownNameValue cdnv;

            for (int i = 1; i <= genderNames.Length - 1; i++)
            {
                if (genderNames[i] == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(genderNames[i], i.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(genderNames[i], i.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetMaritalStatus(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            string[] maritalStatusNames = Enum.GetNames(typeof(MaritalStatusEnum));
            Array maritalStatusValues = Enum.GetValues(typeof(MaritalStatusEnum));

            CascadingDropDownNameValue cdnv;

            for (int i = 1; i <= maritalStatusNames.Length - 1; i++)
            {
                if (maritalStatusNames[i] == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(maritalStatusNames[i], i.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(maritalStatusNames[i], i.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetEducationTrainingLevels(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            string[] organizationalLevelNames = Enum.GetNames(typeof(EducationTrainingLevelEnum));
            Array organizationalLevelValues = Enum.GetValues(typeof(EducationTrainingLevelEnum));

            CascadingDropDownNameValue cdnv;

            for (int i = 1; i <= organizationalLevelNames.Length - 1; i++)
            {
                if (organizationalLevelNames[i] == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(organizationalLevelNames[i], i.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(organizationalLevelNames[i], i.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetPaymentTypes(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            string[] paymentTypeNames = Enum.GetNames(typeof(LeaveNameType));
            Array paymentTypeValues = Enum.GetValues(typeof(LeaveNameType));

            CascadingDropDownNameValue cdnv;

            for (int i = 1; i <= paymentTypeNames.Length - 1; i++)
            {
                if (paymentTypeNames[i] == contextKey)
                {
                    cdnv = new CascadingDropDownNameValue(paymentTypeNames[i], i.ToString(), true);
                }
                else
                {
                    cdnv = new CascadingDropDownNameValue(paymentTypeNames[i], i.ToString());
                }

                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetRoles(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<RoleEntity> list = new RoleMapper().List("");
            foreach (RoleEntity ent in list)
            {
                CascadingDropDownNameValue cdnv = new CascadingDropDownNameValue(ent.Title, ent.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public string[] GetUsersList(string prefixText, int count)
        {
            List<string> results = new List<string>();

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal qbeUser = new UserPrincipal(ctx);
            qbeUser.DisplayName = "*" + prefixText + "*";
            PrincipalSearcher searcher = new PrincipalSearcher(qbeUser);
            foreach (var found in searcher.FindAll())
            {
                results.Add(found.SamAccountName);
            }

            return results.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public string[] GetEmployees(string prefixText, int count)
        {
            List<string> results = new List<string>();

            List<EmployeeView> list = new EmployeeMapper().ListWithAdvancedFilter("", prefixText, "", null, "", StatusEnum.Active);

            foreach (EmployeeView e in list)
            {
                results.Add(e.ToString() + " - " + e.EmployeeNo);
            }

            return results.ToArray();
        }

        [WebMethod]
        [ScriptMethod]
        public CascadingDropDownNameValue[] GetLeaveTypes(string knownCategoryValues, string category, string contextKey)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            List<LeaveTypeEntity> list = new LeaveTypeMapper().List("");
            foreach (LeaveTypeEntity entity in list)
            {
                CascadingDropDownNameValue cdnv;

                cdnv = new CascadingDropDownNameValue(entity.Title, entity.Id.ToString());
                values.Add(cdnv);
            }

            return values.ToArray();
        }
    }

}
