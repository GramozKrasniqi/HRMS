using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.Definition.Nationalities
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["NationalityId"] != null)
            {
                if (!IsPostBack)
                {
                    NationalityEntity entity = new NationalityMapper().Get(new NationalityEntity() { Id = Convert.ToInt32(Request.QueryString["NationalityId"]) });
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
            NationalityEntity entity = new NationalityEntity();
            entity.Id = Convert.ToInt32(Request.QueryString["NationalityId"]);
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;
            entity.Status = StatusEnum.Active;

            new NationalityMapper().Update(entity);

            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}