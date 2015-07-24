<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ContractList.aspx.cs" Inherits="HRM.HR_Managment.Employee.ContractList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM//Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Employee active contracts: </strong></font><em>This section
                    contains all active contracts of the emplyee: </em>
            </h2>
            <div style="width: 100%;">
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hyperDetails" runat="server" NavigateUrl='<%# "ContractDetails.aspx?ContractNumber=" + HttpUtility.UrlEncode(Eval("ContractNumber").ToString()) %>'
                                    Text="Details" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
            <h2>
                <font color="#707070"><strong>Employee old contracts: </strong></font><em>This section
                    contains all old contracts of the emplyee: </em>
            </h2>
            <div style="width: 100%;">
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hyperDetails" runat="server" NavigateUrl='<%# "ContractDetails.aspx?ContractNumber=" + HttpUtility.UrlEncode(Eval("ContractNumber").ToString()) %>'
                                    Text="Details" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                No expired contracts found for the current employee!</label>
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
</asp:Content>
