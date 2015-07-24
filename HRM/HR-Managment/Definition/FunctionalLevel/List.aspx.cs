using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using System.Text;

namespace HRM.HR_Managment.Definition.FunctionalLevel
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["FunctionalLevelId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                new FunctionalLevelMapper().Delete(new Entities.FunctionalLevelEntity() { Id = Convert.ToInt32(Request.QueryString["FunctionalLevelId"]) });
                }
                catch (Exception)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Functional Level is being used by other entities and it cannot be deleted. Maybe you should change the status of the Functional Level to Pasive.');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }
        }
    }
}