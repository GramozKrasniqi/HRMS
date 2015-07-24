using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.Views;
using DAL.Mapper;
using Entities;

namespace HRM.HR_Managment.JobTitle
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["jobCode"] != null)
            {
                if (!IsPostBack)
                {
                    JobTitleView view = new JobTitleMapper().Get(new JobTitleEntity() { JobCode = Request.QueryString["jobCode"] });
                    if (view.Code != "")
                    {
                        JobCodeCurrentLabel.InnerText = Request.QueryString["jobCode"];
                        JobTitleTextBox.Text = view.Title;

                        JobTitleView jobView = new JobTitleMapper().GetParent(view.Code);
                        ReportsToCascadingDropDown.ContextKey = jobView.Title;

                        OrganizationalUnitView orgView = new OrganizationalUnitMapper().Get(view.OrganisationalUnit);
                        OrganizationalUnitCascadingDropDown.ContextKey = orgView.TitleAndOrganizationaUnitGroup;
                    }
                    else
                    {
                        Response.Redirect("List.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("List.aspx");
            }

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            JobTitleEntity jbe = new JobTitleEntity();
            jbe.JobCode = Request.QueryString["jobCode"];
            jbe.Title = JobTitleTextBox.Text;
            jbe.Description = OtherInfoTextBox.Text;
            jbe.OrganizationalUnitId = Convert.ToInt32(OrganizationalUnitDropDownList.SelectedValue);

            if (ReportsToDropDownList.SelectedValue != "")
            {
                new JobTitleMapper().Update(jbe, ReportsToDropDownList.SelectedValue);
            }
            else
            {
                new JobTitleMapper().Update(jbe, null);
            }
            Response.Redirect("DefineGrade.aspx?jobCode=" + jbe.JobCode);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}