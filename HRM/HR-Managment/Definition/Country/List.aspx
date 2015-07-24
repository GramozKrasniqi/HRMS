<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Definition.Country.List" %>

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
                        <font color="#707070"><strong>Countries list</strong></font>
                        <asp:HyperLink ID="NewLeaveTypeHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm"
                            NavigateUrl="~/HR-Managment/Definition/Country/Add.aspx">Add new</asp:HyperLink>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="SearchTextBox" id="SearchLabel">
                                    Search name:</label>
                                <asp:TextBox ID="SearchTextBox" runat="server" TabIndex="1"></asp:TextBox>
                            </li>
                            <li class="second">
                                <label runat="server" id="empty">
                                    &nbsp
                                </label>
                                <asp:Button ID="Button1" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                    runat="server" Text="Clear" OnClientClick="document.location.href=document.location.href;">
                                </asp:Button>
                                <asp:Button ID="newListTypeFilterButton" ToolTip="Save" CssClass="secondaryButton"
                                    ValidationGroup="Education" runat="server" Text="Filter"></asp:Button>
                            </li>
                        </ul>
                    </div>
                    <div style="width: 100%;">
                        <asp:GridView ID="LeaveTypeGridView" runat="server" AutoGenerateColumns="False" DataSourceID="LeaveTypeObjectDataSource"
                            EnableModelValidation="True" AllowPaging="True" OnDataBound="LeaveTypeGridView_DataBound">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Edit.aspx?CountryId={0}">
                                    <HeaderStyle Width="50px" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField Text="Delete" ControlStyle-CssClass="confirmNeeded" DataNavigateUrlFields="Id"
                                    DataNavigateUrlFormatString="List.aspx?CountryId={0}&action=delete">
                                    <ControlStyle CssClass="confirmNeeded" />
                                    <HeaderStyle Width="50px" />
                                </asp:HyperLinkField>
                            </Columns>
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
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="NoLeaveTypeLabel" style="font-size: 15px;">
                                        No countries were found! Insert and it will be shown here.</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="LeaveTypeObjectDataSource" runat="server" SelectMethod="List"
                            TypeName="DAL.Mapper.CountryMapper">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="SearchTextBox" ConvertEmptyStringToNull="False"
                                    Name="search" PropertyName="Text" Type="String" />
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
                                <asp:Label Text="If you delete the record you cannot return it back." ID="Label1"
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
