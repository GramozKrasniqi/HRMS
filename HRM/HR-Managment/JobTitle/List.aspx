<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.JobTitle.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; width: auto; height: auto;">
                <div class="page" style="width: 93%;">
                    <h2>
                        <font color="#707070"><strong>Job titles list </strong></font>
                        <asp:HyperLink ID="NewJobTitleHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm"
                            NavigateUrl="~/HR-Managment/JobTitle/Add.aspx">Add new</asp:HyperLink>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="JobCodeTextBox" id="JobCodeLabel">
                                    Job code:</label>
                                <asp:TextBox ID="JobCodeTextBox" runat="server" TabIndex="15"> </asp:TextBox>
                            </li>
                            <li class="second">
                                <label runat="server" for="OrganizationalUnitDropDownList" id="OrganizationalUnitLabel">
                                    Organization unit:</label>
                                <asp:DropDownList ID="OrganizationalUnitDropDownList" runat="server" TabIndex="4">
                                </asp:DropDownList>
                                <ajaxToolkit:CascadingDropDown ID="OrganizationalUnitCascadingDropDown" runat="server"
                                    ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnits" ServiceMethod="GetOrganizationalUnits"
                                    TargetControlID="OrganizationalUnitDropDownList" PromptText="Please select" ContextKey="" />
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
                                        runat="server" Text="Clear" TabIndex="7" OnClientClick="document.location.href=document.location.href;"></asp:Button>
                                    <asp:Button ID="newEducationButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Education"
                                        runat="server" Text="Filter" TabIndex="8" PostBackUrl="~/HR-Managment/JobTitle/List.aspx"></asp:Button>
                                </li>
                            </li>
                        </ul>
                    </div>
                    <div style="width: 100%;">
                        <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="JobTitleObjectDataSource" EnableModelValidation="True" AllowPaging="True"
                            OnDataBound="EducationTrainingGridView_DataBound">
                            <Columns>
                                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                <asp:BoundField DataField="OrganisationalUnit" HeaderText="Organisational Unit" SortExpression="OrganisationalUnit" />
                                <asp:BoundField DataField="EmployeesCount" HeaderText="Employees Count" SortExpression="EmployeesCount" />
                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Code" DataNavigateUrlFormatString="Edit.aspx?JobCode={0}" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="NoEmployeeDataLabel" style="font-size: 15px;">
                                        No job titles were found!.</label>
                                </div>
                            </EmptyDataTemplate>
                            <PagerTemplate>
                                <table width="100%" id="pager" class="pager">
                                    <tr>
                                        <td align="right" width="100%">
                                            <asp:LinkButton ID="PreviousButton" runat="server" CommandName="Page" CommandArgument="Prev"
                                                Text="< Prev" />
                                            <asp:LinkButton ID="NextButton" runat="server" CommandName="Page" CommandArgument="Next"
                                                Text="Next >" />
                                            Page
                                            <asp:Label ID="PageNumberLabel" runat="server" />
                                            of
                                            <asp:Label ID="TotalPagesLabel" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                            <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="&gt;" PreviousPageText="&lt;" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="JobTitleObjectDataSource" runat="server" SelectMethod="ListByOrganisationalUnitId"
                            TypeName="DAL.Mapper.JobTitleMapper">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="OrganizationalUnitDropDownList" Name="organisationalUnitId"
                                    PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="JobCodeTextBox" Name="search" ConvertEmptyStringToNull="false"
                                    PropertyName="Text" Type="String" />
                                <asp:Parameter Name="status" Type="Object" DefaultValue="1" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
