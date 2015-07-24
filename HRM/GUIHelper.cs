using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using Entities.Views;

namespace HRM
{
    public class GUIHelper
    {
        public string ReplaceTemplateContractWithConcreteContract(string content, JobDetailsSessionView jbs, EmployeeView employeeView)
        {
            //Employee
            content = content.Replace(@"{#EmployeeName}", employeeView.ToString());
            content = content.Replace(@"{#EmployeeNo}", employeeView.EmployeeNo);
            content = content.Replace(@"{#DateOfBirth}", employeeView.DateOfBirth.ToString("dd.MM.yyyy"));
            content = content.Replace(@"{#PersonalNo}", employeeView.PersonalNumber);
            content = content.Replace(@"{#Gender}", employeeView.Gender.ToString());
            content = content.Replace(@"{#Address}", employeeView.Address);
            content = content.Replace(@"{#Country}", employeeView.Country);

            //JobTitle
            content = content.Replace(@"{#JobCode}", jbs.Job.Code);
            content = content.Replace(@"{#JobTitle}", jbs.Job.Title);
            content = content.Replace(@"{#OrganisationalUnit}", jbs.OrganisationalUnit.Title);
            #warning changed please review and edit
            //content = content.Replace(@"{#GradeKCB}", jbs.Grade.KCB.ToString("f2"));
            content = content.Replace(@"{#Step}", jbs.Step.Id);
            //content = content.Replace(@"{#StepEntry}", jbs.Step.Entry.ToString("f2"));
            content = content.Replace(@"{#Step}", jbs.Step.Id);
            content = content.Replace(@"{#Grade}", jbs.Grade.Id);
            content = content.Replace(@"{#JobDescription}", jbs.Job.Description);
            //content = content.Replace(@"{#ReportsTo}", jbs.Job.Description);

            //Contract
            
            content = content.Replace(@"{#OfficiallyApprovedDate}", DateTime.Now.ToString("dd.MM.yyyy"));
            //content = content.Replace(@"{#GrossValue}", jbs.Job.Code);

            //General
            content = content.Replace(@"{#TodayDate}", DateTime.Now.ToString("dd.MM.yyyy"));
            content = content.Replace(@"{#Time}", DateTime.Now.ToString("HH:mm"));

            return content;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Pass in a DropDownList and typeof(YourEnum) as parameters to auto-bind a dropdownlist to an enum
        /// </summary>
        /// <param name="ddl">ddlMyDropDownList</param>
        /// <param name="enumType">typeof(MyEnum)</param>
        /// <param name="retainSelected">true/false indicating if the currently selected item should remain selected</param>
        public static void BindEnum2DropDownList(DropDownList ddl, Type enumType, bool retainSelected)
        {
            // retain the currently selected item if possible
            string currentlySelectedValue = string.Empty;
            if (retainSelected)
                currentlySelectedValue = ddl.SelectedValue;


            ddl.DataSource = GetListItemsFromEnum(enumType);
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();

            // in the event that there was a selected item, keep it.
            if (currentlySelectedValue != string.Empty && retainSelected == true)
            {
                ddl.ClearSelection();
                ddl.Items.FindByText(currentlySelectedValue).Selected = true;
            }
        }


        public static ListItemCollection GetListItemsFromEnum(Type enumType)
        {
            // container to be returned
            ListItemCollection items = new ListItemCollection();
            // break down the enumerator items into key/value pairs
            string[] names = Enum.GetNames(enumType);
            Array values = Enum.GetValues(enumType);
            // piece together the key/pairs into the listitem collection
            items.Add(new ListItem("Please select", ""));
            for (int i = 1; i <= names.Length - 1; i++)
            {
                items.Add(new ListItem(names[i], i.ToString()));
            }
            // return it
            return items;
        }
    }
}
