using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DAL.Mapper;

namespace HRM.HR_Managment.OrganizationalUnit
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrganizationalUnitId"] != null && Request.QueryString["action"] == "delete")
            {
                try
                {
                    new OrganizationalUnitMapper().Delete(new Entities.OrganizationalUnitEntity() { Id = Convert.ToInt32(Request.QueryString["OrganizationalUnitId"]) });
                }
                catch (Exception)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script language='javascript'>displayNoty('This Organizational Unit is being used by other entities and it cannot be deleted. Maybe you should change the status of the Organizational Unit to Pasive.');</script>");

                    // if the script is not already registered
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
                }
            }
        }

        protected void EducationTrainingGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = EducationTrainingGridView.BottomPagerRow;
            if (pagerRow != null)
            {
                Label pageNum = (Label)pagerRow.Cells[0].FindControl("PageNumberLabel");
                Label totalNum = (Label)pagerRow.Cells[0].FindControl("TotalPagesLabel");
                if ((pageNum != null) && (totalNum != null))
                {
                    int page = EducationTrainingGridView.PageIndex + 1;
                    int count = EducationTrainingGridView.PageCount;
                    pageNum.Text = page.ToString();
                    totalNum.Text = count.ToString();
                }
            }
        }
    }
}