using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace HRM.HR_Managment.Employee
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GUIHelper.BindEnum2DropDownList(EmployeeStatusDropDownList, typeof(StatusEnum), true);
            }
        }
    }
}