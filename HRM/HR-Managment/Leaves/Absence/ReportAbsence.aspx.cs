using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using System.DirectoryServices.AccountManagement;

namespace HRM.HR_Managment.Leaves.Absence
{
    public partial class ReportAbsence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            ReportedAbsenceEntity entity = new ReportedAbsenceEntity();
            entity.ManagerEmployeeId = new UserMapper().GetUserByUserName(UserPrincipal.Current.SamAccountName).EmployeeId;

            entity.AbsenceEmployeeId = Convert.ToInt32(AbsenceEmployeeDropDownList.SelectedValue);
            entity.Notes = OtherInfoTextBox.Text;
            entity.Date = DateTime.Now;

            new ReportedAbsenceMapper().ReportAbsence(entity);

            Response.Redirect("~/Dashboard.aspx");
        }
    }
}