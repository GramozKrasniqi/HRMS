using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using System.Text;

namespace HRM.HR_Managment.Definition.AmandmentTemplate
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["AmandamentTemplateId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new AmandamentMapper().Delete(Convert.ToInt32(Request.QueryString["AmandamentTemplateId"]));
                }
                catch (Exception)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Amandment template is being used by other entities and it cannot be deleted. Maybe you should change the status of the Amandment template to Pasive.');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }

            if (!IsPostBack)
            {
                GUIHelper.BindEnum2DropDownList(AmandamentStatusDropDownList, typeof(StatusEnum), true);
            }
        }
    }
}