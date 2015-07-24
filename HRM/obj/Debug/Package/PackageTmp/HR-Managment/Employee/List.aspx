<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
EnableEventValidation="false" CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Employee.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>Employees list </strong></font><em>Please enter employee
                    search criteria and press filter: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="FirstOrLastNameTextBox" id="FirstOrLastNameLabel">
                            Search name:</label>
                        <asp:TextBox ID="FirstOrLastNameTextBox" runat="server" TabIndex="1"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="EmployeeNoTextBox" id="EmployeeNoLabel">
                            Employee no:</label>
                        <asp:TextBox ID="EmployeeNoTextBox" runat="server" TabIndex="2"></asp:TextBox>
                    </li>
                    <li>
                        <label runat="server" for="OrganisationalUnitDropDownList" id="OrganisationalUnitLabel">
                            Organizational unit:</label>
                        <asp:DropDownList ID="OrganisationalUnitDropDownList" runat="server" TabIndex="3">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="OrganisationalUnitCascadingDropDown" runat="server"
                            ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnit" ServiceMethod="GetOrganizationalUnits"
                            TargetControlID="OrganisationalUnitDropDownList" PromptText="Please select" ContextKey=""/>
                    </li>
                    <li class="second">
                        <label runat="server" for="JobDownList" id="JobLabel">
                            Job:</label>
                        <asp:DropDownList ID="JobDetailsDropDownList" runat="server" TabIndex="4">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="JobDetailsCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="JobTitle" ServiceMethod="GetJobTitlesByOrganisationalUnit" TargetControlID="JobDetailsDropDownList"
                            PromptText="Please select" ParentControlID="OrganisationalUnitDropDownList" ContextKey="" />
                    </li>
                    <li>
                        <label runat="server" for="PersonalNumberTextBox" id="PersonalNumberLabel">
                            Personal number:</label>
                        <asp:TextBox ID="PersonalNumberTextBox" runat="server" TabIndex="5"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="EmployeeStatusDropDownList" id="EmployeeStatusLabel">
                            Status:</label>
                        <asp:DropDownList ID="EmployeeStatusDropDownList" runat="server" TabIndex="6">
                        </asp:DropDownList>
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
                        <asp:BoundField DataField="EmployeeNo" HeaderText="Employee no" SortExpression="EmployeeNo" />
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                        <asp:BoundField DataField="PersonalNumber" HeaderText="Personal number" SortExpression="PersonalNumber" />
                        <asp:BoundField DataField="OrganizationalUnit" 
                            HeaderText="Organizational unit" 
                            SortExpression="OrganizationalUnit" />
                        <asp:BoundField DataField="Job" HeaderText="Job" 
                            SortExpression="Job" />
                        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Details.aspx?EmployeeId={0}" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="NoEmployeeDataLabel" style="font-size: 15px;">
                                No employees found!.</label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="EducationTrainingObjectDataSource" runat="server" SelectMethod="ListWithAdvancedFilter"
                    TypeName="DAL.Mapper.EmployeeMapper">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="EmployeeNoTextBox" ConvertEmptyStringToNull="False"
                            Name="employeeNo" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="FirstOrLastNameTextBox" ConvertEmptyStringToNull="False"
                            Name="searchName" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="PersonalNumberTextBox" ConvertEmptyStringToNull="False"
                            Name="personalNumber" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="OrganisationalUnitDropDownList" Name="organizationalUnitId"
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="JobDetailsDropDownList" ConvertEmptyStringToNull="False"
                            Name="jobCode" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="EmployeeStatusDropDownList" Name="status" PropertyName="SelectedValue"
                            Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
