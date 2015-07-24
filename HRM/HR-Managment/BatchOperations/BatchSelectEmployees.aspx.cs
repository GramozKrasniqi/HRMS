using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using DAL.Mapper;
using Entities.Views;
using Entities;

namespace HRM.HR_Managment.BatchOperations
{
    public partial class BatchSelectEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<G_JSTree> GetAllNodes(string id, string isOrganizationUnit)
        {
            
            List<G_JSTree> list = new List<G_JSTree>();
            if (isOrganizationUnit == "False")
                return list;

            if (id == "0")
            {
                List<OrganizationalUnitView> organizationalUnits = new OrganizationalUnitMapper().List("");
                foreach (OrganizationalUnitView organizationalUnit in organizationalUnits)
                {
                    G_JSTree parent = new G_JSTree();
                    parent.data = organizationalUnit.Title;
                    parent.state = "closed";
                    parent.IdServerUse = 10;
                    parent.attr = new G_JsTreeAttribute { id = "0" + organizationalUnit.Id.ToString(), selected = false, isOrganizationUnit = true };

                    list.Add(parent);
                }
            }
            else
            {
                List<EmployeeView> employees = new EmployeeMapper().ListWithAdvancedFilter("", "", "", Convert.ToInt32(id), "", StatusEnum.Active);

                foreach (EmployeeView employee in employees)
                {
                    G_JSTree child = new G_JSTree();
                    child.data = employee.ToString();
                    child.state = "closed";
                    child.IdServerUse = 10;
                    child.children = null;
                    child.attr = new G_JsTreeAttribute { id = employee.Id.ToString(), selected = false, isOrganizationUnit = false };
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
                List<OrganizationalUnitView> organizationalUnits = new OrganizationalUnitMapper().List("");
                foreach (OrganizationalUnitView organizationalUnit in organizationalUnits)
                {
                    G_JSTree parent = new G_JSTree();
                    parent.data = organizationalUnit.Title;
                    parent.state = "closed";
                    parent.IdServerUse = 10;
                    parent.attr = new G_JsTreeAttribute { id = organizationalUnit.Id.ToString(), selected = false, isOrganizationUnit = true };

                    list.Add(parent);
                }
            }
            else
            {
                List<EmployeeView> employees = new EmployeeMapper().ListWithAdvancedFilter("", "", "", Convert.ToInt32(id), "", StatusEnum.Active);

                foreach (EmployeeView employee in employees)
                {
                    G_JSTree child = new G_JSTree();
                    child.data = employee.ToString();
                    child.state = "closed";
                    child.IdServerUse = 10;
                    child.children = null;
                    child.attr = new G_JsTreeAttribute { id = employee.Id.ToString(), selected = false, isOrganizationUnit = false };
                    list.Add(child);
                }
            }

            return list;
        }
    }
}