using DAL.Mapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.HR_Managment.Definition.LeaveType
{
    public partial class Edit : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            //http://localhost:14994/HRM/HR-Managment/Definition/LeaveType/Edit.aspx?LeaveTypeNameId=3&action=delete&LeaveTypeId=15
            if (Request.QueryString["LeaveTypeNameId"] != null && Request.QueryString["action"] == "delete")
            {
                new LeaveTypeLevelMapper().Delete(new Entities.LeaveTypeLevelEntity() { Id = Convert.ToInt32(Request.QueryString["LeaveTypeNameId"]) });
            }
           

            if (!IsPostBack)
            {
                GUIHelper.BindEnum2DropDownList(TypeDropDownList, typeof(LeaveNameType), true);

                if (Request.QueryString["LeaveTypeId"] != null)
                {
                    int LeaveTypeId;
                    
                    LeaveTypeEntity entity = new LeaveTypeEntity();
                    Int32.TryParse(Request.QueryString["LeaveTypeId"], out LeaveTypeId);
                    entity.Id = LeaveTypeId;

                    LeaveTypeMapper mapper = new LeaveTypeMapper();
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
            LeaveTypeLevelEntity entity = new LeaveTypeLevelEntity();
            LeaveTypeLevelMapper mapper = new LeaveTypeLevelMapper();

            entity.LeaveTypeId = Convert.ToInt32(Request.QueryString["LeaveTypeId"]);
            entity.NoOfDays = Convert.ToInt32(NoDaysTextBox.Text);
            entity.PaymentPercentage = Convert.ToInt32(PaymentPercentageTextBox.Text);
            entity.LeaveNameType = (LeaveNameType)Enum.Parse(typeof(LeaveNameType), TypeDropDownList.SelectedValue.ToString());

            mapper.Insert(entity);

            LeaveTypeGridView.DataBind();

        }
    }
}