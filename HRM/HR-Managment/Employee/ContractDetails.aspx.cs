using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;

namespace HRM.HR_Managment.Employee
{
    public partial class ContractDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ContractNumber"] != null)
            {
                if (!IsPostBack)
                {
                    CKEditor1.config.toolbar = new object[]
                    {
                        new object[] { "Print"}
                    };

                    Entities.ContractEntity contract = new ContractMapper().GetByLanguageId(new Entities.ContractEntity(){ ContractNumber = Convert.ToString(Server.HtmlDecode(Request.QueryString["ContractNumber"]))}, 1);
                    CKEditor1.Text = contract.Content.Content;
                    ContractNumberLabel.InnerText = contract.ContractNumber;
                    ContractTypeLabel.InnerText = contract.ContractTemplateTitle;
                    OrganizationaUnitLabel.InnerText = contract.OrganizationalUnitTitle;
                    JobCodeLabel.InnerText = contract.JobCode;
                    JobTitleLabel.InnerText = contract.JobTitle;
                    GradeIdLabel.InnerText = contract.GradeId;
                    GradeKCBLabel.InnerText = contract.GradeKCB.ToString("0.00");
                    GradeEntryLabel.InnerText = contract.GradeEntry.ToString("0.00");
                    StepLabel.InnerText = contract.StepId;
                    StepEntryLabel.InnerText = contract.StepEntry.ToString("0.00");
                    GrossValueLabel.InnerText = contract.GrossValue.ToString("0.00");
                    StartDateLabel.InnerText = contract.StartDate.ToString("dd.MM.yyyy");
                    if (contract.EndDate != null)
                    {
                        EndDateLabel.InnerText = ((DateTime)contract.EndDate).ToString("dd.MM.yyyy");
                    }
                    OfficiallyApprovedDateLabel.InnerText = contract.OfficiallyApprovedDate.ToString("dd.MM.yyyy");
                    ContractStatusLabel.InnerText = contract.Status.ToString();
                }
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }
    }
}