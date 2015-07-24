using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.OrganizationalUnit
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            OrganizationalUnitEntity entity = new OrganizationalUnitEntity();
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;
            entity.OrganizationaUnitGroupId = Convert.ToInt32(OrganizationalUnitGroupDropDownList.SelectedValue);

            if (ParentDropDownList.SelectedValue != "")
            {
                new OrganizationalUnitMapper().InsertWithParent(entity, Convert.ToInt32(ParentDropDownList.SelectedValue));
            }
            else
            {
                new OrganizationalUnitMapper().InsertWithParent(entity, null);
            }
            Response.Redirect("List.aspx");
        }
    }
}