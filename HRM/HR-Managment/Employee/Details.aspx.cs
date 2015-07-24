using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using Entities;
using Entities.Views;
using System.Configuration;

namespace HRM.HR_Managment.Employee
{
    public partial class Details : TranslatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EmployeeId"] != null)
            {
                if (!IsPostBack)
                {
                    ((BoundField)EducationTrainingGridView.Columns[0]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)EducationTrainingGridView.Columns[1]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)EducationTrainingGridView.Columns[1]).NullDisplayText = "On Going";

                    ((BoundField)ExperienceGridView.Columns[0]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)ExperienceGridView.Columns[1]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)ExperienceGridView.Columns[1]).NullDisplayText = "On Going";

                    ((BoundField)EmployeeActiveContractsGridView.Columns[4]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)EmployeeActiveContractsGridView.Columns[5]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)EmployeeActiveContractsGridView.Columns[5]).NullDisplayText = "Indifinite";

                    ((BoundField)EmployeeExpiredContractsGridView.Columns[4]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                    ((BoundField)EmployeeExpiredContractsGridView.Columns[5]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + " }";

                    EmployeeView view = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });
                    if (view.Id != 0)
                    {
                        EmployeeNameLabel.Text = view.ToString();
                        JobTitleAndUnitLabel.Text = view.Job + " at " + view.OrganizationalUnit;
                        EmployeeNoLabel.InnerText = view.EmployeeNo;
                        PersonalNoLabel.InnerText = view.PersonalNumber;
                        DateOfBirthLabel.InnerText = view.DateOfBirth.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                        
                        #warning change the static language number
                        GenderLabel.InnerText = TranslateApplicationString(2, view.Gender.ToString());
                        
                        CountryLabel.InnerText = view.Country;
                        NationalityNoLabel.InnerText = view.Nationality;
                        CityLabel.InnerText = view.City;
                        tMobilePhoneLabel.InnerText = view.MobilePhone;
                        WorkEmailLabel.InnerText = view.WorkEmail;

                        if (view.Image != null)
                        {
                            Session["fileContents_"] = view.Image;
                            string relativePath = Page.AppRelativeVirtualPath;
                            relativePath = relativePath.Replace("~", "");
                            empployeeImage.ImageUrl = String.Format("/HRM" + relativePath + "?preview=1");
                        }

                        EmployeeEditHyperLink.NavigateUrl = "PersonalInformation.aspx?action=update&EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);
                        EducationTrainingHyperLink.NavigateUrl = "EducationAndExperience.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);
                        ExperienceHyperLink.NavigateUrl = "EducationAndExperience.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);
                        EmployeeActiveContractsManageHyperLink.NavigateUrl = "ContractList.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);
                        EmployeePasiveContractsManageHyperLink.NavigateUrl = "ContractList.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);

                        ContractEmployeeHyperLink.NavigateUrl = "JobDetails.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);
                        ChangeContractHyperLink.NavigateUrl = "ContractChange.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);
                        ExtendContractHyperLink.NavigateUrl = "ContractExtend.aspx?EmployeeId=" + Convert.ToInt32(Request.QueryString["EmployeeId"]);

                        if (new ContractMapper().GetLastContract(new ContractEntity() { EmployeeId = view.Id }).ContractNumber != null)
                        {
                            ContractEmployeeHyperLink.Enabled = false;
                        }
                        else
                        {
                            ChangeContractHyperLink.Enabled = false;
                            ExtendContractHyperLink.Enabled = false;
                        }

                        
                    }
                    else
                    {
                        Response.Redirect("List.aspx");
                    }
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }

            if (Request.QueryString["preview"] == "1")
            {
                byte[] fileContents = (byte[])Session["fileContents_"];
                if (fileContents.Length != 0)
                {
                    Session.Remove("fileContents_");
                    Response.Clear();
                    Response.ContentType = "fileContentType_";
                    Response.BinaryWrite(fileContents);
                    Response.End();
                }
            }
        }
    }
}