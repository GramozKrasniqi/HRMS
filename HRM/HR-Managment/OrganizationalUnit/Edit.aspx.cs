using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.Views;
using DAL.Mapper;
using Entities;

namespace HRM.HR_Managment.OrganizationalUnit
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["orgUnitId"] != null)
            {
                if (!IsPostBack)
                {
                    OrganizationalUnitView view = new OrganizationalUnitMapper().Get(new Entities.OrganizationalUnitEntity() { Id = Convert.ToInt32(Request.QueryString["orgUnitId"]) });

                    if (view!= null)
                    {
                        TitleTextBox.Text = view.Title;
                        OtherInfoTextBox.Text = view.Description;

                        OrganizationalUnitView orgView = new OrganizationalUnitMapper().GetParent(new Entities.OrganizationalUnitEntity() { Id = Convert.ToInt32(Request.QueryString["orgUnitId"])});
                        ParentCascadingDropDown.ContextKey = orgView.TitleAndOrganizationaUnitGroup;

                        OrganizationalUnitGroupCascadingDropDown.ContextKey = view.OrganizationaUnitGroup;
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
            OrganizationalUnitEntity entity = new OrganizationalUnitEntity();
            entity.Id = Convert.ToInt32(Request.QueryString["orgUnitId"]);
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;

            entity.OrganizationaUnitGroupId = Convert.ToInt32(OrganizationalUnitGroupDropDownList.SelectedValue);

            if (ParentDropDownList.SelectedValue != "")
            {
                new OrganizationalUnitMapper().Update(entity, Convert.ToInt32(ParentDropDownList.SelectedValue));
            }
            else
            {
                new OrganizationalUnitMapper().Update(entity, null);

            }
            Response.Redirect("List.aspx");
        }
    }
}