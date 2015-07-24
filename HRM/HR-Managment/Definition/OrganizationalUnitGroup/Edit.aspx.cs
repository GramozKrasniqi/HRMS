using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.Definition.OrganizationalUnitGroup
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UnitGroupId"] != null)
            {
                if (!IsPostBack)
                {
                    OrganizationalUnitGroupEntity entity = new OrganizationalUnitGroupMapper().Get(new OrganizationalUnitGroupEntity() { Id = Convert.ToInt32(Request.QueryString["UnitGroupId"]) });
                    if (entity != null)
                    {
                        TitleTextBox.Text = entity.Title;
                        OtherInfoTextBox.Text = entity.Description;
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
            OrganizationalUnitGroupEntity entity = new OrganizationalUnitGroupEntity();
            entity.Id = Convert.ToInt32(Request.QueryString["UnitGroupId"]);
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;

            new OrganizationalUnitGroupMapper().Update(entity);

            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}