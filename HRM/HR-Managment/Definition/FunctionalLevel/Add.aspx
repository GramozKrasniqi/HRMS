<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="HRM.HR_Managment.Definition.FunctionalLevel.Add" %>

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
                <font color="#707070"><strong>Insert a new functional level: </strong></font>
                <em>Please enter functional level information: </em>
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
