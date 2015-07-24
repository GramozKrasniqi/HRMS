using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;
using DAL.Mapper;
using Entities;
using System.Configuration;

namespace HRM.HR_Managment.Administration.Role
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RoleId"] != null)
                {
                    RoleNameTextBox.Text = Request.QueryString["RoleTitle"].ToString();
                    roleId.Value = Request.QueryString["RoleId"];
                }
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            string strings = jsfields.Value;

            List<string> list = strings.Split(',').ToList();

            RoleEntity entity = new RoleEntity()
            {
                ApplicationId = Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]),
                Id = Convert.ToInt32(Request.QueryString["RoleId"]),
            };

            new RoleMapper().Get(entity);

            entity.Title = RoleNameTextBox.Text;
            entity.Description = "";
            new RoleMapper().Update(entity);

            new FormMapper().DeleteFormsFromRole(entity);

            foreach (string s in list)
            {
                string id = "";

                if (s.StartsWith("0"))
                {
                    id = s.Substring(1, s.Length - 1);
                }
                else
                {
                    id = s;
                }

                if (id != "")
                {
                    int i = Convert.ToInt32(id);

                    new FormMapper().InsertFormForRole(new FormEntity() { Id = i }, new RoleEntity() { Id = entity.Id }, Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]));
                }
            }

            Response.Redirect("List.aspx");
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<G_JSTree> GetAllNodes(string id, string isOrganizationUnit, string roleId)
        {
            int role = Convert.ToInt32(roleId);

            List<G_JSTree> list = new List<G_JSTree>();
            //if (isOrganizationUnit == "False")
            //    return list;

            if (id == "0")
            {
                List<FormEntity> formEntities = new FormMapper().ListWithAdvanced("", null, StatusEnum.Active, true, Convert.ToInt32(roleId), 1);
                foreach (FormEntity formentity in formEntities)
                {
                    G_JSTree parent = new G_JSTree();
                    parent.data = formentity.Title;
                    parent.state = "closed";
                    parent.IdServerUse = 10;
                    if (formentity.IsChecked == true)
                    {
                        parent.attr = new G_JsTreeAttribute { id = "0" + formentity.Id.ToString(), selected = true, isOrganizationUnit = true };
                    }
                    else
                    {
                        parent.attr = new G_JsTreeAttribute { id = "0" + formentity.Id.ToString(), selected = false, isOrganizationUnit = true };
                    }

                    list.Add(parent);
                }
            }
            else
            {
                List<FormEntity> childForms = new FormMapper().ListWithAdvanced("", Convert.ToInt32(id), StatusEnum.Active, null, Convert.ToInt32(roleId), 1);
                foreach (FormEntity childForm in childForms)
                {
                    G_JSTree child = new G_JSTree();
                    child.data = childForm.Title;
                    child.state = "closed";
                    child.IdServerUse = 10;
                    child.children = null;
                    if (childForm.IsChecked == true)
                    {
                        child.attr = new G_JsTreeAttribute { id = childForm.Id.ToString(), selected = true, isOrganizationUnit = false };
                    }
                    else
                    {
                        child.attr = new G_JsTreeAttribute { id = childForm.Id.ToString(), selected = false, isOrganizationUnit = false };
                    }
                    list.Add(child);
                }
            }

            return list;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<G_JSTree> SaveNodes(string id, string isOrganizationUnit)
        {

            List<G_JSTree> list = new List<G_JSTree>();
            if (isOrganizationUnit == "False")
                return list;

            if (id == "0")
            {
                List<FormEntity> formEntities = new FormMapper().ListWithAdvanced("", null, StatusEnum.Active, true, null, 1);
                foreach (FormEntity formEntity in formEntities)
                {
                    G_JSTree parent = new G_JSTree();
                    parent.data = formEntity.Title;
                    parent.state = "closed";
                    parent.IdServerUse = 10;
                    parent.attr = new G_JsTreeAttribute { id = formEntity.Id.ToString(), selected = false, isOrganizationUnit = true };

                    list.Add(parent);
                }
            }
            else
            {
                List<FormEntity> formEntities = new FormMapper().ListWithAdvanced("", Convert.ToInt32(id), StatusEnum.Active, false, null, 1);

                foreach (FormEntity formEntity in formEntities)
                {
                    G_JSTree child = new G_JSTree();
                    child.data = formEntity.Title;
                    child.state = "closed";
                    child.IdServerUse = 10;
                    child.children = null;
                    child.attr = new G_JsTreeAttribute { id = formEntity.Id.ToString(), selected = false, isOrganizationUnit = false };
                    list.Add(child);
                }
            }

            return list;
        }
    }
}