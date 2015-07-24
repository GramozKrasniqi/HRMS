using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using DAL.Mapper;
using Entities.Views;

namespace HRM
{
    public partial class Dashboard : TranslatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string logUser;
            //IIdentity WinId = HttpContext.Current.User.Identity;
            //WindowsIdentity wi = (WindowsIdentity)WinId;
            //logUser = wi.Name.ToString().Substring(wi.Name.ToString().LastIndexOf("\\") + 1);

            logUser = Session["logUser"].ToString();

            UserView user = new UserMapper().GetUserByUserName(logUser);
            EmployeeView emp = new EmployeeMapper().Get(new Entities.EmployeeEntity() { Id = user.EmployeeId });

            NameSurnameLabel.Text = emp.ToString();
            PersonalNoLabel.Text = emp.PersonalNumber;
            EmployeeNoLabel.Text = emp.EmployeeNo;
            UsernameLabel.Text = logUser;
            JobLabel.Text = emp.Job;
            OrganizationUnitLabel.Text = emp.OrganizationalUnit;

            #warning only for hr for simple users set to the EmployeeId
            ReminderView view = new ReminderMapper().GetReminderByType(Entities.ReminderEnum.EmployeeNoContract, null);
            EmployeeWithoutContractCountLabel.Text = view.Count.ToString();
            EmployeesWithoutContractUrl.Attributes.Add("href", view.Url);

            view = new ReminderMapper().GetReminderByType(Entities.ReminderEnum.ContractExpire, null);
            ContractExpireCountLabel.Text = view.Count.ToString();
            ContractExpireUrl.Attributes.Add("href", view.Url);

            view = new ReminderMapper().GetReminderByType(Entities.ReminderEnum.LeaveRequest, null);
            LeaveRequestsCountLabel.Text = view.Count.ToString();
            LeaveRequestsUrl.Attributes.Add("href", view.Url);
        }
    }
}