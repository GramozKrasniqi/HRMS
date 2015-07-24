<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.OrganizationalUnit.List"
    EnableEventValidation="false" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script type="text/javascript" src="/HRM/Scripts/ConfirmNeeded.js"></script>
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
            border: solid 1px #c0c0c0;
            background: #f0f0f0;
            padding: 0px;
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
        
        .confirm ul li
        {
            float: none !important;
        }
        
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; width: auto; height: auto;">
                <div class="page" style="width: 93%;">
                    <h2>
                        <font color="#707070"><strong>Organizational units list </strong></font>
                        <asp:HyperLink ID="NewJobTitleHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm"
                            NavigateUrl="~/HR-Managment/OrganizationalUnit/Add.aspx">Add new</asp:HyperLink>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="TitleTextBox" id="TitleLabel">
                                    Title:</label>
                                <asp:TextBox ID="TitleTextBox" runat="server" TabIndex="15">
                                </asp:TextBox>
                            </li>
                            <li class="second">
                                <label runat="server" for="OrganizationalUnitGroupDropDownList" id="OrganizationalUnitGroupLabel">
                                    Unit group:</label>
                                <asp:DropDownList ID="OrganizationalUnitGroupDropDownList" runat="server" TabIndex="4">
                                </asp:DropDownList>
                                <ajaxToolkit:CascadingDropDown ID="OrganizationalUnitGroupCascadingDropDown" runat="server"
                                    ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnitsGroups" ServiceMethod="GetOrganizationalUnitGroups"
                                    TargetControlID="OrganizationalUnitGroupDropDownList" PromptText="Please select"
                                    ContextKey="" />
                            </li>
                            <li>
                                <label runat="server" for="ParentDropDownList" id="ParentLabel">
                                    Parent unit:</label>
                                <asp:DropDownList ID="ParentDropDownList" runat="server" TabIndex="4">
                                </asp:DropDownList>
                                <ajaxToolkit:CascadingDropDown ID="ParentCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                    Category="OrganizationalUnit" ServiceMethod="GetOrganizationalUnits" TargetControlID="ParentDropDownList"
                                    PromptText="Please select" ContextKey="" />
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
                                        runat="server" Text="Filter" TabIndex="8" PostBackUrl="~/HR-Managment/OrganizationalUnit/List.aspx">
                                    </asp:Button>
                                </li>
                            </li>
                        </ul>
                    </div>
                    <div style="width: 100%;">
                        <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="JobTitleObjectDataSource" EnableModelValidation="True" AllowPaging="True"
                            CssClass="dataGrid" OnDataBound="EducationTrainingGridView_DataBound">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                <asp:BoundField DataField="OrganizationaUnitGroup" HeaderText="Unit Group" SortExpression="OrganizationaUnitGroup" />
                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Edit.aspx?orgUnitId={0}" />
                                <asp:HyperLinkField Text="Delete" ControlStyle-CssClass="confirmNeeded" DataNavigateUrlFields="Id"
                                    DataNavigateUrlFormatString="List.aspx?OrganizationalUnitId={0}&action=delete">
                                    <ControlStyle CssClass="confirmNeeded" />
                                    <HeaderStyle Width="50px" />
                                </asp:HyperLinkField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="NoEmployeeDataLabel" style="font-size: 15px;">
                                        No organizational units were found!.</label>
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
                        <asp:ObjectDataSource ID="JobTitleObjectDataSource" runat="server" SelectMethod="ListWithAdvancedFilter"
                            TypeName="DAL.Mapper.OrganizationalUnitMapper">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TitleTextBox" Name="title" PropertyName="Text" Type="String"
                                    ConvertEmptyStringToNull="false" />
                                <asp:ControlParameter ControlID="ParentDropDownList" Name="parentOrgId" PropertyName="SelectedValue"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="OrganizationalUnitGroupDropDownList" Name="orgUnitGroup"
                                    PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
                <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
                    <div class="confirm">
                        <div class="confirmTextContainer">
                            <b>
                                <asp:Label Text="Are you sure you want to delete the data?" ID="popupMessage" runat="server"
                                    CssClass="confirmHeader"></asp:Label></b>
                            <br />
                            <i>
                                <asp:Label Text="If you delete the record you cannot return it back." ID="Label2"
                                    runat="server" CssClass="confirmBody"></asp:Label></i>
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
                <asp:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
                    BackgroundCssClass="modalBackground" OkControlID="OkButton" OnOkScript="okClick();"
                    PopupControlID="popup" CancelControlID="CancelButton" OnCancelScript="cancelClick();"
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
