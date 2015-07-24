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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            NationalityEntity entity = new NationalityEntity();
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;

            new NationalityMapper().Insert(entity);
            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}