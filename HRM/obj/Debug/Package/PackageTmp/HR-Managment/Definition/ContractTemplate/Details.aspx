<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Details.aspx.cs" Inherits="HRM.HR_Managment.Definition.ContractTemplate.Details" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;" id="contractVersion" runat="server">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Contract template details </strong></font><em>This shows
                    the details of contract template: </em>
            </h2>
            <div style="margin-bottom: 30px;">
                <ul id="double2">
                    <li><b>
                        <label runat="server" id="TextContractTemplateTitleLabel">
                            Template title:</label></b> <i>
                                <label runat="server" id="ContractTemplateTitleLabel">
                                    Template title:</label></i> </li>
                    <li class="second"><b>
                        <label runat="server" id="TextContractPreffixLabel">
                            Contract preffix:</label></b> <i>
                                <label runat="server" id="ContractPreffixLabel">
                                    Contract preffix:</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextLeaveDaysPerMonthLabel">
                            Leave days/month:</label></b> <i>
                                <label runat="server" id="LeaveDaysPerMonthLabel">
                                    Template title:</label></i> </li>
                    <li class="second"><b>
                        <label runat="server" id="TextExpLeaveDaysPerYearLabel">
                            Exp. leave days/year:</label></b> <i>
                                <label runat="server" id="ExpLeaveDaysPerYearLabel">
                                    Contract preffix:</label></i> </li>
                    <li><b>
                        <label runat="server" id="TextDaysCarriedForwardLabel">
                            Days carried forward:</label></b> <i>
                                <label runat="server" id="DaysCarriedForwardLabel">
                                    Template title:</label></i> </li>
                </ul>
            </div>
            <h2>
                <font color="#707070"><strong>Holiday group days: </strong></font><em>This shows holiday group days to be used by this contract template. </em>
            </h2>
            <div style="margin-bottom: 30px;">
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="chkb" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" DataSourceID="ObjectDataSource1" DataTextField="Title" DataValueField="Id"
                    Font-Size="Medium" Enabled="False">
                </asp:CheckBoxList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListByContractTemplateId" TypeName="DAL.Mapper.HolidayGroupMapper">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ContractTemplateId" 
                            QueryStringField="ContractTemplateId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
