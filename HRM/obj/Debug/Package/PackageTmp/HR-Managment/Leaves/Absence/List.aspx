<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Leaves.Absence.List" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>Abseneces list </strong></font><em>Please enter search
                    criteria and press filter: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="DateFromTextBox" id="DateFromLabel">
                            Date from:</label>
                        <asp:TextBox ID="DateFromTextBox" runat="server" TabIndex="999" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="DateFromRegularExpressionValidator" ControlToValidate="DateFromTextBox"
                            Display="None" runat="server" ErrorMessage="The date format must be {dd.MM.yyyy}."
                            ValidationExpression="((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                        <input type="image" id="DateFromImageButton" src="../../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" tabindex="6" />
                        <ajaxToolkit:CalendarExtender ID="DateFromCalendarExtender" runat="server" TargetControlID="DateFromTextBox"
                            CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="DateFromImageButton" />
                    </li>
                    <li class="second">
                        <label runat="server" for="DateToTextBox" id="DateToLabel">
                            Date to:</label>
                        <asp:TextBox ID="DateToTextBox" runat="server" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="DateToRegularExpressionValidator" ControlToValidate="DateToTextBox"
                            ValidationGroup="Education" Display="None" runat="server" ErrorMessage="The date format must be {dd.MM.yyyy}."
                            ValidationExpression="((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                        <input type="image" id="DateToImageButton" src="../../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" tabindex="2" />
                        <ajaxToolkit:CalendarExtender ID="DateToCalendarExtender" runat="server"
                            TargetControlID="DateToTextBox" CssClass="cal_Theme1" Format="dd.MM.yyyy"
                            PopupButtonID="DateToImageButton" />
                    </li>
                    <li>
                        <label runat="server" id="Label1">
                        </label>
                        &nbsp </li>
                    <li>
                        <li class="second">
                            <label runat="server" id="empty">
                                &nbsp
                            </label>
                            <asp:Button ID="Button1" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear" TabIndex="7"></asp:Button>
                            <asp:Button ID="newEducationButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Education"
                                runat="server" Text="Filter" TabIndex="8"></asp:Button>
                        </li>
                    </li>
                </ul>
            </div>
            <div style="width: 100%;">
                <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                    DataSourceID="EducationTrainingObjectDataSource" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:dd.MM.yyyy}" />
                        <asp:BoundField DataField="AbsenceEmployee" HeaderText="Absence employee" SortExpression="AbsenceEmployee" />
                        <asp:BoundField DataField="Manager" HeaderText="Manager of employee" SortExpression="Manager" />
                        <asp:HyperLinkField Text="Cancel" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="List.aspx?action=Cancel&AbsenceId={0}" />
                        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Details.aspx?AbsenceId={0}" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="NoEmployeeDataLabel" style="font-size: 15px;">
                                No reported absences were found!.</label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="EducationTrainingObjectDataSource" runat="server" SelectMethod="ListWithAdvancedFilter"
                    TypeName="DAL.Mapper.ReportedAbsenceMapper" 
                    onselecting="EducationTrainingObjectDataSource_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="dateFrom" Type="DateTime" />
                        <asp:Parameter Name="dateTo" Type="DateTime"  />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
