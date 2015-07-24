using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace HRM.HR_Managment.Definition
{
    public partial class ComapnyPolicies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CoefficientValueTextBox.Text = ConfigurationManager.AppSettings["CoefficientValue"].ToString();
            LeaveDaysPerMonthTextBox.Text = ConfigurationManager.AppSettings["LeaveDaysPerMonth"].ToString();
            YearsOfExperienceTextBox.Text = ConfigurationManager.AppSettings["ExperienceYears"].ToString();
            LeaveDaysPerExperienceTextBox.Text = ConfigurationManager.AppSettings["LeaveDayPerExperience"].ToString();
        }

        protected void SetButton_Click(object sender, EventArgs e)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            config.AppSettings.Settings["CoefficientValue"].Value = CoefficientValueTextBox.Text;
            config.AppSettings.Settings["LeaveDaysPerMonth"].Value = LeaveDaysPerMonthTextBox.Text;
            config.AppSettings.Settings["ExperienceYears"].Value = YearsOfExperienceTextBox.Text;
            config.AppSettings.Settings["LeaveDayPerExperience"].Value = LeaveDaysPerExperienceTextBox.Text;
            config.Save();
        }
    }
}