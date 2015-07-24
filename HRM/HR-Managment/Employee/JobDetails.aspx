<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="JobDetails.aspx.cs" Inherits="HRM.HR_Managment.Employee.JobDetails"
    EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/RequiredFieldValidatorForCheckBoxList.js"></script>
    <script type="text/javascript" src="../../Scripts/defaultText.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_IsInterShipCheckBox').change(function () {
                $('#pay').toggle();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; height: auto; width: auto;">
                <div class="page" style="width: 93%;">
                    <div id="dialog-form">
                    </div>
                    <h2>
                        <font color="#707070"><strong>Vacancy details: </strong></font><em>Please enter vacancy
                            details. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double2">
                            <li>
                                <label runat="server" for="VacancyNoTextBox" id="VacancyNoLabel">
                                    Vacancy number:</label>
                                <asp:TextBox ID="VacancyNoTextBox" runat="server" TabIndex="1">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="VacancyNoTextBox"
                                    Display="None" runat="server" ErrorMessage="Please write the vacancy number."
                                    InitialValue=""></asp:RequiredFieldValidator>
                            </li>
                            <li class="second">
                                <label runat="server" for="VacancyDateTextBox" id="VacancyDateLabel">
                                    Vacancy date:</label>
                                <asp:TextBox ID="VacancyDateTextBox" runat="server" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="VacancyDateRequiredFieldValidator" ControlToValidate="VacancyDateTextBox"
                                    Display="None" runat="server" ErrorMessage="Please select vacancy date."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="VacancyDateRegularExpressionValidator" ControlToValidate="VacancyDateTextBox"
                                    Display="None" runat="server" ErrorMessage="The vacancy date format must be {dd.MM.yyyy}."
                                    ValidationExpression="((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                                <input type="image" id="VacancyDateImage" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" />
                                <ajaxToolkit:CalendarExtender ID="VacancyDateCalendarExtender" runat="server" TargetControlID="VacancyDateTextBox"
                                    CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="VacancyDateImage" />
                            </li>
                        </ul>
                    </div>
                    <h2>
                        <font color="#707070"><strong>Job Details: </strong></font><em>Please enter employee
                            job details. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="PayTypeDropDownList" id="Label1">
                                    Pay type:</label>
                                <asp:DropDownList ID="PayTypeDropDownList" runat="server" TabIndex="1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="PayTypeRequiredFieldValidator" ControlToValidate="PayTypeDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the pay type." InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="PayTypeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                    Category="PayTypes" ServiceMethod="GetPayTypes" TargetControlID="PayTypeDropDownList"
                                    ContextKey="" PromptText="Please select" />
                            </li>
                            <li class="second">
                                <label runat="server" for="FunctionalLevelDropDownList" id="FunctionalLevelLabel">
                                    Functional level:</label>
                                <asp:DropDownList ID="FunctionalLevelDropDownList" runat="server" TabIndex="1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="FunctionalLevelRequiredFieldValidator" ControlToValidate="FunctionalLevelDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the functional level."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="FunctionalLevelsCascadingDropDown" runat="server"
                                    ServicePath="~/HRMWebServices.asmx" Category="FunctionalLevels" ServiceMethod="GetFunctionalLevels"
                                    TargetControlID="FunctionalLevelDropDownList" PromptText="Please select" />
                            </li>
                            <li>
                                <label runat="server" for="OrganisationalUnitDropDownList" id="OrganisationalUnitLabel">
                                    Organizational unit:</label>
                                <asp:DropDownList ID="OrganisationalUnitDropDownList" runat="server" TabIndex="2">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="OrganisationalUnitRequiredFieldValidator" ControlToValidate="OrganisationalUnitDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the organizational unit."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="OrganisationalUnitCascadingDropDown" runat="server"
                                    ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnit" ServiceMethod="GetOrganizationalUnits"
                                    TargetControlID="OrganisationalUnitDropDownList" PromptText="Please select" ContextKey="" />
                            </li>
                            <li class="second">
                                <label runat="server" for="JobDownList" id="JobLabel">
                                    Job:</label>
                                <asp:DropDownList ID="JobDetailsDropDownList" runat="server" TabIndex="3">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="JobDetailsRequiredFieldValidator" ControlToValidate="JobDetailsDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the job for employee."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="JobDetailsCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                    Category="JobTitle" ServiceMethod="GetJobTitlesByOrganisationalUnit" TargetControlID="JobDetailsDropDownList"
                                    PromptText="Please select" ParentControlID="OrganisationalUnitDropDownList" ContextKey="" />
                            </li>
                            <li class="chkbLI">
                                <label runat="server" for="IsInterShipCheckBox" id="IsInterShipLabel">
                                    Is Intership:</label>
                                <asp:CheckBox runat="server" ID="IsInterShipCheckBox" Checked="false" />
                            </li>
                            <li class="second">
                                <label runat="server" for="WorkTypeCheckBox" id="WorkTypeLabel">
                                    Work type:</label>
                                <asp:DropDownList ID="WorkTypeDropDownList" runat="server" TabIndex="5">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="WorkTypeRequiredFieldValidator" ControlToValidate="WorkTypeDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the step a work type."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" ServicePath="~/HRMWebServices.asmx"
                                    Category="WorkType" ServiceMethod="GetWorkTypes" TargetControlID="WorkTypeDropDownList"
                                    PromptText="Please select" ContextKey="" />
                            </li>
                            <div id="pay">
                                <li id="gradeLI">
                                    <label runat="server" for="GradeDropDownList" id="GradeLabel">
                                        Grade type:</label>
                                    <asp:DropDownList ID="GradeDropDownList" runat="server" TabIndex="4">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="GradeRequiredFieldValidator" ControlToValidate="GradeDropDownList"
                                        Display="None" runat="server" ErrorMessage="Please select the grade for the job."
                                        InitialValue=""></asp:RequiredFieldValidator>
                                    <ajaxToolkit:CascadingDropDown ID="GradeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                        Category="Grade" ServiceMethod="GetGradesByJobCode" TargetControlID="GradeDropDownList"
                                        PromptText="Please select" ParentControlID="JobDetailsDropDownList" />
                                </li>
                                <li class="second" id="stepLI">
                                    <label runat="server" for="StepDropDownList" id="StepLabel">
                                        Step type:</label>
                                    <asp:DropDownList ID="StepDropDownList" runat="server" TabIndex="5">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="StepRequiredFieldValidator" ControlToValidate="StepDropDownList"
                                        Display="None" runat="server" ErrorMessage="Please select the step for the grade."
                                        InitialValue=""></asp:RequiredFieldValidator>
                                    <ajaxToolkit:CascadingDropDown ID="StepCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                        Category="Step" ServiceMethod="GetStepsByGradeId" TargetControlID="StepDropDownList"
                                        PromptText="Please select" ParentControlID="GradeDropDownList" />
                                </li>
                            </div>
                            <li>
                                <label runat="server" for="PayRateTextBox" id="PayRateLabel">
                                    Pay rate:</label>
                                <asp:TextBox runat="server" ID="PayRateTextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PayRateRequiredFieldValidator3" ControlToValidate="PayRateTextBox"
                                    Display="None" runat="server" ErrorMessage="Please select the pay rate." InitialValue=""></asp:RequiredFieldValidator>
                            </li>
                        </ul>
                    </div>
                    <br />
                    <h2>
                        <font color="#707070"><strong>Employee contracts: </strong></font><em>Please select
                            contract types for the emplyee. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <asp:CheckBoxList ID="ContractsCheckBoxList" runat="server" CssClass="chkb" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" DataSourceID="ContractObjectDataSource" DataTextField="Preffix"
                            DataValueField="Id" Font-Size="Medium">
                        </asp:CheckBoxList>
                        <asp:CustomValidator ID="ContractsRequiredFieldValidator" Display="None" runat="server"
                            ErrorMessage="Please check at least one contract." InitialValue="" ClientValidationFunction="ensureChecked"></asp:CustomValidator>
                        <asp:ObjectDataSource ID="ContractObjectDataSource" runat="server" SelectMethod="ListWithAdvancedFilter"
                            TypeName="DAL.Mapper.ContractTemplateMapper">
                            <SelectParameters>
                                <asp:Parameter ConvertEmptyStringToNull="False" DefaultValue="" Name="search" Type="String" />
                                <asp:Parameter DefaultValue="" Name="status" Type="Object" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <ul class="clearfix">
                        <li>
                            <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                                TabIndex="8" OnClick="ProceedButton_Click"></asp:Button>
                            <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                                TabIndex="7"></asp:Button></li>
                    </ul>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
