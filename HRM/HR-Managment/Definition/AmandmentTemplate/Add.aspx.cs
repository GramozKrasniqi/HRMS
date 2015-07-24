using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using Entities.Views;

namespace HRM.HR_Managment.Definition.AmandmentTemplate
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stack<string> stack = (Stack<string>)Session["BackStack"];
            if (!stack.Contains(Request.Url.PathAndQuery))
            {
                stack.Push(Request.Url.PathAndQuery.ToString());
            }

            Session["BackStack"] = stack;

            if (Session["AmandamentTemplatePreData"] == null || Request.QueryString["LanguageId"] == null)
            {
                Session.Remove("AmandamentTemplatePreData");
                Response.Redirect("List.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["AmandamentTemplateId"] != null)
                {
                    AmandamentTemplateEntity ent = new AmandamentTemplateMapper().Get(Convert.ToInt32(Request.QueryString["AmandamentTemplateId"]));
                    AmandamentTemplateTitleBox.Text = ent.Title;
                }
            }

            LanguageEntity lang = new LanguageMapper().Get(Convert.ToInt32(Request.QueryString["LanguageId"]));
            LanguageLabel.Text = lang.Title;

            string s = CKEditor1.Text;

            if (!IsPostBack)
            {
                CKEditor1.config.toolbar = new object[]
                {
                    new object[] { "Save", "NewPage", "Preview"},
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
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            if (CKEditor1.Text != "")
            {
                AmandmentTemplatePreDataSessionView view = (AmandmentTemplatePreDataSessionView)Session["AmandamentTemplatePreData"];

                AmandamentTemplateEntity entity = new AmandamentTemplateEntity();
                entity.Content = CKEditor1.Text;
                entity.Title = AmandamentTemplateTitleBox.Text;
                entity.LanguageId = Convert.ToInt32(Request.QueryString["LanguageId"]);
                entity.Status = StatusEnum.Active;

                AmandamentTemplateMapper mapper = new AmandamentTemplateMapper();
                mapper.Insert(entity);

                if (view.Languages.Count > 0)
                {
                    int languageId = view.Languages[0].Id;
                    view.Languages.RemoveAt(0);
                    Response.Redirect("Edit.aspx?LanguageId=" + languageId + "&AmandamentTemplateId=" + entity.AmandamentTemplateId.ToString());
                }
                else
                {
                    Session.Remove("AmandamentTemplatePreData");
                    Response.Redirect("List.aspx");
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