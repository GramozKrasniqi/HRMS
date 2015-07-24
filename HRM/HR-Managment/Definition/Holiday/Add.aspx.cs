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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddLeaveType_Click(object sender, EventArgs e)
        {
            HolidayGroupEntity entity = new HolidayGroupEntity();

            entity.Title = TitleTextBox.Text;
            entity.Description = DescriptionTextBox.Text;

            HolidayGroupMapper mapper = new HolidayGroupMapper();
            mapper.Insert(entity);

            Response.Redirect(String.Format("Edit.aspx?HolidayGroupId={0}", entity.Id));
        }
    }
}