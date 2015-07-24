using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.JobTitle
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            JobTitleEntity jbe = new JobTitleEntity();
            jbe.JobCode = JobCodeTextBox.Text;
            jbe.Title = JobTitleTextBox.Text;
            jbe.Description = OtherInfoTextBox.Text;
            jbe.OrganizationalUnitId = Convert.ToInt32(OrganizationalUnitDropDownList.SelectedValue);
            if (ReportsToDropDownList.SelectedValue != "")
            {
                new JobTitleMapper().InsertWithParent(jbe, ReportsToDropDownList.SelectedValue);
            }
            else
            {
                new JobTitleMapper().InsertWithParent(jbe, null);
            }

            Response.Redirect("DefineGrade.aspx?jobCode="+ jbe.JobCode);
        }
    }
}