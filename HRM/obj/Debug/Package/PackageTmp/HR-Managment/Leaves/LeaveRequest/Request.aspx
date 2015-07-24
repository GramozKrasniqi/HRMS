<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Request.aspx.cs" Inherits="HRM.HR_Managment.Leaves.LeaveRequest.Request"
    EnableEventValidation="false" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/autocomplete.css" />
    <style type="text/css">
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
        
        .confirm ul
        {
            padding-left: 0px;
        }
        
        .confirm ul li
        {
            float: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%; height: 350px;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Request a leave: </strong></font>
                <asp:LinkButton ID="showbilancePopup" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm"
                    Text="Show leave bilance" CausesValidation="False" />
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="LeaveTypeDropDownList" id="LeaveTypeLabel">
                            Leave type:</label>
                        <asp:DropDownList ID="LeaveTypeDropDownList" runat="server" TabIndex="15">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="LeaveTypeRequiredFieldValidator" ControlToValidate="LeaveTypeDropDownList"
                            Display="None" runat="server" ErrorMessage="Please choose a leave type."></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="LeaveTypeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="LeaveTypes" ServiceMethod="GetLeaveTypes" TargetControlID="LeaveTypeDropDownList"
                            ContextKey="" PromptText="Please select" />
                    </li>
                    <li class="second">
                        <label runat="server" for="PaymentTypeDropDownList" id="PaymentTypeLabel">
                            Payment type:</label>
                        <asp:DropDownList ID="PaymentTypeDropDownList" runat="server" TabIndex="15">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PaymentTypeRequiredFieldValidator" ControlToValidate="PaymentTypeDropDownList"
                            Display="None" runat="server" ErrorMessage="Please choose a payment type."></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="PaymentTypeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="LeaveTypes" ServiceMethod="GetPaymentTypesByLeaveType" TargetControlID="PaymentTypeDropDownList"
                            ParentControlID="LeaveTypeDropDownList" ContextKey="" PromptText="Please select" />
                    </li>
                    <li>
                        <label runat="server" for="IsHalfDayCheckBox" id="IsHalfDayLabel">
                            Is half day:</label>
                        <asp:CheckBox ID="IsHalfDayCheckBox" runat="server" TabIndex="4" AutoPostBack="True"
                            OnCheckedChanged="IsHalfDayCheckBox_CheckedChanged"></asp:CheckBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="StartDateTextBox" id="StartDateLabel">
                            Start date:</label>
                        <asp:TextBox ID="StartDateTextBox" runat="server" TabIndex="999" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="StartDateRequiredFieldValidator" ControlToValidate="StartDateTextBox"
                            Display="None" runat="server" ErrorMessage="Please select the start date from calendar."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" ControlToValidate="StartDateTextBox"
                            Display="None" runat="server" ErrorMessage="The start date format must be {dd.MM.yyyy}."
                            ValidationExpression="((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                        <input type="image" id="StartDateImageButton" src="../../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" tabindex="6" />
                        <ajaxToolkit:CalendarExtender ID="StartDateCalendarExtender" runat="server" TargetControlID="StartDateTextBox"
                            CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="StartDateImageButton" />
                    </li>
                    <li>
                        <label runat="server" for="EndDateTextBox" id="EndDateLabel">
                            End date:</label>
                        <asp:TextBox ID="EndDateTextBox" runat="server" TabIndex="999" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <input type="image" id="EndDateImageButton" src="../../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" tabindex="6" />
                        <ajaxToolkit:CalendarExtender ID="EndDateCalendarExtender" runat="server" TargetControlID="EndDateTextBox"
                            CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="EndDateImageButton" />
                    </li>
                    <li class="second">
                         <label runat="server" for="AlternateEmployeeDropDownList" id="AlternateEmployeeLabel">
                            Alternate employee:</label>
                        <asp:DropDownList ID="AlternateEmployeeDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="AlternateEmployeeRequiredFieldValidator" ControlToValidate="AlternateEmployeeDropDownList"
                        Display="None" runat="server" ErrorMessage="Please select an alternate employee."
                        InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="AlternateEmployeeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="AbsenceEmployee" ServiceMethod="GetEmployeesByOrganisationalUnit" TargetControlID="AlternateEmployeeDropDownList"
                            PromptText="Please select" />
                    </li>
                </ul>
                <ul class="full">
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
    <asp:ConfirmButtonExtender ID="SetButtonConfirmButton" runat="server" TargetControlID="showbilancePopup"
        ConfirmText="Are you sure you want to click this?" DisplayModalPopupID="mpe" />
    <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
        <div class="confirm">
            <div class="confirmTextContainer">
                <b>
                    <asp:Label Text="Your leave bilance is: 8 days" ID="popupMessage" runat="server"
                        CssClass="confirmHeader"></asp:Label></b>
                <br />
            </div>
            <ul>
                <li>
                    <asp:Button ID="CloseButton" ToolTip="Close" CssClass="secondaryButton" runat="server"
                        Text="Close"></asp:Button>
                </li>
            </ul>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="mpe" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="CloseButton" PopupControlID="popup" TargetControlID="showbilancePopup">
    </asp:ModalPopupExtender>
</asp:Content>
