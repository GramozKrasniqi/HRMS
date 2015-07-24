<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="HRM.HR_Managment.OrganizationalUnit.Add" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%; height: 350px;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Insert a new organizational unit: </strong></font>
                <em>Please enter organizational unit information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="TitleTextBox" id="TitleLabel">
                            Title:</label>
                        <asp:TextBox ID="TitleTextBox" runat="server" TabIndex="15">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" ControlToValidate="TitleTextBox"
                            Display="None" runat="server" ErrorMessage="Please write organizational unit title."></asp:RequiredFieldValidator>
                    </li>
                    <li class="second">
                        <label runat="server" for="OrganizationalUnitGroupDropDownList" id="OrganizationalUnitGroupLabel">
                            Unit group:</label>
                        <asp:DropDownList ID="OrganizationalUnitGroupDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="OrganizationalUnitGroupRequiredFieldValidator" ControlToValidate="OrganizationalUnitGroupDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select the organizational unit group."
                            InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="OrganizationalUnitGroupCascadingDropDown" runat="server"
                            ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnitsGroups" ServiceMethod="GetOrganizationalUnitGroups"
                            TargetControlID="OrganizationalUnitGroupDropDownList" PromptText="Please select" ContextKey="" />
                    </li>
                    <li>
                        <label runat="server" for="ParentDropDownList" id="ParentLabel">
                            Parent unit:</label>
                        <asp:DropDownList ID="ParentDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="ParentCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="OrganizationalUnit" ServiceMethod="GetOrganizationalUnits" TargetControlID="ParentDropDownList"
                            PromptText="Please select" ContextKey="" />
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
                        TabIndex="18"></asp:Button></li>
            </ul>
        </div>
    </div>
</asp:Content>
