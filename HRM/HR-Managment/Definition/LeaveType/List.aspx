<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Definition.LeaveType.List" %>
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
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>Leave types list</strong></font>
                <asp:HyperLink ID="NewLeaveTypeHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm" NavigateUrl="~/HR-Managment/Definition/LeaveType/Add.aspx">Add new</asp:HyperLink>
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
                                runat="server" Text="Clear"></asp:Button>
                            <asp:Button ID="newListTypeFilterButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Education"
                                runat="server" Text="Filter"></asp:Button>
                    </li>
                </ul>
            </div>
            <div style="width: 100%;">
                <asp:GridView ID="LeaveTypeGridView" runat="server" AutoGenerateColumns="False"
                    DataSourceID="LeaveTypeObjectDataSource" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="Status" HeaderText="Status">
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Edit.aspx?LeaveTypeId={0}">
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Details.aspx?LeaveTypeId={0}">
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                         <asp:HyperLinkField  Text="Delete" ControlStyle-CssClass="confirmNeeded" DataNavigateUrlFields="Id"  DataNavigateUrlFormatString="List.aspx?LeaveTypeId={0}&action=delete">
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="NoLeaveTypeLabel" style="font-size: 15px;">
                                No leave types found! Insert and it will be shown here.</label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="LeaveTypeObjectDataSource" runat="server" SelectMethod="List"
                    TypeName="DAL.Mapper.LeaveTypeMapper" DeleteMethod="DeleteLeaveType">
                    <DeleteParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="Id" QueryStringField="LeaveTypeId" />
                    </DeleteParameters>
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
                        <asp:Label Text="If you delete the record you cannot return it back."
                            ID="Label1" runat="server" CssClass="confirmBody"></asp:Label></i>
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
        <asp:ModalPopupExtender BehaviorID="mpe" runat="server" BackgroundCssClass="modalBackground"
            OkControlID="OkButton" OnOkScript="okClick();" PopupControlID="popup" 
            CancelControlID="CancelButton" OnCancelScript="cancelClick();" 
            TargetControlID="dummy">
        </asp:ModalPopupExtender>
        <asp:Button ID="dummy" style="display:none;" runat="server" />

        <script type="text/javascript">
            $('.confirmNeeded').attr('onclick', 'showConfirm(this);return false;');
        </script>

    </div>
</asp:Content>
