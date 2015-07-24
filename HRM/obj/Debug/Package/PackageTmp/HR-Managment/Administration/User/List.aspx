<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Administration.User.List"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/HR.Employee.Details.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script type="text/javascript">

        $(document).ready(function () {
            bindLinks();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>Users list </strong></font>
                <asp:HyperLink ID="EducationTrainingShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
            </h2>
            <div id="EducationTrainingDiv" style="display: none;">
                <div style="margin-bottom: 15px;">
                    <ul id="double">
                        <li>
                            <label runat="server" for="UserNameTextBox" id="UserNameLabel">
                                Search name:</label>
                            <asp:TextBox ID="UserNameTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        </li>
                        <li class="second">
                            <label runat="server" for="RoleDropDownList" id="RoleLabel">
                                Role :</label>
                            <asp:DropDownList ID="RoleDropDownList" runat="server" TabIndex="3">
                            </asp:DropDownList>
                            <ajaxToolkit:CascadingDropDown ID="RoleCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                Category="Role" ServiceMethod="GetRoles" TargetControlID="RoleDropDownList" PromptText="Please select" />
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
                        DataSourceID="RoleObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId" />
                            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="Employee name" SortExpression="EmployeeFullName" />
                            <asp:HyperLinkField Text="Manage" DataNavigateUrlFields="EmployeeId" DataNavigateUrlFormatString="ResetPassword.aspx?EmployeeId={0}">
                            </asp:HyperLinkField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="NoEmployeeDataLabel" style="font-size: 15px;">
                                    No users found!.</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="RoleObjectDataSource" runat="server" SelectMethod="ListByRoleId"
                        TypeName="DAL.Mapper.UserMapper" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="UserNameTextBox" ConvertEmptyStringToNull="False"
                                Name="search" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="RoleDropDownList" Name="roleId" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <%--===============================================Employees without username===============================--%>
            <div style="width: 100%; margin-top: 20px;">
                <h2 id="ExperienceTitle">
                    <font color="#707070"><strong>Employees without username</strong></font>
                    <asp:HyperLink ID="ExperienceShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                </h2>
                <div id="ExperienceDiv" style="display: none;">
                    <asp:GridView ID="ExperienceGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="ExperienceObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="EmployeeNo" HeaderText="Employee no" SortExpression="EmployeeNo" />
                            <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                            <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                            <asp:BoundField DataField="PersonalNumber" HeaderText="Personal number" SortExpression="PersonalNumber" />
                            <asp:BoundField DataField="OrganizationalUnit" HeaderText="Organizational unit" SortExpression="OrganizationalUnit" />
                            <asp:BoundField DataField="Job" HeaderText="Job" SortExpression="Job" />
                            <asp:HyperLinkField Text="Link to user" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="LinkToUser.aspx?EmployeeId={0}" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="ExperienceNoDataLabel" style="font-size: 15px;">
                                    Ther is no employee that does not have a user account!</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ExperienceObjectDataSource" runat="server" SelectMethod="ListEmployeesWithoutUsername"
                        TypeName="DAL.Mapper.EmployeeMapper">
                        <SelectParameters>
                            <asp:Parameter Name="status" Type="Object" DefaultValue="1" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
