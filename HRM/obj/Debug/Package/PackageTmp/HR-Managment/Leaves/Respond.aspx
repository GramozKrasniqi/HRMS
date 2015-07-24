<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Respond.aspx.cs" Inherits="HRM.HR_Managment.Leaves.Respond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>
                    <asp:Label ID="EmployeeNameLabel" runat="server" Text="Gramoz Krasniqi"></asp:Label>
                </strong></font><em>
                    <asp:Label ID="message" runat="server" Text="is requesting for you to approve his leave"></asp:Label></em>
            </h2>
            <h2 style="margin-top: 10px; margin-bottom: 0px; border-bottom: none;">
                <font color="#707070"><strong>Leave request details: </strong></font>
            </h2>
            <div style="margin-bottom: 15px;" class="fltlft">
                <ul id="triple">
                    <li><b>
                        <label runat="server" id="TextLeaveType">
                            Leave type:</label>
                    </b><i>
                        <label runat="server" id="LeaveTypeLabel">
                            Sick leave</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextRequestDateLabel">
                            Request date:</label>
                    </b><i>
                        <label runat="server" id="RequestDateLabel">
                            02.03.2013</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextStartDateLabel">
                            Start date:</label>
                    </b><i>
                        <label runat="server" id="StartDateLabel">
                            02.03.2013</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextIsHalfDayLabel">
                            Is half day:</label></b> <i>
                                <label runat="server" id="IsHalfDayLabel">
                                    No</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextEndDateLabel">
                            End date:</label>
                    </b><i>
                        <label runat="server" id="EndDateLabel">
                            06.03.2013</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextCalculatedNumberOfDaysLabel">
                            Leave days:</label>
                    </b><i>
                        <label runat="server" id="CalculatedNumberOfDaysLabel">
                            3</label></i></li>
                    <li><b>
                        <label runat="server" id="TextNotesLabel">
                            Notes:</label>
                    </b><i>
                        <label runat="server" id="NotesLabel">
                            Head aches</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextAlternatePersonLabel">
                            Alternate person:</label>
                    </b><i>
                        <label runat="server" id="AlternatePersonLabel">
                            Shkelqim Sina</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextManagerLabel">
                            Manager:</label>
                    </b><i>
                        <label runat="server" id="ManagerLabel">
                            Vehbi Neziri</label></i> </li>
                </ul>
            </div>
            <ul class="clearfix">
                <li>
                    <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Approve »"
                        OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                    <asp:Button ID="DeclineButton" CssClass="right login_btn" runat="server" Text="Decline"
                        TabIndex="18" onclick="DeclineButton_Click"></asp:Button>
                    <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                        TabIndex="17"></asp:Button></li>
            </ul>
        </div>
    </div>
</asp:Content>
