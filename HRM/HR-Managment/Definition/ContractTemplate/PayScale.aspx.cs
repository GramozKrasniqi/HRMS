using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text;
using Entities;
using DAL.Mapper;

namespace HRM.HR_Managment.Definition.ContractTemplate
{
    public partial class PayScale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ContractTemplateId"] == null)
            {
                Response.Redirect("List.aspx");
            }
        }

        protected void grdOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Expand")
            {
                ImageButton imgbtn;
                GridView gv = (GridView)(sender);
                Int32 rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                PlaceHolder objPH = (PlaceHolder)(gv.Rows[rowIndex].FindControl("objPHOrderDetails"));
                ObjectDataSource objDS = (ObjectDataSource)(gv.Rows[rowIndex].FindControl("objOrderDetails"));
                GridView objChildGrid = (GridView)(gv.Rows[rowIndex].FindControl("grdOrderDetails"));
                imgbtn = (ImageButton)(gv.Rows[rowIndex].FindControl("ImgBtn"));


                if (imgbtn.ImageUrl == "/HRM/images/gridplus.gif")
                {
                    objDS.SelectParameters["jobCode"].DefaultValue = gv.DataKeys[rowIndex][0].ToString();
                    objDS.SelectParameters["contractTemplateId"].DefaultValue = Request.QueryString["ContractTemplateId"].ToString();

                    Session["jobCode"] = gv.DataKeys[rowIndex][0].ToString();

                    imgbtn.ImageUrl = @"/HRM/images/gridminus.gif";
                    if (objChildGrid != null)
                    {
                        if (objPH != null)
                            objPH.Visible = true;
                        objChildGrid.Visible = true;
                    }
                }
                else
                {
                    if (objChildGrid != null)
                    {
                        imgbtn.ImageUrl = @"/HRM/images/gridplus.gif";
                        if (objPH != null)
                            objPH.Visible = false;
                        objChildGrid.Visible = false;
                    }
                }
            }
        }

        protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Expand")
            {
                ImageButton imgbtn;
                GridView gv = (GridView)(sender);
                Int32 rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                PlaceHolder objPH = (PlaceHolder)(gv.Rows[rowIndex].FindControl("objPHOrderDetailsDetails"));
                ObjectDataSource objDS = (ObjectDataSource)(gv.Rows[rowIndex].FindControl("objOrderDetailsDetails"));
                GridView objChildGrid = (GridView)(gv.Rows[rowIndex].FindControl("grdOrderDetailsDetails"));
                imgbtn = (ImageButton)(gv.Rows[rowIndex].FindControl("ImgBtn2"));


                if (imgbtn.ImageUrl == "/HRM/images/gridplus.gif")
                {
                    objDS.SelectParameters["jobCode"].DefaultValue = Session["jobCode"].ToString();
                    objDS.SelectParameters["contractTemplateId"].DefaultValue = Request.QueryString["ContractTemplateId"].ToString();

                    Session["gradeId"] = gv.Rows[rowIndex].Cells[1].Text;

                    imgbtn.ImageUrl = @"/HRM/images/gridminus.gif";
                    if (objChildGrid != null)
                    {
                        if (objPH != null)
                            objPH.Visible = true;
                        objChildGrid.Visible = true;
                    }
                }
                else
                {
                    if (objChildGrid != null)
                    {
                        imgbtn.ImageUrl = @"/HRM/images/gridplus.gif";
                        if (objPH != null)
                            objPH.Visible = false;
                        objChildGrid.Visible = false;
                    }
                }
            }
            if (e.CommandName == "ShowPopup")
            {
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                GradeLabel.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
                // DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                GradeEntryTextBox.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                GradeKCBTextBox.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                Popup(true);
            }
        }

        protected void grdOrderDetailsDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopup2")
            {
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                StepLabel.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
                // DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                StepEntryTextBox.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
                Popup2(true);
            }
        }

        protected void grdOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgBtn;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                imgBtn = (ImageButton)(e.Row.FindControl("ImgBtn"));
                imgBtn.CommandArgument = e.Row.RowIndex.ToString();

                if (e.Row.Cells[0].Text == Session["jobCode"])
                {
                    PlaceHolder objPH;
                    objPH = (PlaceHolder)(e.Row.FindControl("objPHOrderDetails"));
                    if (objPH != null)
                        objPH.Visible = true;

                    if (imgBtn.ImageUrl == "/HRM/images/gridplus.gif")
                        imgBtn.ImageUrl = @"/HRM/images/gridminus.gif";
                    else
                        imgBtn.ImageUrl = @"/HRM/images/gridplus.gif";
                }
            }
        }

        protected void grdOrdersDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgBtn;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                imgBtn = (ImageButton)(e.Row.FindControl("ImgBtn2"));
                imgBtn.CommandArgument = e.Row.RowIndex.ToString();

                if (e.Row.Cells[0].Text == Session["jobCode"])
                {
                    PlaceHolder objPH;
                    objPH = (PlaceHolder)(e.Row.FindControl("objPHOrderDetailsDetails"));
                    if (objPH != null)
                        objPH.Visible = true;

                    if (imgBtn.ImageUrl == "/HRM/images/gridplus.gif")
                        imgBtn.ImageUrl = @"/HRM/images/gridminus.gif";
                    else
                        imgBtn.ImageUrl = @"/HRM/images/gridplus.gif";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            PayScaleGradeItemEntity grade = new PayScaleGradeItemEntity();
            grade.GradeId = GradeLabel.Text;
            grade.GradeEntry = Convert.ToDouble(GradeEntryTextBox.Text);
            grade.GradeKCB = Convert.ToDouble(GradeKCBTextBox.Text);

            new PayScaleMapper().UpdateGrade(grade, Convert.ToInt32(Request.QueryString["ContractTemplateId"].ToString()), Session["jobCode"].ToString());
            Response.Redirect("PayScale.aspx?ContractTemplateId=" + Request.QueryString["ContractTemplateId"]);
        }
        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            PayScaleStepItemEntity step = new PayScaleStepItemEntity();
            step.StepId = StepLabel.Text;
            step.StepEntry = Convert.ToDouble(StepEntryTextBox.Text);

            new PayScaleMapper().UpdateStep(step, Convert.ToInt32(Request.QueryString["ContractTemplateId"].ToString()), Session["jobCode"].ToString(), Session["gradeId"].ToString());
            Response.Redirect("PayScale.aspx?ContractTemplateId=" + Request.QueryString["ContractTemplateId"]);
        }

        //To show message after performing operations
        void Popup(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
            }
        }
        void Popup2(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup2(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup2(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
            }
        }
    }

}