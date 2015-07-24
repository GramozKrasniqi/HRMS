<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ApplicationStrings.aspx.cs" Inherits="HRM.HR_Managment.Administration.Multilanguage.ApplicationStrings" %>

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
<%--    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>--%>
            <div id="wizard" style="margin: 0px; width: auto; height: auto;">
                <div class="page" style="width: 93%;">
                    <h2>
                        <font color="#707070"><strong>Application strings</strong></font>
                    </h2>
                    <div style="width: 100%;">
                        <asp:GridView ID="AppStringGridView" runat="server" DataSourceID="ApplicationStringSqlDataSource"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:ButtonField Text="Edit" ControlStyle-CssClass="confirmNeeded" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="NoLeaveTypeLabel" style="font-size: 15px;">
                                        No application strings were found!</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ApplicationStringSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRConnectionString %>"
                            SelectCommand="usp_ListAllApplicationStrings" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter Name="AppId" SessionField="ApplicationId" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
                            <div class="confirm">
                                <ul runat="server" id="TranslateLanguages">
                                    <li>
                                        <label runat="server" for="StringNameTextBox" id="StringNameLabel">
                                            String name:</label>
                                        <asp:TextBox ID="StringNameTextBox" TextMode="MultiLine" runat="server" ReadOnly="True"></asp:TextBox>
                                    </li>
                                    <li>
                                        <label runat="server" for="DefaultValueTextBox" id="DefaultValueLabel">
                                            Default value:</label>
                                        <asp:TextBox ID="DefaultValueTextBox" TextMode="MultiLine" runat="server" ReadOnly="True"></asp:TextBox>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <asp:Button ID="OkButton" ToolTip="Save" CssClass="secondaryButton fltrht" runat="server" Text="Proceed"></asp:Button>
                                    </li>
                                    <li>
                                        <asp:Button ID="CancelButton" CssClass="secondaryButton fltrht" ToolTip="Cancel"
                                            runat="server" Text="Cancel"></asp:Button>
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>
                        <asp:ModalPopupExtender BehaviorID="mpe" runat="server" BackgroundCssClass="modalBackground"
                            OkControlID="OkButton" OnOkScript="okClick();" PopupControlID="popup" CancelControlID="CancelButton"
                            OnCancelScript="cancelClick();" TargetControlID="dummy">
                        </asp:ModalPopupExtender>
                        <asp:Button ID="dummy" Style="display: none;" runat="server" />
                        <script type="text/javascript">
                            $('.confirmNeeded').attr('onclick', 'showConfirm(this);return false;');
                        </script>
                    </div>
                </div>
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
