using DAL.Mapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Definition.Language
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LanguageId"] != null)
            {
                if (!IsPostBack)
                {
                    LanguageEntity entity = new LanguageMapper().Get(Convert.ToInt32(Request.QueryString["LanguageId"]));
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
            LanguageEntity entity = new LanguageEntity();
            entity.Id = Convert.ToInt32(Request.QueryString["LanguageId"]);
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;
            entity.Status = StatusEnum.Active;
            entity.ApplicationId = Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]);

            new LanguageMapper().Update(entity);

            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}