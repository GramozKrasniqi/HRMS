using DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Definition.Holiday
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["HolidayId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new HolidayGroupMapper().Delete(new Entities.HolidayGroupEntity() { Id = Convert.ToInt32(Request.QueryString["HolidayGroupId"]) });
                }
                catch (Exception)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Holiday Group is being used by Holidays and it cannot be deleted. Change Holidays group to delete or change the status of the Holiday Group to Pasive');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }
        }

        protected void HolidayGroupGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = HolidayGroupGridView.BottomPagerRow;
            if (pagerRow != null)
            {
                Label pageNum = (Label)pagerRow.Cells[0].FindControl("PageNumberLabel");
                Label totalNum = (Label)pagerRow.Cells[0].FindControl("TotalPagesLabel");
                if ((pageNum != null) && (totalNum != null))
                {
                    int page = HolidayGroupGridView.PageIndex + 1;
                    int count = HolidayGroupGridView.PageCount;
                    pageNum.Text = page.ToString();
                    totalNum.Text = count.ToString();
                }
            }
        }
    }
}