<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PreData.aspx.cs" Inherits="HRM.HR_Managment.Definition.ContractTemplate.PreData" %>

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
                        <font color="#707070"><strong>Leave days: </strong></font><em>Please enter leave information
                            for the current contract template. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="LeaveDaysPerMonthTextBox" id="LeaveDaysPerMonthLabel">
                                    Leave days / 1 Month:</label>
                                <ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server" TargetControlID="LeaveDaysPerMonthTextBox"
                                    Minimum="0" Maximum="10" BoundControlID="LeaveDaysPerMonthTextBox" Steps="100"
                                    Decimals="1" />
                                <asp:TextBox runat="server" ID="LeaveDaysPerMonthTextBox" CssClass="textSlider"></asp:TextBox>
                            </li>
                            <li class="second">
                                <label runat="server" for="LeaveDaysPerExperienceTextBox" id="LeaveDaysPerExperienceLabel">
                                    Exp. leave days / 1 Year:</label>
                                <ajaxToolkit:SliderExtender ID="SliderExtender2" runat="server" TargetControlID="LeaveDaysPerExperienceTextBox"
                                    Minimum="0" Maximum="10" BoundControlID="LeaveDaysPerExperienceTextBox" Steps="100"
                                    Decimals="1" />
                                <asp:TextBox runat="server" ID="LeaveDaysPerExperienceTextBox" CssClass="textSlider"></asp:TextBox>
                            </li>
                            <li>
                                <label runat="server" for="FunctionalLevelDropDownList" id="LeaveDaysCarriedForwardLabel">
                                    Days carried forward:</label>
                                <ajaxToolkit:SliderExtender ID="SliderExtender3" runat="server" TargetControlID="LeaveDaysCarriedForwardTextBox"
                                    Minimum="0" Maximum="30" BoundControlID="LeaveDaysCarriedForwardTextBox" Steps="100" />
                                <asp:TextBox runat="server" ID="LeaveDaysCarriedForwardTextBox" CssClass="textSlider"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                    <br />
                    <h2>
                        <font color="#707070"><strong>Select holiday group days: </strong></font><em>Please select
                            holiday group days to be used by this contract template. </em>
                    </h2>
                    <div style="margin-bottom: 30px;">
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="chkb" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" DataSourceID="ObjectDataSource1" DataTextField="Title"
                            DataValueField="Id" Font-Size="Medium" 
                            onprerender="CheckBoxList2_PreRender">
                        </asp:CheckBoxList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="List" TypeName="DAL.Mapper.HolidayGroupMapper">
                            <SelectParameters>
                                <asp:Parameter ConvertEmptyStringToNull="False" DefaultValue="" Name="search" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <h2>
                        <font color="#707070"><strong>Select languages: </strong></font><em>Please select languages
                            to be used by this contract template. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <asp:CheckBoxList ID="ContractsCheckBoxList" runat="server" CssClass="chkb" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" DataSourceID="ContractObjectDataSource" DataTextField="Title"
                            DataValueField="Id" Font-Size="Medium" 
                            onprerender="ContractsCheckBoxList_PreRender">
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
