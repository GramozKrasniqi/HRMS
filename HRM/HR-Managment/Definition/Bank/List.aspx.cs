using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using System.Text;

namespace HRM.HR_Managment.Definition.Bank
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BankId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new BankMapper().Delete(new Entities.BankEntity() { Id = Convert.ToInt32(Request.QueryString["BankId"]) });
                }
                catch (Exception)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Bank is being used by Employees and it cannot be deleted. Change Employees Bank to delete or change the status of Bank to Pasive');</script>");

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