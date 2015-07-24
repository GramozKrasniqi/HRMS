using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using System.Web.UI.HtmlControls;
using System.Text;

namespace HRM.HR_Managment.Definition.ContractTemplate
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ContractTemplateId"] != null)
            {
                int contractTemplateId = Convert.ToInt32(Request.QueryString["ContractTemplateId"]);

                ContractTemplateEntity contract = new ContractTemplateMapper().Get(contractTemplateId);
                ContractTemplateTitleLabel.InnerText = contract.Title;
                ContractPreffixLabel.InnerText = contract.Preffix;
                LeaveDaysPerMonthLabel.InnerText = contract.LeaveDaysPerMonth.ToString();
                ExpLeaveDaysPerYearLabel.InnerText = contract.LeaveDaysPerYearExperience.ToString();
                DaysCarriedForwardLabel.InnerText = contract.DaysCarriedForwardPerYear.ToString();

                List<LanguageEntity> langs = new LanguageMapper().ListForContractTemplate(contractTemplateId);
                foreach (LanguageEntity ent in langs)
                {
                    ContractTemplateEntity cte = new ContractTemplateMapper().GetContentById(contractTemplateId, ent.Id);
                    GenerateContractVersions(ent.Title, cte);
                }

                GenerateButton("List.aspx");
            }
            else
            {                
                Response.Redirect("List.aspx");
            }
        }

        private void GenerateButton(string PostBackUrl)
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("width", "auto");
            ul.Attributes.Add("margin-top", "12px");
            ul.Attributes.Add("class", "clearfix");

            HtmlGenericControl li = new HtmlGenericControl("li");

            Button b = new Button();
            b.ID = "BaclToListButton";
            b.CssClass = "right login_btn";
            b.Text = "Back";
            b.CausesValidation = false;
            b.PostBackUrl = PostBackUrl;

            li.Controls.Add(b);
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

            Label text= new Label();
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
            container.Attributes.Add("id", (LanguageTitle+"Div"));
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
            if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), ("HeyPopup"+LanguageTitle)))
                ClientScript.RegisterStartupScript(Page.GetType(), ("HeyPopup" + LanguageTitle), sb.ToString());
        }
    }
}