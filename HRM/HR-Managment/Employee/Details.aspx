<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Details.aspx.cs" Inherits="HRM.HR_Managment.Employee.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/HR.Employee.Details.js"></script>
    <script type="text/javascript" src="/HRM/Scripts/custom.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/custom.css" />


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
                <font color="#707070"><strong>
                    <asp:Label ID="EmployeeNameLabel" runat="server" Text="Gramoz Krasniqi"></asp:Label>
                </strong></font>
                <asp:HyperLink ID="EmployeeDismissHyperLink" runat="server" CssClass="fltrht butt">Dismiss</asp:HyperLink>
                <asp:HyperLink ID="EmployeeChangeJobDetailsHyperLink" runat="server" CssClass="fltrht butt menubutton">Job</asp:HyperLink>
                <div class="subMenu" style="display: none; margin: 0px !important; border-radius: 6px;">
                    <div class="cornup">
                    </div>
                    <ul>
                        <li>
                        <asp:HyperLink ID="ContractEmployeeHyperLink" runat="server" CssClass="" NavigateUrl="Contract.aspx">Contract employee</asp:HyperLink>
                        </li>
                        <li>
                        <asp:HyperLink ID="ChangeContractHyperLink" runat="server" CssClass="" NavigateUrl="ContractChange.aspx">Change contract</asp:HyperLink>
                        </li>
                        <li>
                        <asp:HyperLink ID="ExtendContractHyperLink" runat="server" CssClass="" NavigateUrl="ContractDetails.aspx">Extend contract</asp:HyperLink>
                        </li>
                    </ul>
                </div>
                <asp:HyperLink ID="EmployeeEditHyperLink" runat="server" CssClass="fltrht butt">Edit</asp:HyperLink>
                <em>
                    <asp:Label ID="JobTitleAndUnitLabel" runat="server" Text="Senior Assistant Programmer at Software Development"></asp:Label></em>
            </h2>
            <div class="fltlft" style="margin-bottom: 30px; width: 100%;">
                <asp:Image ID="empployeeImage" runat="server" ImageUrl="~/images/no-pic.jpg" CssClass="employeeImage employeeImageDetails fltlft" />
                <div class="fltlft" style="max-width: 700px;">
                    <ul id="triple">
                        <li><b>
                            <label runat="server" id="TextEmployeeNoLabel">
                                Employee no:</label>
                        </b><i>
                            <label runat="server" id="EmployeeNoLabel">
                                KPA662012</label></i> </li>
<%--                        <li><b>
                            <label runat="server" id="TextVacancyNoLabel">
                                Vacancy No:</label></b> <i>
                                    <label runat="server" id="VacancyNoLabel">
                                        726251</label></i></li>--%>
                        <li><b>
                            <label runat="server" id="TextPersonalNoLabel">
                                Personal No:</label>
                        </b><i>
                            <label runat="server" id="PersonalNoLabel">
                                23434341221</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextGenderLabel">
                                Gender:</label>
                        </b><i>
                            <label runat="server" id="GenderLabel">
                                Male</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextDateOfBirthLabel">
                                Date of birth:</label>
                        </b><i>
                            <label runat="server" id="DateOfBirthLabel">
                                02.08.2012</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextNationalityNoLabel">
                                Nationality:</label></b> <i>
                                    <label runat="server" id="NationalityNoLabel">
                                        Albanian</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextCountryLabel">
                                Country:</label>
                        </b><i>
                            <label runat="server" id="CountryLabel">
                                Kosovo</label></i></li>
                        <li><b>
                            <label runat="server" id="TextCityLabel">
                                City:</label>
                        </b><i>
                            <label runat="server" id="CityLabel">
                                Mitrovica</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextMobilePhoneLabel">
                                Mobile phone:</label>
                        </b><i>
                            <label runat="server" id="tMobilePhoneLabel">
                                045323323</label></i></li>
                        <li><b>
                            <label runat="server" id="TextWorkEmailLabel">
                                Work email:</label>
                        </b><i>
                            <label runat="server" id="WorkEmailLabel">
                                email@email.com</label></i></li>
                        <li><b>
                            <label runat="server" id="TextBankLabel">
                                Bank:</label>
                        </b><i>
                            <label runat="server" id="BankLabel">
                                TEB Bank</label></i></li>
                        <li><b>
                            <label runat="server" id="TextAccountNumberLabel">
                                Account number:</label>
                        </b><i>
                            <label runat="server" id="AccountNumberLabel">
                                0012547865454</label></i></li>
                    </ul>
                </div>
            </div>
            <div style="width: 100%; clear: both;">
                <h2 id="EducationTrainingTitle">
                    <font color="#707070"><strong>Educations and trainings</strong></font>
                    <asp:HyperLink ID="EducationTrainingShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                    <asp:HyperLink ID="EducationTrainingHyperLink" runat="server" CssClass="fltrht employeeLink employeeLinkWithoutEm">Manage</asp:HyperLink>
                </h2>
                <div id="EducationTrainingDiv" style="display: none;">
                    <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="EducationTrainingObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="DateFrom" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date from"
                                SortExpression="DateFrom" />
                            <asp:BoundField DataField="DateTo" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date to"
                                SortExpression="DateTo" />
                            <asp:BoundField DataField="OrganizationName" HeaderText="Organization name" SortExpression="OrganizationName" />
                            <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                            <asp:BoundField DataField="OrganizationContact" HeaderText="Organization contact"
                                SortExpression="OrganizationContact" />
                            <asp:BoundField DataField="QualificationAwarded" HeaderText="Qualification awarded"
                                SortExpression="QualificationAwarded" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                    No educations or trainings found for the current employee!</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="EducationTrainingObjectDataSource" runat="server" SelectMethod="ListByEmployeeId"
                        TypeName="DAL.Mapper.EducationTrainingMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div style="width: 100%; margin-top: 20px;">
                <h2 id="ExperienceTitle">
                    <font color="#707070"><strong>Experience</strong></font>
                    <asp:HyperLink ID="ExperienceShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                    <asp:HyperLink ID="ExperienceHyperLink" runat="server" CssClass="fltrht employeeLink employeeLinkWithoutEm">Manage</asp:HyperLink>
                </h2>
                <div id="ExperienceDiv" style="display: none;">
                    <asp:GridView ID="ExperienceGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="ExperienceObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="DateFrom" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date from"
                                SortExpression="DateFrom" />
                            <asp:BoundField DataField="DateTo" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date to"
                                SortExpression="DateTo" />
                            <asp:BoundField DataField="EmployeeName" HeaderText="Employee name" SortExpression="EmployeeName" />
                            <asp:BoundField DataField="EmployeeContact" HeaderText="Employee contact" SortExpression="EmployeeContact" />
                            <asp:BoundField DataField="PositionHeld" HeaderText="Position held" SortExpression="PositionHeld" />
                            <asp:BoundField DataField="BusinessType" HeaderText="Business type" SortExpression="BusinessType" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="ExperienceNoDataLabel" style="font-size: 15px;">
                                    No experiences found for the current employee.</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ExperienceObjectDataSource" runat="server" SelectMethod="ListByEmployeeId"
                        TypeName="DAL.Mapper.ExperienceMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div style="width: 100%; margin-top: 20px;">
                <h2 id="ActiveContractsTitle">
                    <font color="#707070"><strong>Employee active contracts: </strong></font>
                    <asp:HyperLink ID="EmployeeActiveContractsShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                    <asp:HyperLink ID="EmployeeActiveContractsManageHyperLink" runat="server" CssClass="fltrht employeeLink employeeLinkWithoutEm">Manage</asp:HyperLink>
                </h2>
                <div style="width: 100%; display: none;" id="ActiveContractsDiv">
                    <asp:GridView ID="EmployeeActiveContractsGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="EmployeeActiveContractsObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="ContractNumber" HeaderText="Contract number" SortExpression="ContractNumber">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContractTemplateTitle" HeaderText="Contract type" SortExpression="ContractTemplateTitle" />
                            <asp:BoundField DataField="OrganizationalUnitTitle" HeaderText="Organizational unit"
                                SortExpression="OrganizationalUnitTitle" />
                            <asp:BoundField DataField="JobTitle" HeaderText="Job title" SortExpression="JobTitle" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start date" SortExpression="StartDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End date" SortExpression="EndDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="ContractStatus" HeaderText="Contract status" SortExpression="ContractStatus" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                    No active contracts found for the current employee!</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="EmployeeActiveContractsObjectDataSource" runat="server"
                        SelectMethod="ListWithAdvancedFilter" TypeName="DAL.Mapper.ContractMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32"
                                ConvertEmptyStringToNull="False" />
                            <asp:Parameter Name="status" Type="Object" DefaultValue="Active" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div style="width: 100%; margin-top: 20px;">
                <h2>
                    <font color="#707070"><strong>Employee old contracts: </strong></font>
                    <asp:HyperLink ID="EmployeePasiveContractsShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm">Show</asp:HyperLink>
                    <asp:HyperLink ID="EmployeePasiveContractsManageHyperLink" runat="server" CssClass="fltrht employeeLink employeeLinkWithoutEm">Manage</asp:HyperLink>
                </h2>
                <div style="width: 100%; display: none;" id="PasiveContractsDiv">
                    <asp:GridView ID="EmployeeExpiredContractsGridView" runat="server" AutoGenerateColumns="False"
                        DataSourceID="EmployeeExpiredContractsObjectDataSource" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="ContractNumber" HeaderText="Contract number" SortExpression="ContractNumber">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContractTemplateTitle" HeaderText="Contract type" SortExpression="ContractTemplateTitle" />
                            <asp:BoundField DataField="OrganizationalUnitTitle" HeaderText="Organizational unit"
                                SortExpression="OrganizationalUnitTitle" />
                            <asp:BoundField DataField="JobTitle" HeaderText="Job title" SortExpression="JobTitle" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start date" SortExpression="StartDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End date" SortExpression="EndDate"
                                DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="ContractStatus" HeaderText="Contract status" SortExpression="ContractStatus" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                    No old contracts exists for the current employee!</label>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="EmployeeExpiredContractsObjectDataSource" runat="server"
                        SelectMethod="ListWithAdvancedFilter" TypeName="DAL.Mapper.ContractMapper">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32"
                                ConvertEmptyStringToNull="False" />
                            <asp:Parameter Name="status" Type="Object" DefaultValue="Pasive" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
