<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Edit.aspx.cs" Inherits="HRM.HR_Managment.JobTitle.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Step 1 - Edit job title </strong></font><em>Please enter job title
                    information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="JobCodeCurrentLabel" id="JobCodeLabel">
                            Job code:</label>
                         <label runat="server" id="JobCodeCurrentLabel">
                            #:</label>
                    </li>
                    <li class="second">
                        <label runat="server" for="JobTitleTextBox" id="JobTitleLabel">
                            Job title:</label>
                        <asp:TextBox ID="JobTitleTextBox" runat="server" TabIndex="15">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="JobTitleRequiredFieldValidator" ControlToValidate="JobTitleTextbox"
                            Display="None" runat="server" ErrorMessage="Please write job title."></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label runat="server" for="ReportsToDropDownList" id="ReportsToLabel">
                            Reports to:</label>
                        <asp:DropDownList ID="ReportsToDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="ReportsToCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="JobTitle" ServiceMethod="GetJobTitlesByOrganisationalUnit" TargetControlID="ReportsToDropDownList"
                            PromptText="Please select" />
                    </li>
                    <li class="second">
                        <label runat="server" for="OrganizationalUnitDropDownList" id="OrganizationalUnitLabel">
                            Organization unit:</label>
                        <asp:DropDownList ID="OrganizationalUnitDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="OrganizationalUnitRequiredFieldValidator" ControlToValidate="OrganizationalUnitDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select the organizational unit."
                            InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="OrganizationalUnitCascadingDropDown" runat="server"
                            ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnits" ServiceMethod="GetOrganizationalUnits"
                            TargetControlID="OrganizationalUnitDropDownList" PromptText="Please select" />
                    </li>
                </ul>
                <ul class="full">
                    <li>
                        <label runat="server" for="OtherInfoTextBox" id="OtherInfoLabel">
                            Description:</label>
                        <asp:TextBox ID="OtherInfoTextBox" TextMode="MultiLine" runat="server" CssClass="fullmultitext"
                            TabIndex="6"></asp:TextBox>
                    </li>
                </ul>
            </div>
            <ul class="clearfix">
                <li>
                    <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                        OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                    <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                        TabIndex="18" onclick="CancelButton_Click"></asp:Button></li>
            </ul>
        </div>
    </div>
</asp:Content>
