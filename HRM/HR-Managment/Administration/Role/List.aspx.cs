using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using Entities;
using System.Configuration;

namespace HRM.HR_Managment.Administration.Role
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RoleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRole")
            {
                int roleId = Convert.ToInt32(e.CommandArgument);
                RoleEntity entity = new RoleEntity() { Id = roleId, ApplicationId = Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"])};
                new FormMapper().DeleteFormsFromRole(entity);
                new UserMapper().DeleteUsersFromRole(entity);
                new RoleMapper().Delete(entity);

                RoleGridView.DataBind();
            }
        }
    }
}