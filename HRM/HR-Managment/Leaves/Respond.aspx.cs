using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using Entities.Views;
using System.DirectoryServices.AccountManagement;

namespace HRM.HR_Managment.Leaves
{
    public partial class Respond : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LeaveRequestId"] == null)
            {
                Response.Redirect("/HRM/Dashboard.aspx");
            }
            else
            {
                int requestId = Convert.ToInt32(Request.QueryString["LeaveRequestId"]);
                LeaveRequestView entity = new LeaveRequestMapper().Get(requestId);
                RequestsProcessedByEnum status = new LeaveRespondMapper().GetLeaveStatus(requestId);
                if (status == RequestsProcessedByEnum.NotDefined)
                {
                    if (entity.AlternateEmployee != UserPrincipal.Current.SamAccountName)
                    {
                        Response.Redirect("/HRM/Authorization.aspx");
                    }
                }
                else if (status == RequestsProcessedByEnum.Alternate)
                {
                    if (entity.ManagerEmployee != UserPrincipal.Current.SamAccountName)
                    {
                        Response.Redirect("/HRM/Authorization.aspx");
                    }
                }

                if (entity.Id != 0)
                {
                    LeaveTypeLabel.InnerText = entity.LeaveType;
                    RequestDateLabel.InnerText = entity.RequestDate.ToString("dd.MM.yyyy");
                    StartDateLabel.InnerText = entity.StartDate.ToString("dd.MM.yyyy");
                    if (entity.IsHalfDay)
                    {
                        IsHalfDayLabel.InnerText = "Yes";
                    }
                    else
                    {
                        IsHalfDayLabel.InnerText = "No";
                    }
                    EndDateLabel.InnerText = entity.EndDate.ToString("dd.MM.yyyy");
                    CalculatedNumberOfDaysLabel.InnerText = "Not done yet";
                    NotesLabel.InnerText = entity.Notes;
                    AlternatePersonLabel.InnerText = entity.AlternateEmployee;
                    ManagerLabel.InnerText = entity.ManagerEmployee;
                }
                else
                {
                    Response.Redirect("/HRM/Dashboard.aspx");
                }
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            LeaveRequestView view = new LeaveRequestMapper().Get(Convert.ToInt32(Request.QueryString["LeaveRequestId"]));

            //What about if the alternate manager and hr are the same problem / we have a problem
            #warning Warning of design concerns
            
            if (view.AlternateEmployee == view.ManagerEmployee)
            {
                AproveAsAlternateAndManager();
            }
            else
            {
                LeaveRespond respond = new LeaveRespond();
                respond.LeaveRequestId = Convert.ToInt32(Request.QueryString["LeaveRequestId"]);
                respond.Notes = "";
                respond.ResponderId = new UserMapper().GetUserByUserName(UserPrincipal.Current.SamAccountName).EmployeeId;
                respond.ResponseDate = DateTime.Now;
                respond.ResponseStatus = RequestsEnum.Processed;

                if (view.AlternateEmployee == UserPrincipal.Current.SamAccountName)
                {
                    respond.RequestProcessedBy = RequestsProcessedByEnum.Alternate;
                }
                if (view.ManagerEmployee == UserPrincipal.Current.SamAccountName)
                {
                    respond.RequestProcessedBy = RequestsProcessedByEnum.Manager;
                }
                else
                {
                    respond.RequestProcessedBy = RequestsProcessedByEnum.HRM;
                }
                new LeaveRespondMapper().Respond(respond);
            }

            Response.Redirect("/HRM/Dashboard.aspx");
        }

        private void AproveAsAlternateAndManager()
        {
            LeaveRespond respond = new LeaveRespond();
            respond.LeaveRequestId = Convert.ToInt32(Request.QueryString["LeaveRequestId"]);
            respond.Notes = "";
            respond.ResponderId = new UserMapper().GetUserByUserName(UserPrincipal.Current.SamAccountName).EmployeeId;
            respond.ResponseDate = DateTime.Now;
            respond.ResponseStatus = RequestsEnum.Processed;

            respond.RequestProcessedBy = RequestsProcessedByEnum.Alternate;
            new LeaveRespondMapper().Respond(respond);

            respond = new LeaveRespond();
            respond.LeaveRequestId = Convert.ToInt32(Request.QueryString["LeaveRequestId"]);
            respond.Notes = "";
            respond.ResponderId = new UserMapper().GetUserByUserName(UserPrincipal.Current.SamAccountName).EmployeeId;
            respond.ResponseDate = DateTime.Now;
            respond.ResponseStatus = RequestsEnum.Processed;

            respond.RequestProcessedBy = RequestsProcessedByEnum.Manager;
            new LeaveRespondMapper().Respond(respond);
        }

        protected void DeclineButton_Click(object sender, EventArgs e)
        {
            LeaveRespond respond = new LeaveRespond();
            respond.LeaveRequestId = Convert.ToInt32(Request.QueryString["LeaveRequestId"]);
            respond.Notes = "";
            respond.ResponderId = new UserMapper().GetUserByUserName(UserPrincipal.Current.SamAccountName).EmployeeId;
            respond.ResponseDate = DateTime.Now;
            respond.ResponseStatus = RequestsEnum.Declined;
            new LeaveRespondMapper().Respond(respond);
            Response.Redirect("/HRM/Dashboard.aspx");
        }
    }
}