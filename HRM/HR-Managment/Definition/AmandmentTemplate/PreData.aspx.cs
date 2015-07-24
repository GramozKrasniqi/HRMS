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
    public partial class PreData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("AmandamentTemplatePreData");
            Session.Remove("BackStack");

            Stack<string> stack = new Stack<string>();
            if (!stack.Contains(Request.Url.PathAndQuery))
            {
                stack.Push(Request.Url.PathAndQuery.ToString());
            }
            Session.Add("BackStack", stack);
        }

        protected void ContractsCheckBoxList_PreRender(object sender, EventArgs e)
        {
            List<LanguageEntity> list = new LanguageMapper().ListForAmandmentTemplate(Convert.ToInt32(Request.QueryString["AmandamentTemplateId"]));
            foreach (LanguageEntity ent in list)
            {
                ContractsCheckBoxList.Items.FindByValue(ent.Id.ToString()).Selected = true;
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            AmandmentTemplatePreDataSessionView view = new AmandmentTemplatePreDataSessionView();

            foreach (ListItem field in ContractsCheckBoxList.Items)
            {
                if (field.Selected)
                {
                    view.Languages.Add(new Entities.LanguageEntity() { Title = field.Text, Id = Convert.ToInt32(field.Value) });
                }
            }

            int languageId = view.Languages[0].Id;
            view.Languages.RemoveAt(0);

            Session.Add("AmandamentTemplatePreData", view);
            if (Request.QueryString["action"] != null)
            {
                Response.Redirect("Edit.aspx?AmandamentTemplateId=" + Request.QueryString["AmandamentTemplateId"] + "&LanguageId=" + languageId);
            }
            else
            {
                Response.Redirect("Add.aspx?LanguageId=" + languageId);
            }
        }
    }
}