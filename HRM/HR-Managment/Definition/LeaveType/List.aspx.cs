using DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Definition.LeaveType
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //http://localhost:14994/HRM/HR-Managment/Definition/LeaveType/List.aspx?LeaveTypeId=3&action=delete
            if (Request.QueryString["LeaveTypeId"] != null && Request.QueryString["action"] == "delete")
            {
                new LeaveTypeMapper().Delete(new Entities.LeaveTypeEntity() { Id = Convert.ToInt32(Request.QueryString["LeaveTypeId"]) });
            }

        }
    }
}