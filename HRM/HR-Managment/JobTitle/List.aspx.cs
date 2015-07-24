using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.JobTitle
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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