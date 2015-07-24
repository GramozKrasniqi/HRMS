using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace HRM.HR_Managment.Leaves.LeaveRequest
{
    public partial class List : System.Web.UI.Page
    {
        
        // Please check the leaves that i approved for the parameter EmployeeId which must be the id of the current user logged
        #warning Warning of design concerns
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExperienceObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["status"] = Convert.ToInt32(RequestsEnum.Processed).ToString();
        }
    }
}