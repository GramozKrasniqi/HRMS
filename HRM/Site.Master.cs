using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using Entities;
using System.Web.UI.HtmlControls;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace HRM
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string logUser;
            IIdentity WinId = HttpContext.Current.User.Identity;
            WindowsIdentity wi  = (WindowsIdentity)WinId;
            logUser = wi.Name.ToString().Substring(wi.Name.ToString().LastIndexOf("\\") + 1);
            RoleEntity role = Authorization.isAuthorized(logUser, Request.RawUrl);

            if (role == null)
            {
                Response.Redirect("~/Authorization.aspx");
            }

            HtmlGenericControl li;
            HtmlGenericControl a;
            HtmlGenericControl ul = new HtmlGenericControl("ul");

            List<FormEntity> list = new FormMapper().ListWithAdvanced("", null, StatusEnum.Active, true, role.Id, null);

            foreach (FormEntity entity in list)
            {
                li = new HtmlGenericControl("li");
                a = new HtmlGenericControl("a");

                a.Attributes.Add("href", entity.Path);
                a.InnerText = entity.Title;
                li.Controls.Add(a);

                List<FormEntity> childs = new FormMapper().ListWithAdvanced("", entity.Id, StatusEnum.Active, true, role.Id, null);

                ul = new HtmlGenericControl("ul");
                foreach (FormEntity child in childs)
                {
                    HtmlGenericControl liChild = new HtmlGenericControl("li");
                    HtmlGenericControl aChild = new HtmlGenericControl("a");

                    aChild.Attributes.Add("href", child.Path);
                    aChild.InnerText = child.Title;
                    liChild.Controls.Add(aChild);

                    ul.Controls.Add(liChild);
                }
                if (childs.Count != 0)
                {
                    li.Controls.Add(ul);
                }

                menu.Controls.Add(li);
            }
        }
    }
}