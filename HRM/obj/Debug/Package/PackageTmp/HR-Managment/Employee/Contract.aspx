<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="Contract.aspx.cs" Inherits="HRM.HR_Managment.Employee.Contract" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;" id="contractVersion" runat="server">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Employee Contract Information <asp:Label runat="server" ID="ContractTypeHeaderText">(KPA Contract)</asp:Label> </strong></font><em>Please
                    enter employee contract information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="ContractTemplateTitleLabel" id="TextContractTemplateTitleLabel">
                            Contract type:</label>
                        <b>
                            <label runat="server" id="ContractTemplateTitleLabel">
                            </label>
                        </b></li>
                    <li class="second">
                        <label runat="server" for="ContractNumberTextBox" id="ContractNumberLabel">
                            Contract number:</label>
                        <asp:TextBox ID="ContractNumberTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ContractNumberRequiredFieldValidator" ValidationGroup="ContractTemplate"
                            ControlToValidate="ContractNumberTextBox" Display="None" runat="server" ErrorMessage="Please type contract number."></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label runat="server" for="StartDateTextBox" id="StarDateLabel">
                            Start date:</label>
                        <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="StartDateRequiredFieldValidator" ValidationGroup="ContractTemplate"
                            ControlToValidate="StartDateTextBox" Display="None" runat="server" ErrorMessage="Please select start date for contract."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" ControlToValidate="StartDateTextBox"
                            Display="None" runat="server" ErrorMessage="The start date format must be {dd.MM.yyyy}."
                            ValidationGroup="ContractTemplate" ValidationExpression="((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                        <input type="image" id="StartDateImage" src="../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" />
                        <ajaxToolkit:CalendarExtender ID="StartDateCalendarExtender" runat="server" TargetControlID="StartDateTextBox"
                            CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="StartDateImage" />
                    </li>
                    <li class="second">
                        <label runat="server" for="EndDateTextBox" id="EndDateLabel">
                            End date:</label>
                        <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <input type="image" id="EndDateImageButton" src="../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" />
                        <ajaxToolkit:CalendarExtender ID="EndDateCalendarExtender" runat="server" TargetControlID="EndDateTextBox"
                            CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="EndDateImageButton" />
                    </li>
                    <li>
                        <li class="second">
                            <label runat="server" id="emptyLabel">
                                &nbsp
                            </label>
                        </li>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
