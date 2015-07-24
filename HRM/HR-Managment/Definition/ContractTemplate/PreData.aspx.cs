using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.Views;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.Definition.ContractTemplate
{
    public partial class PreData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("ContractTemplatePreData");
            Session.Remove("BackStack");

            Stack<string> stack = new Stack<string>();
            if (!stack.Contains(Request.Url.PathAndQuery))
            {
                stack.Push(Request.Url.PathAndQuery.ToString());
            }
            Session.Add("BackStack", stack);

            if (!IsPostBack)
            {
                if (Request.QueryString["ContractTemplateId"] != null)
                {
                    int ContractTemplateId = Convert.ToInt32(Request.QueryString["ContractTemplateId"]);

                    ContractTemplateEntity entity = new ContractTemplateMapper()
                        .Get(ContractTemplateId);
                    LeaveDaysPerMonthTextBox.Text = entity.LeaveDaysPerMonth.ToString();
                    LeaveDaysPerExperienceTextBox.Text = entity.LeaveDaysPerYearExperience.ToString();
                    LeaveDaysCarriedForwardTextBox.Text = entity.DaysCarriedForwardPerYear.ToString();
                }
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            ContractTemplatePreDataSessionView view = new ContractTemplatePreDataSessionView();

            view.LeaveDaysPerMonth = Convert.ToDouble(LeaveDaysPerMonthTextBox.Text);
            view.LeaveDaysPerYearExperience = Convert.ToDouble(LeaveDaysPerExperienceTextBox.Text);
            view.DaysCarriedForward = Convert.ToDouble(LeaveDaysCarriedForwardTextBox.Text);

            foreach (ListItem field in CheckBoxList2.Items)
            {
                if (field.Selected)
                {
                    view.HolidayGroups.Add(new Entities.HolidayGroupEntity() { Title = field.Text, Id = Convert.ToInt32(field.Value) });
                }
            }

            foreach (ListItem field in ContractsCheckBoxList.Items)
            {
                if (field.Selected)
                {
                    view.Languages.Add(new Entities.LanguageEntity() { Title = field.Text, Id = Convert.ToInt32(field.Value) });
                }
            }

            int languageId = view.Languages[0].Id;
            view.Languages.RemoveAt(0);

            Session.Add("ContractTemplatePreData", view);
            if (Request.QueryString["action"] != null)
            {
                Response.Redirect("Edit.aspx?ContractTemplateId=" + Request.QueryString["ContractTemplateId"] + "&LanguageId=" + languageId);
            }
            else
            {
                Response.Redirect("Add.aspx?LanguageId=" + languageId);
            }
        }

        protected void CheckBoxList2_PreRender(object sender, EventArgs e)
        {
            List<HolidayGroupEntity> list = new HolidayGroupMapper().ListByContractTemplateId(Convert.ToInt32(Request.QueryString["ContractTemplateId"]));
            foreach (HolidayGroupEntity ent in list)
            {
                CheckBoxList2.Items.FindByValue(ent.Id.ToString()).Selected = true;
            }
        }

        protected void ContractsCheckBoxList_PreRender(object sender, EventArgs e)
        {
            List<LanguageEntity> list = new LanguageMapper().ListForContractTemplate(Convert.ToInt32(Request.QueryString["ContractTemplateId"]));
            foreach (LanguageEntity ent in list)
            {
                ContractsCheckBoxList.Items.FindByValue(ent.Id.ToString()).Selected = true;
            }
        }
    }
}