using DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Definition.Language
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LanguageId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new LanguageMapper().Delete(new Entities.LanguageEntity() { Id = Convert.ToInt32(Request.QueryString["LanguageId"]) });
                }
                catch (Exception)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Language is being used by Employees and it cannot be deleted. Change Employees Language to delete or change the status of the Language to Pasive');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }
        }
    }
}