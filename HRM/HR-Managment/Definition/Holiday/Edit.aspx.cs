using DAL.Mapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Definition.Holiday
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["HolidayGroupId"] != null)
                {
                    int HolidayGroupId;

                    HolidayGroupEntity entity = new HolidayGroupEntity();
                    Int32.TryParse(Request.QueryString["HolidayGroupId"], out HolidayGroupId);
                    entity.Id = HolidayGroupId;

                    HolidayGroupMapper mapper = new HolidayGroupMapper();
                    entity = mapper.Get(entity);

                    TitleTextBox.Text = entity.Title;
                    DescriptionTextBox.Text = entity.Description;
                }
            }
        }

        protected void SaveLeaveType_Click(object sender, EventArgs e)
        {

        }

        protected void AddPaymentTypeButton_Click(object sender, EventArgs e)
        {
            HolidayEntity entity = new HolidayEntity();
            HolidayMapper mapper = new HolidayMapper();

            entity.HolidayGroupId = Convert.ToInt32(Request.QueryString["HolidayGroupId"]);

            DateTime dt;
            if (DateTime.TryParseExact(StartDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                entity.StartDate = dt;
            }
            if (DateTime.TryParseExact(EndDateTextBox.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                entity.EndDate = dt;
            }

            entity.Title = HolidayTitleTextBox.Text;
            entity.Status = StatusEnum.Active;
            entity.Description = "";

            mapper.Insert(entity);

            HolidayTitleTextBox.Text = "";
            StartDateTextBox.Text = "";
            EndDateTextBox.Text = "";

            LeaveTypeGridView.DataBind();

        }
    }
}