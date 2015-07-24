using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.Definition.Bank
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BankId"] != null)
            {
                if (!IsPostBack)
                {
                    BankEntity entity = new BankMapper().Get(new BankEntity() { Id = Convert.ToInt32(Request.QueryString["BankId"]) });
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
            BankEntity entity = new BankEntity();
            entity.Id = Convert.ToInt32(Request.QueryString["BankId"]);
            entity.Title = TitleTextBox.Text;
            entity.Description = OtherInfoTextBox.Text;
            entity.Status = StatusEnum.Active;

            new BankMapper().Update(entity);

            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}