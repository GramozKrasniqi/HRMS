using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using Entities.Views;
using DAL.Mapper;
using Entities;
using System.Configuration;
using DAL.Mapper.Transactions;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace HRM.HR_Managment.Administration.User
{
    public partial class LinkToUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EmployeeId"] != null)
            {
                if (!IsPostBack)
                {
                    EmployeeView view = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });
                    if (view.Id != 0)
                    {
                        EmployeeNameLabel.Text = view.ToString();
                        JobTitleAndUnitLabel.Text = view.Job + " at " + view.OrganizationalUnit;
                        EmployeeNoLabel.InnerText = view.EmployeeNo;
                        PersonalNoLabel.InnerText = view.PersonalNumber;
                        DateOfBirthLabel.InnerText = view.DateOfBirth.ToShortDateString();
                        GenderLabel.InnerText = view.Gender.ToString();
                        CountryLabel.InnerText = view.Country;
                        NationalityNoLabel.InnerText = view.Nationality;
                        CityLabel.InnerText = view.City;
                        tMobilePhoneLabel.InnerText = view.MobilePhone;
                        WorkEmailLabel.InnerText = view.WorkEmail;
                    }
                    else
                    {
                        Response.Redirect("List.aspx");
                    }
                }
                else
                {
                    if (userTextBox.Text != "")
                    {
                        //PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                        //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userTextBox.Text);
                        //if (user != null)
                        //{
                        //    if (user.UserPrincipalName != null)
                        //    {
                        //        EmailAddressTextBox.Text = user.UserPrincipalName;
                        //    }
                        //}
                        //else
                        //{
                        //    EmailAddressTextBox.Text = "";
                        //}


                        // Get the number of items in the Contacts folder. To keep the response smaller, request only the TotalCount property. 
                        ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010);
                        service.Url = new Uri(@"https://mail.kpaonline.org/EWS/Exchange.asmx");
                        service.Credentials = new NetworkCredential("gramoz.krasniqi@kpaonline.org", "Passsygtech456");

                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                        NameResolutionCollection nameResolutions = service.ResolveName(
                         userTextBox.Text,
                         ResolveNameSearchLocation.DirectoryOnly,
                         true);

                        foreach (NameResolution nameResolution in nameResolutions)
                        {
                            EmailAddressTextBox.Text = nameResolution.Mailbox.Address;
                        }
                    }
                }
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userTextBox.Text);
            if (user != null)
            {
                int appId = Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]);
                int empId = Convert.ToInt32(Request.QueryString["EmployeeId"]);

                UserEntity userEntity = new UserEntity();
                userEntity.ApplicationId = appId;
                userEntity.EmployeeId = empId;
                userEntity.Username = userTextBox.Text;
                userEntity.Status = StatusEnum.Active;
                userEntity.Password = "";

                new LinkEmployeeToUserBO().Link(userEntity, Convert.ToInt32(RoleDropDownList.SelectedValue), user.UserPrincipalName);
                #warning set this to a good mail message
                string[] to = { EmailAddressTextBox.Text };
                SendMail.Send(to, "Hi", ("HR Test from system. You have been granted acess to the HR system." + userEntity.EmployeeId));

                Response.Redirect("List.aspx");
            }
        }
    }
}