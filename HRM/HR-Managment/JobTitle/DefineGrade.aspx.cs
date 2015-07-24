using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Mapper;
using Entities;
using System.Text;

namespace HRM.HR_Managment.JobTitle
{
    public partial class DefineGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["jobCode"] != null)
            {

            }
            else
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void newEducationButton_Click(object sender, EventArgs e)
        {
            GradeEntity grade = new GradeEntity();
            grade.Id = GradeTextBox.Text;
            grade.JobCode = Request.QueryString["jobCode"];
            try
            {
                new GradeMapper().Insert(grade);
                Response.Redirect("DefineGrade.aspx?jobCode=" + Request.QueryString["jobCode"]);
            }
            catch (Exception)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>displayNoty('Please write another Grade name beacuse this Grade name already exists.');</script>");

                // if the script is not already registered
                if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            StepEntity step = new StepEntity();
            step.Id = StepTextBox.Text;
            step.GradeId = GradeStepDropDownList.SelectedValue;
            step.Description = "";
            try
            {
                new StepMapper().Insert(step);
                Response.Redirect("DefineGrade.aspx?jobCode=" + Request.QueryString["jobCode"]);
            }
            catch (Exception)
            {
               StringBuilder sb = new StringBuilder();
               sb.Append("<script language='javascript'>displayNoty('Please write another Step name beacuse this Step name already exists.');</script>");

                // if the script is not already registered
                if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "HeyPopup"))
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "HeyPopup", sb.ToString());
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx?jobCode=" + Request.QueryString["jobCode"]);
        }
    }
}