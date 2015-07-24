using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.DirectoryServices.AccountManagement;
using DAL.Mapper;
using Entities;
using System.Web.UI;
using System.Web.Caching;
using System.Configuration;
using System.Security.Principal;

namespace HRM
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            foreach (LanguageEntity language in new LanguageMapper().List(""))
            {
                TranslatorHelper.AppStrings.Add(language.Id, new ApplicationStringMapper().ListApplicationStringsByLanguageId(Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]), Convert.ToInt32(Session["defaultLanguage"])));
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {
            string[] to = { "gramoz.krasniqi@kpaonline.org" };
            SendMail.Send(to, "Error", Server.GetLastError().ToString() + "\n" + Request.FilePath);

        }


        void Session_Start(object sender, EventArgs e)
        {
            string logUser;
            IIdentity WinId = HttpContext.Current.User.Identity;
            WindowsIdentity wi = (WindowsIdentity)WinId;
            logUser = wi.Name.ToString().Substring(wi.Name.ToString().LastIndexOf("\\") + 1);

            Session.Add("logUser", logUser);
            Session.Add("defaultLanguage", 2);
            Session.Add("ApplicationId", 2);
        }


        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
    }
}
