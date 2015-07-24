<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="HRM.HR_Managment.Definition.LeaveType.Add" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <script type="text/javascript" src="/HRM/Scripts/QueryString.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Leave Types: </strong></font><em>Please
                    enter leave type information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="TitleTextBox" id="TitleLabel">
                            Title:</label>
                        <asp:TextBox ID="TitleTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" ControlToValidate="TitleTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter title."></asp:RequiredFieldValidator>
                    </li>

                    <li class="second">
                        <label runat="server" for="DescriptionTextBox" id="DescriptionLabel">
                            Description:</label>
                        <asp:TextBox ID="DescriptionTextBox" TextMode="MultiLine" runat="server" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator" ControlToValidate="DescriptionTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter the personal number."></asp:RequiredFieldValidator>
                    </li>
                    <li />
                    <li class="second">
                            <label runat="server" id="Label1">
                                &nbsp
                            </label>
                            <asp:Button ID="ClearFirstFormButton" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear"></asp:Button>
                            <asp:Button ID="AddLeaveType" ToolTip="Add" CssClass="secondaryButton"
                                runat="server" Text="Add" OnClick="AddLeaveType_Click"></asp:Button>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
