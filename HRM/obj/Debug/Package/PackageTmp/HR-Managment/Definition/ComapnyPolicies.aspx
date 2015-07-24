<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ComapnyPolicies.aspx.cs" Inherits="HRM.HR_Managment.Definition.ComapnyPolicies" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table tr td
        {
            border: none !important;
        }
        ul#double li
        {
            height: 30px;
        }
        ul#double label
        {
            margin-top: 5px;
        }
        ul#double input[type="text"]
        {
            min-width: 100px;
            width: 185px !important;
        }
        
        .modalBackground
        {
            width: 100%;
            height: 100%;
            background-color: #EBEBEB;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .ModalWindow
        {
            border: solid1px#c0c0c0;
            background: #f0f0f0;
            padding: 0px10px10px10px;
            position: absolute;
            top: -1000px;
            text-align: center;
            vertical-align: middle;
        }
        .confirm
        {
            background-color: White;
            padding: 10px;
            width: 370px;
        }
        
        .confirmTextContainer
        {
            margin-bottom: 15px;
        }
        
        .confirm ul li
        {
            float: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>Company policies: </strong></font><em>Please
                    enter company policies information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="CoefficientValueTextBox" id="CoefficientValueLabe">
                            KCB coefficient value:</label>
                        <asp:TextBox ID="CoefficientValueTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="CoefficientValueNumericUpDownExtender" runat="server"
                            TargetControlID="CoefficientValueTextBox" Minimum="1" Maximum="25">
                        </asp:NumericUpDownExtender>
                    </li>
                    <li class="second">
                        <label runat="server" for="LeaveDaysPerMonthTextBox" id="LeaveDaysPerMonthLabel">
                            Leave days / Month:</label>
                        <asp:TextBox ID="LeaveDaysPerMonthTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="LeaveDaysPerMonthNumericUpDownExtender" runat="server"
                            TargetControlID="LeaveDaysPerMonthTextBox" Minimum="1" Maximum="25">
                        </asp:NumericUpDownExtender>
                    </li>
                    <li>
                        <label runat="server" for="YearsOfExperienceTextBox" id="YearsOfExperienceLabel">
                            Years of experience:</label>
                        <asp:TextBox ID="YearsOfExperienceTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="YearsOfExperienceNumericUpDownExtender" runat="server"
                            TargetControlID="YearsOfExperienceTextBox" Minimum="1" Maximum="25">
                        </asp:NumericUpDownExtender>
                    </li>
                    <li class="second">
                        <label runat="server" for="LeaveDaysPerExperienceTextBox" id="LeaveDaysPerExperienceLabel">
                            Leave days values:</label>
                        <asp:TextBox ID="LeaveDaysPerExperienceTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="LeaveDaysPerExperienceNumericUpDownExtender" runat="server"
                            TargetControlID="LeaveDaysPerExperienceTextBox" Minimum="1" Maximum="25">
                        </asp:NumericUpDownExtender>
                    </li>
                </ul>
            </div>
            <ul class="clearfix">
                <li>
                    <asp:Button ID="SetButton" CssClass="right login_btn" runat="server" Text="Set »"
                        TabIndex="19" OnClick="SetButton_Click"></asp:Button>
                    <asp:ConfirmButtonExtender ID="SetButtonConfirmButton" runat="server" TargetControlID="SetButton"
                        ConfirmText="Are you sure you want to click this?" DisplayModalPopupID="mpe" />
                    <asp:Button ID="BackButton" CssClass="right login_btn" runat="server" Text="Back"
                        TabIndex="18"></asp:Button></li>
            </ul>
        </div>
        <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
            <div class="confirm">
                <div class="confirmTextContainer">
                    <b>
                        <asp:Label Text="Are you sure you want to change the data?" ID="popupMessage" runat="server"
                            CssClass="confirmHeader"></asp:Label></b>
                    <br />
                    <i>
                        <asp:Label Text="If you change the company policy information please be advised that you must also change the current contracts of your employees. The system will proceed with the changes and redirect you to change the contracts."
                            ID="Label1" runat="server" CssClass="confirmBody"></asp:Label></i>
                </div>
                <ul>
                    <li>
                        <asp:Button ID="OkButton" ToolTip="Save" CssClass="secondaryButton" runat="server"
                            Text="Proceed"></asp:Button>
                    </li>
                    <li>
                        <asp:Button ID="CancelButton" CssClass="secondaryButton" ToolTip="Cancel" runat="server"
                            Text="Cancel"></asp:Button>
                    </li>
                </ul>
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpe" runat="server" BackgroundCssClass="modalBackground"
            CancelControlID="CancelButton" OkControlID="OkButton" PopupControlID="popup"
            TargetControlID="SetButton">
        </asp:ModalPopupExtender>
    </div>
</asp:Content>
