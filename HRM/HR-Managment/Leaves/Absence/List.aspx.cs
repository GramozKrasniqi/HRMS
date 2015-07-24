using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Leaves.Absence
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EducationTrainingGridView.DataBind();
            //EducationTrainingObjectDataSource.Select();
        }

        protected void EducationTrainingObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (DateFromTextBox.Text != "" && DateToTextBox.Text != "")
            {
                DateTime dt;
                if (DateTime.TryParseExact(DateFromTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    e.InputParameters["dateFrom"] = dt;
                }
                if (DateTime.TryParseExact(DateToTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    e.InputParameters["dateTo"] = dt;
                }
            }
            else
            {
                DateFromTextBox.Text = "";
                DateToTextBox.Text = "";
            }
        }
    }
}