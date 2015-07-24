<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Definition.AmandmentTemplate.List" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
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
                <font color="#707070"><strong>Amandaments templates list</strong></font>
                <asp:HyperLink ID="NewAmandamentTemplateHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm"
                    NavigateUrl="~/HR-Managment/Definition/AmandmentTemplate/PreData.aspx">Add new</asp:HyperLink>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="SearchTextBox" id="SearchLabel">
                            Search name:</label>
                        <asp:TextBox ID="SearchTextBox" runat="server" TabIndex="1"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="AmandamentStatusDropDownList" id="AmandamentStatusLabel">
                            Status:</label>
                        <asp:DropDownList ID="AmandamentStatusDropDownList" runat="server" TabIndex="6">
                        </asp:DropDownList>
                    </li>
                    <li>
                        <li class="second">
                            <label runat="server" id="empty">
                                &nbsp
                            </label>
                            <asp:Button ID="Button1" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear"></asp:Button>
                            <asp:Button ID="newEducationButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Education"
                                runat="server" Text="Filter"></asp:Button>
                        </li>
                    </li>
                </ul>
            </div>
            <div style="width: 100%;">
                <asp:GridView ID="AmandamentTemplateGridView" runat="server" AutoGenerateColumns="False"
                    DataSourceID="AmandamentTemplateObjectDataSource" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="AmandamentTemplateId" HeaderText="Id" SortExpression="AmandamentTemplateId" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="Status" HeaderText="Status">
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="AmandamentTemplateId" DataNavigateUrlFormatString="PreData.aspx?AmandamentTemplateId={0}&action=edit">
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="AmandamentTemplateId" DataNavigateUrlFormatString="Details.aspx?AmandamentTemplateId={0}">
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="AmandamentTemplateId" DataNavigateUrlFormatString="List.aspx?AmandamentTemplateId={0}&action=delete">
                            <ControlStyle CssClass="confirmNeeded" />
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="NoAmandamentsTemplateLabel" style="font-size: 15px;">
                                No amandaments templates found! Insert and it will be shown here.</label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="AmandamentTemplateObjectDataSource" runat="server" SelectMethod="ListWithAdvancedFilter"
                    TypeName="DAL.Mapper.AmandamentTemplateMapper">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="SearchTextBox" ConvertEmptyStringToNull="False"
                            Name="search" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="AmandamentStatusDropDownList" Name="status" PropertyName="SelectedValue"
                            Type="Object" />
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
</asp:Content>
