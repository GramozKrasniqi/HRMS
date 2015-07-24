<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="HRM.HR_Managment.Definition.Holiday.Edit" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <script type="text/javascript" src="/HRM/Scripts/QueryString.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script type="text/javascript" src="/HRM/Scripts/ConfirmNeeded.js"></script>
    <style type="text/css">
        .modalBackground {
            width: 100%;
            height: 100%;
            background-color: #EBEBEB;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .ModalWindow {
            border: solid 1px #c0c0c0;
            background: #f0f0f0;
            padding: 0px;
            position: absolute;
            top: -1000px;
            text-align: center;
            vertical-align: middle;
        }

        .confirm {
            background-color: White;
            padding: 10px;
            width: 370px;
        }

        .confirmTextContainer {
            margin-bottom: 15px;
        }

        .confirm ul li {
            float: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="upPanel">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; height: auto; width: auto;">
                <div class="page" style="width: 93%;">
                    <div id="dialog-form">
                    </div>
                    <h2>
                        <font color="#707070"><strong>Holiday Group & Holiday: </strong></font><em>Please
                    enter holiday information: </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="TitleTextBox" id="TitleLabel">
                                    Title:</label>
                                <asp:TextBox ID="TitleTextBox" runat="server" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" ControlToValidate="TitleTextBox"
                                    Display="None" ValidationGroup="Form1" runat="server" ErrorMessage="Please enter title."></asp:RequiredFieldValidator>
                            </li>

                            <li class="second">
                                <label runat="server" for="DescriptionTextBox" id="DescriptionLabel">
                                    Description:</label>
                                <asp:TextBox ID="DescriptionTextBox" TextMode="MultiLine" runat="server" TabIndex="2"></asp:TextBox>
                            </li>
                            <li />
                            <li class="second">
                                <label runat="server" id="Label1">
                                    &nbsp
                                </label>
                                <asp:Button ID="ClearFirstFormButton" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                    runat="server" Text="Clear"></asp:Button>
                                <asp:Button ID="SaveLeaveType" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Form1"
                                    runat="server" Text="Save" OnClick="SaveLeaveType_Click"></asp:Button>

                            </li>
                            <li style="width: 100%">
                                <h2>&nbsp;</h2>
                            </li>
                            <li>

                                <label runat="server" for="HolidayTitleTextBox" id="HolidayTitleLabel">
                                    Holiday title:</label>
                                <asp:TextBox ID="HolidayTitleTextBox" runat="server" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="HolidayTitleRequiredFieldValidator" ControlToValidate="HolidayTitleTextBox"
                                    Display="None" ValidationGroup="Form2" runat="server" ErrorMessage="Please enter holiday title."></asp:RequiredFieldValidator>
                            </li>

                            <li class="second">
                                <label runat="server" for="StartDateTextBox" id="StartDateLabel">
                                    Start date:</label>
                                <asp:TextBox ID="StartDateTextBox" runat="server" TabIndex="999" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="StartDateRequiredFieldValidator" ControlToValidate="StartDateTextBox"
                                    Display="None" runat="server" ErrorMessage="Please select the start date from calendar." ValidationGroup="Form2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" ControlToValidate="StartDateTextBox"
                                    Display="None" runat="server" ErrorMessage="The start date format must be {dd.MM.yyyy}." ValidationGroup="Form2"
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
                                <label runat="server" id="empty">
                                    &nbsp
                                </label>
                                <asp:Button ID="ClearButton" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                    runat="server" Text="Clear"></asp:Button>
                                <asp:Button ID="AddPaymentTypeButton" ToolTip="Add" CssClass="secondaryButton" ValidationGroup="Form2"
                                    runat="server" Text="Add" OnClick="AddPaymentTypeButton_Click"></asp:Button>
                            </li>
                        </ul>
                    </div>
                    <div style="width: 100%">
                        <asp:GridView ID="LeaveTypeGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="LeaveTypeObjectDataSource" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" DataFormatString="{0:dd.MM.yyyy}" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="NoLeaveTypeLabel" style="font-size: 15px;">
                                        No payment types found! Insert and it will be shown here.</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <asp:ObjectDataSource ID="LeaveTypeObjectDataSource" runat="server" SelectMethod="List"
                        TypeName="DAL.Mapper.HolidayMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="HolidayGroupId" QueryStringField="HolidayGroupId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
                    <div class="confirm">
                        <div class="confirmTextContainer">
                            <b>
                                <asp:Label Text="Are you sure you want to make the data inactive?" ID="popupMessage" runat="server"
                                    CssClass="confirmHeader"></asp:Label></b>
                            <br />
                            <i>
                                <asp:Label Text="If you make this record inactive this will not be shown on other forms."
                                    ID="Label2" runat="server" CssClass="confirmBody"></asp:Label></i>
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
                <asp:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server" BackgroundCssClass="modalBackground"
                    OkControlID="OkButton" OnOkScript="okClick();" PopupControlID="popup"
                    CancelControlID="CancelButton" OnCancelScript="cancelClick();"
                    TargetControlID="dummy">
                </asp:ModalPopupExtender>
                <asp:Button ID="dummy" Style="display: none;" runat="server" />

                <script type="text/javascript">
                    $('.confirmNeeded').attr('onclick', 'showConfirm(this);return false;');
                </script>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
