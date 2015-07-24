using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using System.Text;

namespace HRM.HR_Managment.Definition.ContractTemplate
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ContractTemplateId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new ContractTemplateMapper().Delete(Convert.ToInt32(Request.QueryString["ContractTemplateId"]));
                }
                catch (Exception)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Contract template is being used by other entities and it cannot be deleted. Maybe you should change the status of the Contract template to Pasive.');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }

            if (!IsPostBack)
            {
                GUIHelper.BindEnum2DropDownList(ContractStatusDropDownList, typeof(StatusEnum), true);
            }
        }

        protected void ContractTemplateGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = ContractTemplateGridView.BottomPagerRow;
            if (pagerRow != null)
            {
                Label pageNum = (Label)pagerRow.Cells[0].FindControl("PageNumberLabel");
                Label totalNum = (Label)pagerRow.Cells[0].FindControl("TotalPagesLabel");
                if ((pageNum != null) && (totalNum != null))
                {
                    int page = ContractTemplateGridView.PageIndex + 1;
                    int count = ContractTemplateGridView.PageCount;
                    pageNum.Text = page.ToString();
                    totalNum.Text = count.ToString();
                }
            }
        }
    }
}