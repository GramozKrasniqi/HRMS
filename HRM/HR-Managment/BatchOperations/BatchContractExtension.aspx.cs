using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Entities.Views;
using DAL.Mapper;
using System.Web.Services;
using System.Web.Script.Services;
using Entities;
using System.Text;

namespace HRM.HR_Managment.BatchOperations
{
    public partial class BatchContractExtension : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContractTemplateCascadingDropDown.ServicePath = "~/HRMWebServices.asmx";
            ContractTemplateCascadingDropDown.Category = "ContractTemplate";
            ContractTemplateCascadingDropDown.ServiceMethod = "GetContractTemplatesFromCurrentJobDetails";

            if (RadioButtonList1.SelectedItem.Value != "1")
            {
                System.Web.UI.HtmlControls.HtmlGenericControl li = new System.Web.UI.HtmlControls.HtmlGenericControl("li");
                System.Web.UI.HtmlControls.HtmlGenericControl span = new System.Web.UI.HtmlControls.HtmlGenericControl("label");
                span.InnerText = "Amandament template:";
                span.ID = "AmandamentTemplateLabel";
                span.Attributes.Add("for", "AmandamentTemplateDropDownList");
                li.Controls.Add(span);
                DropDownList ddl = new DropDownList();
                ddl.ID = "AmandamentTemplateDropDownList";
                li.Controls.Add(ddl);
                RequiredFieldValidator rfv = new RequiredFieldValidator();
                rfv.ID = "AmandamentTemplateRequiredFieldValidator";
                rfv.ControlToValidate = "AmandamentTemplateDropDownList";
                rfv.Display = ValidatorDisplay.None;
                rfv.ErrorMessage = "Please select an amandament template.";
                rfv.InitialValue = "";
                li.Controls.Add(rfv);
                CascadingDropDown cdd = new CascadingDropDown();
                cdd.ID = "AmandamentTemplateCascadingDropDown";
                cdd.ServicePath = "~/HRMWebServices.asmx";
                cdd.Category = "AmandamentTemplate";
                cdd.ServiceMethod = "GetAmandamentTemplates";
                cdd.TargetControlID = "AmandamentTemplateDropDownList";
                cdd.ContextKey = "";
                cdd.PromptText = "Please select";
                li.Controls.Add(cdd);

                doubleTemplate.Controls.Add(li);
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            string strings = jsfields.Value;
            StringBuilder stb = new StringBuilder();
            stb.Append("employeeId=");
            stb.Append(strings);

            List<string> list = strings.Split(',').ToList();

            DateTime startdt;
            DateTime enddt;
            DateTime.TryParseExact(StartDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out startdt);
            DateTime.TryParseExact(EndDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out enddt);

            foreach (string s in list)
            {
                if (!s.StartsWith("0"))
                {
                    int i = Convert.ToInt32(s);

                    EmployeeView employeeView = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(s) });

                    ContractEntity lastContract = new ContractMapper().GetLastContract(new ContractEntity() { EmployeeId = employeeView.Id });

#warning change the 1 value parameter of getContentById
                    ContractTemplateEntity cte = new ContractTemplateMapper().GetContentById(Convert.ToInt32(ContractTemplateDropDownList.SelectedValue), 1);

                    JobDetailsSessionView jsv = new JobDetailsSessionView();
                    CurrentJobDetailsEntity cjde = new CurrentJobDetailsMapper().Get(new CurrentJobDetailsEntity() { EmployeeId = employeeView.Id, ContractNumber = (employeeView.Id + " / " + cte.Preffix) });

                    jsv.FunctionalLevel.Id = cjde.FunctionalLevelId;
                    jsv.FunctionalLevel.Title = cjde.FunctionalLevelTitle;

                    jsv.Grade.Id = cjde.GradeId;
                    jsv.Grade = new GradeMapper().Get(jsv.Grade);

                    jsv.Job.Code = cjde.JobCode;
                    jsv.Job.Title = cjde.JobTitle;

                    jsv.OrganisationalUnit.Id = cjde.OrganizationalUnitId;
                    jsv.OrganisationalUnit.Title = cjde.OrganizationalUnitTitle;

                    #warning changed review and edit

                    jsv.Step.Id = cjde.StepId;
                    //jsv.Step.Entry = cjde.StepEntry;

                    if (RadioButtonList1.SelectedItem.Value != "1")
                    {
                        AmandamentTemplateEntity amte = new AmandamentTemplateMapper().GetContentById(Convert.ToInt32(RadioButtonList1.SelectedValue), null);
                        AmandamentEntity am = new AmandamentEntity(cjde);

                        am.Status = StatusEnum.Active;

                        am.Content.Content = new GUIHelper().ReplaceTemplateContractWithConcreteContract(amte.Content, jsv, employeeView);
                        am.ContractNumber = cjde.ContractNumber;
                        am.Content.Content = am.Content.Content.Replace(@"{#ContractNumber}", am.ContractNumber);
                        am.StartDate = startdt;

                        #warning check for contract type Probation if this is first contract it is probation and also check if it is special contract
                        
                        if (enddt != null)
                        {
                            am.EndDate = enddt;
                            am.Type = ContractType.Limited;

                            TimeSpan span = am.EndDate.Value.Subtract(am.StartDate);
                            double years = span.TotalDays / 365;
                            if (years > 10)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("<script language='javascript'>displayNoty('The amandment that is not for idifinite period cannot be for more than 10 years.');</script>");

                                // if the script is not already registered
                                if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());

                                return;
                            }
                        }
                        else
                        {
                            am.Type = ContractType.Permanent;
                        }

                        new AmandamentMapper().Insert(am, employeeView.Id);
                    }
                    else
                    {
                        ContractEntity ct = new ContractEntity(cjde, employeeView);
                        ct.Content.Content = new GUIHelper().ReplaceTemplateContractWithConcreteContract(cte.Content, jsv, employeeView);

                        string dt = DateTime.Now.ToString("dd.MM.yyyy");
                        dt = dt.Replace(".", "");
                        ct.ContractNumber = (employeeView.EmployeeNo.Replace("AKP", "") + " / " + cte.Preffix + " / " + dt);

                        ct.Status = StatusEnum.Active;
                        ct.ContractStatus = ContractStatus.Aproved;
                        ct.OfficiallyApprovedDate = DateTime.Now;
                        ct.ContractTemplateTitle = cte.Preffix;

                        ct.Content.Content = ct.Content.Content.Replace(@"{#ContractNumber}", ct.ContractNumber);

                        ct.StartDate = startdt;
                        if (enddt != null)
                        {
                            ct.EndDate = enddt;
                            ct.Type = ContractType.Limited;

                            TimeSpan span = ct.EndDate.Value.Subtract(ct.StartDate);
                            double years = span.TotalDays / 365;
                            if (years > 10)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("<script language='javascript'>displayNoty('The contract that is not for idifinite period cannot be for more than 10 years.');</script>");

                                // if the script is not already registered
                                if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());

                                return;
                            }
                        }
                        else
                        {
                            ct.Type = ContractType.Permanent;
                        }

#warning bug please check

                        //new ContractMapper().Insert(ct);

#warning this dosent exists why
                        //new ContractMapper().UpdatePreviousContract(new ContractEntity() { ContractNumber = lastContract.ContractNumber, NextContractNumber = ct.ContractNumber, ContractStatus = Entities.ContractStatus.Changed, Status = StatusEnum.Pasive });
                    }

                }
            }
            if (RadioButtonList1.SelectedItem.Value != "1")
            {
                Response.Redirect("Print.aspx?" + stb + "&type=newAmandament");

            }
            else
            {
                Response.Redirect("Print.aspx?" + stb + "&type=newContract");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<G_JSTree> GetAllNodes(string id, string isOrganizationUnit, string contractTemplateId)
        {

            List<G_JSTree> list = new List<G_JSTree>();
            if (isOrganizationUnit == "False")
                return list;

            if (id == "0")
            {
                List<OrganizationalUnitView> organizationalUnits = new OrganizationalUnitMapper().List("");
                foreach (OrganizationalUnitView organizationalUnit in organizationalUnits)
                {
                    G_JSTree parent = new G_JSTree();
                    parent.data = organizationalUnit.Title;
                    parent.state = "closed";
                    parent.IdServerUse = 10;
                    parent.attr = new G_JsTreeAttribute { id = "0" + organizationalUnit.Id.ToString(), selected = false, isOrganizationUnit = true };

                    list.Add(parent);
                }
            }
            else
            {
                List<EmployeeView> employees = new List<EmployeeView>();
                if (contractTemplateId != "0")
                {
                    employees = new EmployeeMapper().ListWithAdvancedFilterByContractPreffix("", "", "", Convert.ToInt32(id), "", StatusEnum.Active, Convert.ToInt32(contractTemplateId));
                }
                else
                {
                    employees = new EmployeeMapper().ListWithAdvancedFilterByContractPreffix("", "", "", Convert.ToInt32(id), "", StatusEnum.Active, null);
                }
                foreach (EmployeeView employee in employees)
                {
                    G_JSTree child = new G_JSTree();
                    child.data = employee.ToString();
                    child.state = "closed";
                    child.IdServerUse = 10;
                    child.children = null;
                    child.attr = new G_JsTreeAttribute { id = employee.Id.ToString(), selected = false, isOrganizationUnit = false };
                    list.Add(child);
                }
            }

            return list;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<G_JSTree> SaveNodes(string id, string isOrganizationUnit)
        {

            List<G_JSTree> list = new List<G_JSTree>();
            if (isOrganizationUnit == "False")
                return list;

            if (id == "0")
            {
                List<OrganizationalUnitView> organizationalUnits = new OrganizationalUnitMapper().List("");
                foreach (OrganizationalUnitView organizationalUnit in organizationalUnits)
                {
                    G_JSTree parent = new G_JSTree();
                    parent.data = organizationalUnit.Title;
                    parent.state = "closed";
                    parent.IdServerUse = 10;
                    parent.attr = new G_JsTreeAttribute { id = organizationalUnit.Id.ToString(), selected = false, isOrganizationUnit = true };

                    list.Add(parent);
                }
            }
            else
            {
                List<EmployeeView> employees = new EmployeeMapper().ListWithAdvancedFilter("", "", "", Convert.ToInt32(id), "", StatusEnum.Active);

                foreach (EmployeeView employee in employees)
                {
                    G_JSTree child = new G_JSTree();
                    child.data = employee.ToString();
                    child.state = "closed";
                    child.IdServerUse = 10;
                    child.children = null;
                    child.attr = new G_JsTreeAttribute { id = employee.Id.ToString(), selected = false, isOrganizationUnit = false };
                    list.Add(child);
                }
            }

            return list;
        }
    }
}