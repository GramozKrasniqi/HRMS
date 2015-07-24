<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PersonalAbsences.aspx.cs" Inherits="HRM.HR_Managment.Leaves.Absence.PersonalAbsences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/HR.Employee.Details.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script type="text/javascript">

        $(document).ready(function () {
            bindLinks();
        });
    </script>
    <style type="text/css">
        #EducationTrainingDiv
        {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>
                    <asp:Label ID="EmployeeNameLabel" runat="server" Text="Leave list"></asp:Label>
                </strong></font><em>
                    <asp:Label ID="JobTitleAndUnitLabel" runat="server" Text="Shows personal leaves and approved leaves by you for others."></asp:Label></em>
            </h2>
            <div style="width: 100%; clear: both;">
                <h2 id="EducationTrainingTitle">
                    <font color="#707070"><strong>My personal leaves</strong></font>
                    <asp:HyperLink ID="EducationTrainingShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                </h2>
                <div id="EducationTrainingDiv" style="display: none;">
                    <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="EducationTrainingObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave type" SortExpression="LeaveType" />
                            <asp:BoundField DataField="RequestDate" HeaderText="Request date" SortExpression="RequestDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start date" SortExpression="StartDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End date" SortExpression="EndDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:CheckBoxField DataField="IsHalfDay" HeaderText="Is half day" SortExpression="IsHalfDay" />
                            <asp:BoundField DataField="LeaveStatus" HeaderText="Status" SortExpression="LeaveStatus" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                    You have not yet requested any personal leaves!</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="EducationTrainingObjectDataSource" runat="server" SelectMethod="ListWithAdvancedFilter"
                        TypeName="DAL.Mapper.LeaveRequestMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32" />
                            <asp:QueryStringParameter Name="status" DefaultValue="" ConvertEmptyStringToNull="true"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div style="width: 100%; margin-top: 20px;">
                <h2 id="ExperienceTitle">
                    <font color="#707070"><strong>Leaves that i approved</strong></font>
                    <asp:HyperLink ID="ExperienceShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                </h2>
                <div id="ExperienceDiv" style="display: none;">
                    <asp:GridView ID="ExperienceGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="ExperienceObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave type" SortExpression="LeaveType" />
                            <asp:BoundField DataField="RequestDate" HeaderText="Request date" SortExpression="RequestDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start date" SortExpression="StartDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End date" SortExpression="EndDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:CheckBoxField DataField="IsHalfDay" HeaderText="Is half day" SortExpression="IsHalfDay" />
                            <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee" />
                            <asp:BoundField DataField="LeaveStatus" HeaderText="Status" SortExpression="LeaveStatus" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="ExperienceNoDataLabel" style="font-size: 15px;">
                                    You havent approved any leaves yet!</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ExperienceObjectDataSource" runat="server" SelectMethod="ListLeaveRequestsApprovedByEmployee"
                        TypeName="DAL.Mapper.LeaveRequestMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="employeeId" Type="Int32" />
                            <asp:Parameter Name="status" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
