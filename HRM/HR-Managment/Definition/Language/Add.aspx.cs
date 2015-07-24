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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            LanguageEntity entity = new LanguageEntity();
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;
            entity.ApplicationId = Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]);

            new LanguageMapper().Insert(entity);
            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}