using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using System.Text;

namespace HRM.HR_Managment.Definition.Country
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CountryId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new CountryMapper().Delete(new Entities.CountryEntity() { Id = Convert.ToInt32(Request.QueryString["CountryId"]) });
                }
                catch (Exception)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Country is being used by Employees and it cannot be deleted. Change Employees Country to delete or change the status of the Country to Pasive');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }
        }

        protected void LeaveTypeGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = LeaveTypeGridView.BottomPagerRow;
            if (pagerRow != null)
            {
                Label pageNum = (Label)pagerRow.Cells[0].FindControl("PageNumberLabel");
                Label totalNum = (Label)pagerRow.Cells[0].FindControl("TotalPagesLabel");
                if ((pageNum != null) && (totalNum != null))
                {
                    int page = LeaveTypeGridView.PageIndex + 1;
                    int count = LeaveTypeGridView.PageCount;
                    pageNum.Text = page.ToString();
                    totalNum.Text = count.ToString();
                }
            }
        }
    }
}