using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using Entities.Views;
using System.Web.UI.HtmlControls;
using System.Text;

namespace HRM.HR_Managment.Employee
{
    public partial class Contract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EmployeeId"] == null || Request.QueryString["ContractTemplateId"] == null)
            {
                Response.Redirect("List.aspx");
            }
            if (!IsPostBack)
            {
                ContractTemplateEntity ctemplate = new ContractTemplateMapper()
                    .Get(Convert.ToInt32(Request.QueryString["ContractTemplateId"]));

                ContractTypeHeaderText.Text = "(" + ctemplate.Title + " Contract)";
                ContractTemplateTitleLabel.InnerText = ctemplate.Title;

                string s = DateTime.Now.ToString("dd.MM.yyyy");
                s = s.Replace(".", "");

                EmployeeView employeeView = new EmployeeView();
                employeeView = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });

                ContractNumberTextBox.Text = employeeView.EmployeeNo.Replace("AKP", "") + " / " + ctemplate.Preffix + " / " + s;
            }
            Generate();
        }

        private void Generate()
        {
            List<LanguageEntity> langs = new LanguageMapper().ListForContractTemplate(Convert.ToInt32(Request.QueryString["ContractTemplateId"]));
            foreach (LanguageEntity ent in langs)
            {
                ContractTemplateEntity cte = new ContractTemplateMapper().GetContentById(Convert.ToInt32(Request.QueryString["ContractTemplateId"]), ent.Id);
                GenerateContractVersions(ent.Title, cte);
            }

            GenerateButtons();

        }

        private void GenerateButtons()
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("width", "auto");
            ul.Attributes.Add("margin-top", "12px");
            ul.Attributes.Add("class", "clearfix");

            HtmlGenericControl li = new HtmlGenericControl("li");

            Button proceed = new Button();
            proceed.ID = "ProceedButton";
            proceed.CssClass = "right login_btn";
            proceed.Text = "Proceed";
            proceed.Click += new EventHandler(ProceedButton_Click);

            li.Controls.Add(proceed);

            Button cancel = new Button();
            cancel.ID = "CancelButton";
            cancel.CssClass = "right login_btn";
            cancel.Text = "Cancel";
            cancel.CausesValidation = false;
            cancel.PostBackUrl = "List.aspx";

            li.Controls.Add(cancel);

            Button back = new Button();
            back.ID = "BackButton";
            back.CssClass = "right login_btn";
            back.Text = "Back";
            back.CausesValidation = false;
            back.PostBackUrl = "JobDetails.aspx?EmployeeId=" + Request.QueryString["EmployeeId"];

            li.Controls.Add(back);

            ul.Controls.Add(li);

            contractVersion.Controls.Add(ul);
        }

        private void GenerateContractVersions(string LanguageTitle, ContractTemplateEntity cte)
        {
            HtmlGenericControl parent = new HtmlGenericControl("div");
            parent.Attributes.Add("width", "100%");
            parent.Attributes.Add("clear", "both");

            HtmlGenericControl h2 = new HtmlGenericControl("h2");
            h2.Attributes.Add("id", LanguageTitle + "Title");

            HtmlGenericControl font = new HtmlGenericControl("font");
            font.Attributes.Add("color", "#707070");

            HtmlGenericControl strong = new HtmlGenericControl("strong");

            Label text = new Label();
            text.Text = LanguageTitle + " Version ";

            HyperLink link = new HyperLink();
            link.ID = LanguageTitle + "ShowHyperLink";
            link.CssClass = "fltrht employeeLinkLast employeeLink employeeLinkWithoutEm";
            link.Text = "Show";

            strong.Controls.Add(text);
            font.Controls.Add(strong);
            h2.Controls.Add(font);
            h2.Controls.Add(link);

            HtmlGenericControl container = new HtmlGenericControl("div");
            container.Attributes.Add("id", (LanguageTitle + "Div"));
            container.Attributes.Add("style", "display:none");

            CKEditor.NET.CKEditorControl ckEditor = new CKEditor.NET.CKEditorControl();
            ckEditor.ID = LanguageTitle;
            ckEditor.Height = 500;
            ckEditor.BasePath = "~/ckeditor";
            ckEditor.ReadOnly = true;
            ckEditor.FilebrowserBrowseUrl = "/HRM/ckfinder/ckfinder.html";
            ckEditor.FilebrowserImageBrowseUrl = "/HRM/ckfinder/ckfinder.html?type=Images";
            ckEditor.FilebrowserImageUploadUrl = "/HRM/ckfinder/core/connector/aspx/connector.aBspx?command=QuickUpload&type=Images";
            ckEditor.config.toolbar = new object[]
                {
                    new object[] { "Print"}
                };

            ckEditor.Text = cte.Content;

            #region replaceContractTemplate

            JobDetailsSessionView jbs = (JobDetailsSessionView)Session["JobDetails"];
            jbs.IsGenerated = true;

            EmployeeView employeeView = new EmployeeView();
            employeeView = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });

            ckEditor.Text = ckEditor.Text.Replace(@"{#ContractNumber}", ContractNumberTextBox.Text);
            DateTime dt;
            if (DateTime.TryParseExact(StartDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                ckEditor.Text = ckEditor.Text.Replace(@"{#StartDate}", dt.ToString("dd.MM.yyyy"));
            }
            if (DateTime.TryParseExact(EndDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                ckEditor.Text = ckEditor.Text.Replace(@"{#EndDate}", dt.ToString("dd.MM.yyyy"));
            }
            else
            {
                ckEditor.Text = ckEditor.Text.Replace(@"{#EndDate}", "");
            }

            ckEditor.Text = new GUIHelper().ReplaceTemplateContractWithConcreteContract(ckEditor.Text, jbs, employeeView);

            #endregion

            container.Controls.Add(ckEditor);

            parent.Controls.Add(h2);
            parent.Controls.Add(container);

            contractVersion.Controls.Add(parent);

            StringBuilder sb = new StringBuilder();

            sb.Append("<script language='javascript'>");
            sb.Append("\n");
            sb.Append("$('#" + link.ClientID + "').click(function () {");
            sb.Append("\n");
            sb.Append("if($('#" + link.ClientID + "').text() == 'Hide') {");
            sb.Append("\n");
            sb.Append("$('#" + container.ClientID + "').fadeOut('slow');");
            sb.Append("\n");
            sb.Append("$('#" + link.ClientID + "').text('Show'); }");
            sb.Append("\n");
            sb.Append("else { $('#" + container.ClientID + "').fadeIn('slow');");
            sb.Append("\n");
            sb.Append("$('#" + link.ClientID + "').text('Hide');");
            sb.Append("\n");
            sb.Append("$('html,body').animate({ scrollTop: $('#" + container.ClientID + "').offset().top }, 'slow'); } });");
            sb.Append("\n");
            sb.Append("</script>");

            // if the script is not already registered
            if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), ("HeyPopup" + LanguageTitle)))
                ClientScript.RegisterStartupScript(Page.GetType(), ("HeyPopup" + LanguageTitle), sb.ToString());
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            JobDetailsSessionView jbs = new JobDetailsSessionView();
            if (Session["JobDetails"] != null)
            {
                jbs = (JobDetailsSessionView)Session["JobDetails"];
                if (jbs.IsGenerated != false)
                {
                    ContractEntity entity = new ContractEntity();
                    entity.ContractNumber = ContractNumberTextBox.Text;
                    entity.ContractTemplateTitle = jbs.ContractsTemplates[0].Title;


                    entity.OrganizationalUnitId = jbs.OrganisationalUnit.Id;
                    entity.OrganizationalUnitTitle = jbs.OrganisationalUnit.Title;
                    entity.JobCode = jbs.Job.Code;
                    entity.JobTitle = jbs.Job.Title;
                    entity.GradeId = jbs.Grade.Id;

                    #warning changed review and edit

                    //entity.GradeKCB = jbs.Grade.KCB;
                    //entity.GradeEntry = jbs.Grade.Entry;
                    entity.StepId = jbs.Step.Id;
                    //entity.StepEntry = jbs.Step.Entry;
                    entity.OfficiallyApprovedDate = DateTime.Now;
                    entity.FunctionalLevelId = jbs.FunctionalLevel.Id;
                    entity.FunctionalLevelTitle = jbs.FunctionalLevel.Title;
                    entity.EmployeeId = Convert.ToInt32(Request.QueryString["EmployeeId"]);

                    DateTime dt;
                    if (DateTime.TryParseExact(StartDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        entity.StartDate = dt;
                    }
                    if (DateTime.TryParseExact(EndDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt) == true)
                    {
                        entity.EndDate = dt;
                        entity.Type = ContractType.Limited;

                        TimeSpan span = entity.EndDate.Value.Subtract(entity.StartDate);
                        double years = span.TotalDays / 365;
                        if (years > 10)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<script language='javascript'>displayNoty('The contract that is not idifinite cannot be for more than 10 years.');</script>");

                            // if the script is not already registered
                            if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                                ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());

                            return;
                        }
                    }
                    else
                    {
                        entity.Type = ContractType.Permanent;
                    }
                    entity.GrossValue = entity.GradeEntry + entity.StepEntry;

                    EmployeeView employeeView = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });
                    entity.EmployeeNo = employeeView.EmployeeNo;
                    entity.EmployeeFirstname = employeeView.Firstname;
                    entity.EmployeeLastname = employeeView.Lastname;
                    entity.EmployeePersonalNumber = employeeView.PersonalNumber;

                    entity.ContractStatus = ContractStatus.Aproved;
                    entity.NextContractNumber = "";
                    entity.Status = StatusEnum.Active;

                    entity.Content.ContentStatus = StatusEnum.Active;

                    new ContractMapper().Insert(entity);

                    foreach(LanguageEntity lang in new LanguageMapper().ListForContractTemplate(Convert.ToInt32(Request.QueryString["ContractTemplateId"])))
                    {
                        ContractContentEntity contentEntity = new ContractContentEntity();
                        contentEntity.Content = ((CKEditor.NET.CKEditorControl)contractVersion.FindControl(lang.Title)).Text;
                        contentEntity.ContractNumber = entity.ContractNumber;
                        contentEntity.LanguageId = lang.Id;
                        new ContractMapper().InsertContent(contentEntity);
                    }

                    jbs.ContractsTemplates.Remove(jbs.ContractsTemplates.Where(s => s.Id == Convert.ToInt32(Request.QueryString["ContractTemplateId"])).First());
                    if (jbs.ContractsTemplates.Count != 0)
                    {
                        Response.Redirect("Contract.aspx?EmployeeId=" + Request.QueryString["EmployeeId"] + "&ContractTemplateId=" + jbs.ContractsTemplates[0].Id);
                    }
                    else
                    {
                        Response.Redirect("Details.aspx?EmployeeId=" + Request.QueryString["EmployeeId"]);
                    }
                }
            }

            Response.Redirect("List.aspx");
        }
    }
}