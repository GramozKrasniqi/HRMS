using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using Entities;
using Entities.Views;

namespace HRM.HR_Managment.Definition.ContractTemplate
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stack<string> stack = (Stack<string>)Session["BackStack"];
            if (!stack.Contains(Request.Url.PathAndQuery))
            {
                stack.Push(Request.Url.PathAndQuery.ToString());
            }

            Session["BackStack"] = stack;

            if (Session["ContractTemplatePreData"] == null || Request.QueryString["LanguageId"] == null || Request.QueryString["ContractTemplateId"] == null || Session["BackStack"] == null)
            {
                Session.Remove("ContractTemplatePreData");
                Response.Redirect("List.aspx");
            }

            if (!IsPostBack)
            {
                CKEditor1.config.toolbar = new object[]
                    {
                        new object[] { "NewPage", "Preview"},
                        new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker"},
                        new object[] { "Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll"},
                        "/",
                        new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
                        new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent", "Blockquote"},
                        new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
                        new object[] { "BidiLtr", "BidiRtl" },
                        new object[] { "Image", "Table", "HorizontalRule", "SpecialChar", "PageBreak"},
                        "/",
                        new object[] { "Styles", "Format", "Font", "FontSize" },
                        new object[] { "TextColor", "BGColor" },
                        new object[] { "Maximize", "ShowBlocks"}
                    };

                LanguageEntity lang = new LanguageMapper().Get(Convert.ToInt32(Request.QueryString["LanguageId"]));
                LanguageLabel.Text = lang.Title;

                ContractTemplateEntity entity = new ContractTemplateMapper()
                    .GetContentById(Convert.ToInt32(Request.QueryString["ContractTemplateId"]), Convert.ToInt32(Request.QueryString["LanguageId"]));
                if (entity.Id == 0)
                {
                    entity = new ContractTemplateMapper().Get(Convert.ToInt32(Request.QueryString["ContractTemplateId"]));
                }

                ContractTemplateTitleBox.Text = entity.Title;
                ContractPreffixTextBox.Text = entity.Preffix;
                CKEditor1.Text = entity.Content;
            }

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            if (CKEditor1.Text != "")
            {
                ContractTemplatePreDataSessionView view = (ContractTemplatePreDataSessionView)Session["ContractTemplatePreData"];

                ContractTemplateEntity entity = new ContractTemplateEntity();
                entity.Content = CKEditor1.Text;
                entity.Title = ContractTemplateTitleBox.Text;
                entity.Preffix = ContractPreffixTextBox.Text;
                entity.Status = StatusEnum.Active;
                entity.Id = Convert.ToInt32(Request.QueryString["ContractTemplateId"]);
                entity.LeaveDaysPerMonth = view.LeaveDaysPerMonth;
                entity.LeaveDaysPerYearExperience = view.LeaveDaysPerYearExperience;
                entity.DaysCarriedForwardPerYear = view.DaysCarriedForward;
                entity.LanguageId = Convert.ToInt32(Request.QueryString["LanguageId"]);

                new HolidayGroupMapper().DeleteForContractTemplate(entity.Id);
                foreach (HolidayGroupEntity en in view.HolidayGroups)
                {
                    new HolidayGroupMapper().InsertForContractTemplate(en, entity.Id);
                }

                ContractTemplateMapper mapper = new ContractTemplateMapper();
                mapper.Update(entity);

                if (view.Languages.Count > 0)
                {
                    int languageId = view.Languages[0].Id;
                    view.Languages.RemoveAt(0);
                    Response.Redirect("Edit.aspx?ContractTemplateId=" + Request.QueryString["ContractTemplateId"] + "&LanguageId=" + languageId);
                }
                else
                {
                    Session.Remove("ContractTemplatePreData");
                    Response.Redirect("PayScale.aspx?ContractTemplateId=" + entity.Id.ToString());
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            #warning bug add language to view session beacuse you just deleted it when you hit the proceed button
            Stack<string> stack = (Stack<string>)Session["BackStack"];
            stack.Pop();

            Response.Redirect(stack.Peek());
        }
    }
}