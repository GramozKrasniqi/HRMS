using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using System.DirectoryServices.AccountManagement;

namespace HRM.HR_Managment.Leaves.LeaveRequest
{
    public partial class Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            LeaveRequestEntity entity = new LeaveRequestEntity();
            entity.LeaveTypeId = Convert.ToInt32(LeaveTypeDropDownList.SelectedValue);
            entity.RequestDate = DateTime.Now;

            DateTime dt;
            if (DateTime.TryParseExact(StartDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                entity.StartDate = dt;
            }
            if (!IsHalfDayCheckBox.Checked)
            {
                if (DateTime.TryParseExact(EndDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    entity.EndDate = dt;
                }
            }
            entity.Notes = OtherInfoTextBox.Text;

            entity.EmployeeId = new UserMapper().GetUserByUserName(UserPrincipal.Current.SamAccountName).EmployeeId;
            entity.AlternatePersonId = Convert.ToInt32(AlternateEmployeeDropDownList.SelectedValue);
            #warning set Manager to managerEmployeeId
            //entity.ManagerEmployeeId = 
            entity.PaymentTypeId = Convert.ToInt32(PaymentTypeDropDownList.SelectedValue);

            entity.LeaveStatus = RequestsEnum.Request;

            new LeaveRequestMapper().RequestLeave(entity);

            #warning set this to a good mail message
            string[] to = {"gramoz.krasniqi@kpaonline.org"};
            SendMail.Send(to, "Hi", ("HR Test from system. LeaveRequest by employee Id" + entity.EmployeeId) );

            Response.Redirect("List.aspx");
        }

        protected void IsHalfDayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsHalfDayCheckBox.Checked)
            {
                EndDateTextBox.Enabled = false;
            }
            else
            {
                EndDateTextBox.Enabled = true;
            }
        }
    }
}