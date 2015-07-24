using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Mapper;
using Entities.Views;
using System.Text;
using System.Data.SqlClient;
using DAL.Mapper.Transactions;
using System.Configuration;

namespace HRM.HR_Managment.Employee
{
    public partial class PersonalInformation : TranslatedPage
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            #warning make this to values dynamic
            //valDateRange.CultureInvariantValues = false;
            //valDateRange.MinimumValue = DateTime.Today.AddYears(-63).ToString("dd.MM.yyyy");
            //valDateRange.MaximumValue = DateTime.Today.AddYears(-15).ToString("dd.MM.yyyy");
            //valDateRange.ErrorMessage = "The employee cannot be under 15 years of age or more than 63 years older.";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeNoTextBox.Text = new EmployeeMapper().GenerateEmployeeNo("AKP", "AKP");
                DateOfBirthTextBox.ToolTip = "Format: " + ConfigurationManager.AppSettings["DateFormat"];
                DateOfBirthRegularExpressionValidator.ErrorMessage = "The birth date format must be {" + ConfigurationManager.AppSettings["DateFormat"] + " }";
                DateOfBirthRegularExpressionValidator.ValidationExpression = ConfigurationManager.AppSettings["DateValidationExpression"];
            }

            if (Request.QueryString["action"] == "update" && Request.QueryString["EmployeeId"] != null)
            {
                if (!IsPostBack)
                {
                    EmployeeView view = new EmployeeMapper().Get(new EmployeeEntity() { Id = Convert.ToInt32(Request.QueryString["EmployeeId"]) });
                    EmployeeNoTextBox.Text = view.EmployeeNo;
                    PersonalNumberTextBox.Text = view.PersonalNumber;
                    FirstnameTextBox.Text = view.Firstname;
                    LastnameTextBox.Text = view.Lastname;
                    GenderDropDownList.Text = view.Gender.ToString();
                    MiddlenameTextBox.Text = view.Middlename;
                    DateOfBirthTextBox.Text = view.DateOfBirth.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                    NationalityDropDownList.Text = view.Nationality;

                    CountryCascadingDropDown.ContextKey = view.Country;
                    GenderCascadingDropDown.ContextKey = view.Gender.ToString();
                    NationalityCascadingDropDown.ContextKey = view.Nationality;
                    BankCascadingDropDown.ContextKey = view.Bank;
                    MaritalStatusCascadingDropDown.ContextKey = view.MaritalStatus.ToString();

                    CityTextBox.Text = view.City;
                    AddressTextBox.Text = view.Address;
                    MobilePhoneTextBox.Text = view.MobilePhone;
                    OtherEmailTextBox.Text = view.OtherEmail;
                    WorkEmailTextBox.Text = view.WorkEmail;
                    AccountNumberTextBox.Text = view.AccountNumber;

                    if (view.Image != null)
                    {
                        Session["fileContents_"] = view.Image;
                        string relativePath = Page.AppRelativeVirtualPath;
                        relativePath = relativePath.Replace("~", "");
                        empployeeImage.ImageUrl = String.Format("/HRM" + relativePath + "?preview=1");
                    }
                }

            }

            if (Request.QueryString["preview"] == "1")
            {
                if (Session["fileContents_"] != null)
                {
                    byte[] fileContents = (byte[])Session["fileContents_"];
                    if (fileContents.Length != 0)
                    {
                        Response.Clear();
                        Response.ContentType = "fileContentType_";
                        Response.BinaryWrite(fileContents);
                        Response.End();
                    }
                }
            }
        }


        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            EmployeeEntity entity = new EmployeeEntity();
            entity.EmployeeNo = EmployeeNoTextBox.Text;
            entity.Firstname = FirstnameTextBox.Text;
            entity.Middlename = "";
            entity.Middlename = MiddlenameTextBox.Text;
            entity.Lastname = LastnameTextBox.Text;

            DateTime dt;
            if (DateTime.TryParseExact(DateOfBirthTextBox.Text, ConfigurationManager.AppSettings["DateFormat"], null, System.Globalization.DateTimeStyles.None, out dt))
            {
                entity.DateOfBirth = dt;
            }

            entity.Gender = (GenderEnum)Convert.ToInt32(GenderDropDownList.SelectedValue);
            entity.NationalityId = Convert.ToInt32(NationalityDropDownList.SelectedValue);
            entity.CountryId = Convert.ToInt32(CountryDropDownList.SelectedValue);
            entity.Address = AddressTextBox.Text;
            entity.PersonalNumber = PersonalNumberTextBox.Text;
            entity.WorkEmail = WorkEmailTextBox.Text;
            entity.MobilePhone = MobilePhoneTextBox.Text;
            entity.OtherEmail = OtherEmailTextBox.Text;
            entity.City = CityTextBox.Text;
            entity.BankId = Convert.ToInt32(BankDropDownList.SelectedValue);
            entity.AccountNumber = AccountNumberTextBox.Text;
            entity.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(MaritalStatusDropDownList.SelectedValue);

            if (Session["fileContents_"] != null)
            {
                byte[] fileContents = (byte[])Session["fileContents_"];
                entity.Image = fileContents;
            }

            EmployeeMapper mapper = new EmployeeMapper();

            try
            {
                if (Request.QueryString["action"] == "update" && Request.QueryString["EmployeeId"] != null)
                {
                    entity.Id = Convert.ToInt32(Request.QueryString["EmployeeId"]);
                    mapper.Update(entity);
                    Response.Redirect("EducationAndExperience.aspx?action=update&EmployeeId=" + entity.Id);
                }
                else
                {
                    ReminderEntity reminder = new ReminderEntity();
                    reminder.EntityPK = entity.Id.ToString();
                    reminder.EntityPKType = typeof(int).ToString();
                    reminder.ReminderType = ReminderEnum.EmployeeNoContract;
                    reminder.Url = "/HRM/HR-Managment/Employee/EmployeesWithoutContract.aspx";
                    new EmployeeMapperTransaction().InsertWithReminder(entity, reminder);
                    Response.Redirect("EducationAndExperience.aspx?EmployeeId=" + entity.Id);
                }
            }
            catch (SqlException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>displayNoty('The Employee No { " + EmployeeNoTextBox.Text + " } has been used, plase write another number');</script>");

                // if the script is not already registered
                if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
            }
            finally
            {
            }
        }

        protected void saveImage(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string tempPath = System.IO.Path.GetTempPath();
            System.Drawing.Image img = new GUIHelper().byteArrayToImage(e.GetContents());

            if (Session["fileContentType_"] == null)
            {
                Session.Add(("fileContentType_"), e.ContentType);
            }
            Session["fileContentType_"] = e.ContentType;

            if (Session["fileContents_"] == null)
            {
                Session.Add("fileContents_", e.GetContents());
            }
            Session["fileContents_"] = e.GetContents();

            string relativePath = Page.AppRelativeVirtualPath;
            relativePath = relativePath.Replace("~", "");
            e.PostedUrl = String.Format("/HRM" + relativePath + "?preview=1");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }


    }
}