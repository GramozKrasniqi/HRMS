<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="HRM.HR_Managment.Administration.Role.List" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <style type="text/css">
        ul#double li
        {
            height: 30px;
        }
        ul#double label
        {
            margin-top: 5px;
        }
        ul#double input[type="text"]
        {
            min-width: 100px;
            width: 185px !important;
        }
        
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
            border: solid1px#c0c0c0;
            background: #f0f0f0;
            padding: 0px10px10px10px;
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
                <font color="#707070"><strong>Role list </strong></font><asp:HyperLink ID="NewLeaveTypeHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink employeeLinkWithoutEm" NavigateUrl="~/HR-Managment/Administration/Role/Add.aspx">Add new</asp:HyperLink>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="UserNameTextBox" id="UserNameLabel">
                            Search name:</label>
                        <asp:TextBox ID="UserNameTextBox" runat="server" TabIndex="1"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" id="empty">
                            &nbsp
                        </label>
                        <asp:Button ID="Button1" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                            runat="server" Text="Clear" TabIndex="7"></asp:Button>
                        <asp:Button ID="newEducationButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Education"
                            runat="server" Text="Filter" TabIndex="8"></asp:Button>
                    </li>
                </ul>
            </div>
            <div style="width: 100%;">
                <asp:GridView ID="RoleGridView" runat="server" AutoGenerateColumns="False" DataSourceID="RoleObjectDataSource"
                    EnableModelValidation="True" onrowcommand="RoleGridView_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id,Title" DataNavigateUrlFormatString="Edit.aspx?RoleId={0}&RoleTitle={1}">
                            <ItemStyle Width="53px" />
                        </asp:HyperLinkField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="SetButton" runat="server" CommandName="DeleteRole" Text="Delete" CommandArgument='<%#Eval("Id")%>' />
                                <asp:ConfirmButtonExtender ID="SetButtonConfirmButton" runat="server" TargetControlID="SetButton"
                                    ConfirmText="Are you sure you want to click this?" DisplayModalPopupID="mpe" />
                                <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
                                    <div class="confirm">
                                        <div class="confirmTextContainer">
                                            <b>
                                                <asp:Label Text="Are you sure you want to delete this role?" ID="popupMessage" runat="server"
                                                    CssClass="confirmHeader"></asp:Label></b>
                                            <br />
                                            <%--<i>
                                                <asp:Label Text="If you change the company policy information please be advised that you must also change the current contracts of your employees. The system will proceed with the changes and redirect you to change the contracts."
                                                    ID="Label1" runat="server" CssClass="confirmBody"></asp:Label></i>--%>
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
                                <asp:ModalPopupExtender ID="mpe" runat="server" BackgroundCssClass="modalBackground"
                                    CancelControlID="CancelButton" OkControlID="OkButton" PopupControlID="popup"
                                    TargetControlID="SetButton">
                                </asp:ModalPopupExtender>
                            </ItemTemplate>
                            <ItemStyle width="53px" />
                        </asp:TemplateField>
                        <%--<asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id, Title" DataNavigateUrlFormatString="Delete.aspx?RoleId={0}&RoleTitle={1}">
                            <ItemStyle Width="53px" />--%>
                        <%--</asp:HyperLinkField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="NoRolesDataLabel" style="font-size: 15px;">
                                No roles found!.</label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="RoleObjectDataSource" runat="server" SelectMethod="List"
                    TypeName="DAL.Mapper.RoleMapper" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="UserNameTextBox" ConvertEmptyStringToNull="False"
                            Name="search" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
