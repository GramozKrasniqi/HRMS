using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using System.Web.Services;
using System.Configuration;

namespace HRM.HR_Managment.Employee
{
    public partial class EducationAndExperience : System.Web.UI.Page
    {
        [WebMethod]
        public static void skillManagment(string employeeId, string value, string action)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("You must supply a value.");
            }
            if (string.IsNullOrEmpty(action))
            {
                throw new Exception("You must supply a action.");
            }

            if (action == "insert")
            {
                SkillEntity ent = new SkillEntity(){ EmployeeId= Convert.ToInt32(employeeId), SkillName= value};
                new SkillMapper().Insert(ent);
            }
            else
            {
                SkillEntity ent = new SkillEntity() { EmployeeId = Convert.ToInt32(employeeId), SkillName = value };
                new SkillMapper().Delete(ent);
            }
        }

        [WebMethod]
        public static string GetSkills(string EmployeeId)
        {
            if (string.IsNullOrEmpty(EmployeeId))
            {
                throw new Exception("You must supply a EmployeeId.");
            }

            string skill = "";

            List<SkillEntity> list = new SkillMapper().List(Convert.ToInt32(EmployeeId), "");
            foreach(SkillEntity ent in list)
            {
                skill += ent.SkillName + ",";
            }

            if (skill.Length != 0)
            {
                skill.Remove(skill.Length - 1);
            }

            return skill;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EducationDateFromTextBox.ToolTip = "Format: " + ConfigurationManager.AppSettings["DateFormat"];
                EducationDateFromRegularExpressionValidator.ErrorMessage = "The education date format must be {" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                EducationDateFromRegularExpressionValidator.ValidationExpression = ConfigurationManager.AppSettings["DateValidationExpression"];
                EducationDateFromCalendarExtender.Format = ConfigurationManager.AppSettings["DateFormat"];

                EducationDateToTextBox.ToolTip = "Format: " + ConfigurationManager.AppSettings["DateFormat"];
                EducationDateToCalendarExtender.Format = ConfigurationManager.AppSettings["DateFormat"];

                ((BoundField)EducationTrainingGridView.Columns[0]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + "}";
                ((BoundField)EducationTrainingGridView.Columns[1]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + "}";
                ((BoundField)EducationTrainingGridView.Columns[1]).NullDisplayText = "On Going";

                ExperienceDateFromTextBox.ToolTip = "Format: " + ConfigurationManager.AppSettings["DateFormat"];
                ExperienceDateFromRegularExpressionValidator.ErrorMessage = "The experience date from format must be {" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                ExperienceDateFromRegularExpressionValidator.ValidationExpression = ConfigurationManager.AppSettings["DateValidationExpression"];
                ExperienceDateFromCalendarExtender.Format = ConfigurationManager.AppSettings["DateFormat"];

                ExperienceDateToTextBox.ToolTip = "Format: " + ConfigurationManager.AppSettings["DateFormat"];
                ExperienceDateToCalendarExtender.Format = ConfigurationManager.AppSettings["DateFormat"];


                ((BoundField)ExperienceGridView.Columns[0]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + "}";
                ((BoundField)ExperienceGridView.Columns[1]).DataFormatString = "{0:" + ConfigurationManager.AppSettings["DateFormat"] + "}";
                ((BoundField)ExperienceGridView.Columns[1]).NullDisplayText = "On Going";
            }


            if (Request.QueryString["delete"] != null && Request.QueryString["educationId"] != null)
            {
                if (Session["EmployeeId"] != null)
                {
                    new EducationTrainingMapper().Delete(new EducationTrainingEntity() { Id = Convert.ToInt32(Request.QueryString["educationId"]) });
                    Response.Redirect("EducationAndExperience.aspx?EmployeeId=" + Convert.ToInt32(Session["EmployeeId"]));
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
            else if (Request.QueryString["delete"] != null && Request.QueryString["experienceId"] != null)
            {
                if (Session["EmployeeId"] != null)
                {
                    new ExperienceMapper().Delete(new ExperienceEntity() { Id = Convert.ToInt32(Request.QueryString["experienceId"]) });
                    Response.Redirect("EducationAndExperience.aspx?EmployeeId=" + Convert.ToInt32(Session["EmployeeId"]));
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
            else if (Request.QueryString["EmployeeId"] != null)
            {
                if (new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) }).EmployeeNo != null)
                {
                    Session.Add("EmployeeId", Request.QueryString["EmployeeId"]);
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

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "update")
            {
                Response.Redirect("Details.aspx?EmployeeId=" + Request.QueryString["EmployeeId"]);
            }
            else
            {
                Response.Redirect("JobDetails.aspx?EmployeeId=" + Request.QueryString["EmployeeId"]);
            }
        }

        protected void newEducationButton_Click(object sender, EventArgs e)
        {
            if (Session["EmployeeId"] != null)
            {
                EducationTrainingEntity entity = new EducationTrainingEntity();

                DateTime dt;
                if (DateTime.TryParseExact(EducationDateFromTextBox.Text, ConfigurationManager.AppSettings["DateFormat"], null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    entity.DateFrom = dt;
                }

                if (DateTime.TryParseExact(EducationDateToTextBox.Text, ConfigurationManager.AppSettings["DateFormat"], null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    entity.DateTo = dt;
                }
                else
                {
                    entity.DateTo = null;
                }

                entity.OrganizationContact = OrganisationContactTextBox.Text;
                entity.OrganizationName = OrganisationNameTextBox.Text;
                entity.QualificationAwarded = QualificationAwardedTextBox.Text;
                entity.EmployeeId = Convert.ToInt32(Request.QueryString["EmployeeId"]);

                #warning send warning message to ui
                if (EducationTrainingLevelDropDownList.SelectedValue == "")
                {
                    return;
                }
                entity.Level = (EducationTrainingLevelEnum)Convert.ToInt32(EducationTrainingLevelDropDownList.SelectedValue);

                EducationTrainingMapper mapper = new EducationTrainingMapper();
                mapper.Insert(entity);

                Response.Redirect("EducationAndExperience.aspx?EmployeeId=" + Convert.ToInt32(Session["EmployeeId"]));
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }

        protected void newExperience_Click(object sender, EventArgs e)
        {
            if (Session["EmployeeId"] != null)
            {
                ExperienceEntity entity = new ExperienceEntity();
                DateTime dt;
                if (DateTime.TryParseExact(ExperienceDateFromTextBox.Text, ConfigurationManager.AppSettings["DateFormat"], null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    entity.DateFrom = dt;
                }

                if (DateTime.TryParseExact(ExperienceDateToTextBox.Text, ConfigurationManager.AppSettings["DateFormat"], null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    entity.DateTo = dt;
                }
                else
                {
                    entity.DateTo = null;
                }
                entity.PositionHeld = PositionHeldTextBox.Text;
                entity.EmployeeName = EmployeeNameTextBox.Text;
                entity.EmployeeContact = EmployeeContactTextBox.Text;
                entity.BusinessType = BusinessTypeTextBox.Text;

                entity.EmployeeId = Convert.ToInt32(Request.QueryString["EmployeeId"]);

                ExperienceMapper mapper = new ExperienceMapper();
                mapper.Insert(entity);

                Response.Redirect("EducationAndExperience.aspx?EmployeeId=" + Convert.ToInt32(Session["EmployeeId"]));
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void FinishNewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalInformation.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonalInformation.aspx?action=update&EmployeeId=" + Session["EmployeeId"]);
        }
    }
}