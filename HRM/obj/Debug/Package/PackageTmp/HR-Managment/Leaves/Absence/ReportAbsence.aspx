<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReportAbsence.aspx.cs" Inherits="HRM.HR_Managment.Leaves.Absence.ReportAbsence" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/autocomplete.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%; height: 350px;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Report absence: </strong></font>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="OrganisationalUnitDropDownList" id="OrganisationalUnitLabel">
                            Organizational unit:</label>
                        <asp:DropDownList ID="OrganisationalUnitDropDownList" runat="server" TabIndex="3">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="OrganisationalUnitCascadingDropDown" runat="server"
                            ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnit" ServiceMethod="GetOrganizationalUnits"
                            TargetControlID="OrganisationalUnitDropDownList" PromptText="Please select" />
                    </li>
                    <li class="second">
                       <label runat="server" for="AbsenceEmployeeDropDownList" id="AbsenceEmployeeLabel">
                            Absence employee:</label>
                        <asp:DropDownList ID="AbsenceEmployeeDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="AbsenceEmployeeRequiredFieldValidator" ControlToValidate="AbsenceEmployeeDropDownList"
                        Display="None" runat="server" ErrorMessage="Please select an employee."
                        InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="AbsenceEmployeeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="AbsenceEmployee" ServiceMethod="GetEmployeesByOrganisationalUnit" TargetControlID="AbsenceEmployeeDropDownList"
                            PromptText="Please select" ParentControlID="OrganisationalUnitDropDownList" />
                    </li>
                </ul>
                <ul id="full">
                 <li>
                        <label runat="server" for="OtherInfoTextBox" id="OtherInfoLabel">
                            Notes:</label>
                        <asp:TextBox ID="OtherInfoTextBox" TextMode="MultiLine" runat="server" CssClass="fullmultitext" TabIndex="6"></asp:TextBox>
                    </li>
                </ul>
            </div>
            <ul class="clearfix">
                <li>
                    <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                        OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                    <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                        TabIndex="18"></asp:Button></li>
            </ul>
        </div>
    </div>
</asp:Content>
