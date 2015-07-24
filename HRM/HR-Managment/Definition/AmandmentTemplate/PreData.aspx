<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PreData.aspx.cs" Inherits="HRM.HR_Managment.Definition.AmandmentTemplate.PreData" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/RequiredFieldValidatorForCheckBoxList.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; height: auto; width: auto;">
                <div class="page" style="width: 93%;">
                    <div id="dialog-form">
                    </div>
                    <h2>
                        <font color="#707070"><strong>Select languages: </strong></font><em>Please select languages
                            to be used by this amandment template. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <asp:CheckBoxList ID="ContractsCheckBoxList" runat="server" CssClass="chkb" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" DataSourceID="ContractObjectDataSource" DataTextField="Title"
                            DataValueField="Id" Font-Size="Medium" OnPreRender="ContractsCheckBoxList_PreRender">
                        </asp:CheckBoxList>
                        <asp:CustomValidator ID="CustomValidator1" Display="None" runat="server" ErrorMessage="Please check at least one language contract."
                            InitialValue="" ClientValidationFunction="ensureChecked"></asp:CustomValidator>
                        <asp:ObjectDataSource ID="ContractObjectDataSource" runat="server" SelectMethod="List"
                            TypeName="DAL.Mapper.LanguageMapper">
                            <SelectParameters>
                                <asp:Parameter ConvertEmptyStringToNull="False" DefaultValue="" Name="search" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <ul class="clearfix">
                        <li>
                            <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                                TabIndex="8" OnClick="ProceedButton_Click"></asp:Button>
                            <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                                TabIndex="7" CausesValidation="False" PostBackUrl="List.aspx"></asp:Button></li>
                    </ul>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
