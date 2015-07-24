using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.Views;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.Employee
{
    public partial class JobDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EmployeeId"] == null)
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                if (Session["JobDetails"] != null)
                {
                    #warning if this is not null set the values of the form from this session value
                }

                EmployeeView view = new EmployeeMapper()
                    .Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });

                if (view.EmployeeNo != null)
                {
                    if (new ContractMapper().GetLastContract(new ContractEntity() { EmployeeId = view.Id }).ContractNumber == null)
                    {
                        Session.Add("EmployeeId", Request.QueryString["EmployeeId"]);
                    }
                    else
                    {
                        Response.Redirect("Details.aspx?EmployeeId="+Request.QueryString["EmployeeId"]);
                    }
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            JobDetailsSessionView jbs = new JobDetailsSessionView();

            FunctionalLevelEntity flentity = new FunctionalLevelEntity();
            flentity.Id = Convert.ToInt32(FunctionalLevelDropDownList.SelectedValue);
            flentity = new FunctionalLevelMapper().Get(flentity);
            jbs.FunctionalLevel = flentity;

            OrganizationalUnitEntity ouentity = new OrganizationalUnitEntity();
            ouentity.Id = Convert.ToInt32(OrganisationalUnitDropDownList.SelectedValue);
            OrganizationalUnitView ouView = new OrganizationalUnitMapper().Get(ouentity);
            jbs.OrganisationalUnit = ouView;

            GradeEntity gentity = new GradeEntity();
            gentity.Id = GradeDropDownList.SelectedValue;
            gentity = new GradeMapper().Get(gentity);
            jbs.Grade = gentity;

            JobTitleEntity job = new JobTitleEntity();
            job.JobCode = JobDetailsDropDownList.SelectedValue;
            JobTitleView jobview = new JobTitleMapper().Get(job);
            jbs.Job = jobview;

            StepEntity sentity = new StepEntity();
            sentity.Id = StepDropDownList.SelectedValue;
            sentity = new StepMapper().Get(sentity);
            jbs.Step = sentity;

            
            foreach (ListItem item in ContractsCheckBoxList.Items)
            {
                if (item.Selected == true)
                {
                    jbs.ContractsTemplates.Add(new ContractTemplateEntity() { Id = Convert.ToInt32(item.Value), Title = item.Text });
                }
            }

            Session.Add("JobDetails", jbs);
            Response.Redirect("Contract.aspx?EmployeeId=" + Request.QueryString["EmployeeId"] + "&ContractTemplateId=" + jbs.ContractsTemplates[0].Id);
        }
    }
}