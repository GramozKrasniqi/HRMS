using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using Entities;

namespace HRM.HR_Managment.BatchOperations
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["employeeId"] != null && Request.QueryString["type"] != null)
            {
                string content = "";
                string strings = Convert.ToString(Request.QueryString["employeeId"]);
                List<string> list = strings.Split(',').ToList();

                if (Request.QueryString["type"] == "newContract")
                {
                    foreach (string s in list)
                    {
                        if (!s.StartsWith("0"))
                        {
                            ContractEntity ent = new ContractMapper().GetLastContract(new ContractEntity() { EmployeeId = Convert.ToInt32(s) });
                            foreach (ContractContentEntity cce in new ContractMapper().ListLastContractsContents(ent))
                            {
                                content += cce.Content;
                                content += "<p style='page-break-before: always'>";
                            }
                        }
                    }

                    Response.Write(content);
                }
                else if (Request.QueryString["type"] == "newAmandament")
                {
                    foreach (string s in list)
                    {
                        if (!s.StartsWith("0"))
                        {
                            content += new AmandamentMapper()
                                .GetLastAmandament
                                (
                                    new AmandamentEntity()
                                        {
                                            ContractNumber = new ContractMapper()
                                              .GetLastContract(new ContractEntity() { EmployeeId = Convert.ToInt32(s) }).ContractNumber
                                        }
                                ).Content.Content;

                            content += "<p style='page-break-before: always'>";
                        }
                    }
                    content = content.Replace("/ckfinder/userfiles/images/", "/HRM/ckfinder/userfiles/images/");

                    Response.Write(content);
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }
    }
}