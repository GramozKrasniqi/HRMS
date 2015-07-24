<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ContractExtend.aspx.cs" Inherits="HRM.HR_Managment.Employee.ContractExtend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; height: auto; width: auto;">
                <div class="page" style="width: 93%;">
                    <div id="dialog-form">
                    </div>
                    <h2>
                        <font color="#707070"><strong>Contract changes: </strong></font><em>Please make the
                            neccessary changes for the up comming contract. </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
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
                            <li class="second">
                                <label runat="server" for="OrganisationalUnitDropDownList" id="OrganisationalUnitLabel">
                                    Organizational unit:</label>
                                <asp:DropDownList ID="OrganisationalUnitDropDownList" runat="server" TabIndex="2">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="OrganisationalUnitRequiredFieldValidator" ControlToValidate="OrganisationalUnitDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the organizational unit."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="OrganisationalUnitCascadingDropDown" runat="server"
                                    ServicePath="~/HRMWebServices.asmx" Category="OrganizationalUnit" ServiceMethod="GetOrganizationalUnits"
                                    TargetControlID="OrganisationalUnitDropDownList" PromptText="Please select" />
                            </li>
                            <li>
                                <label runat="server" for="JobDownList" id="JobLabel">
                                    Job:</label>
                                <asp:DropDownList ID="JobDetailsDropDownList" runat="server" TabIndex="3">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="JobDetailsRequiredFieldValidator" ControlToValidate="JobDetailsDropDownList"
                                    Display="None" runat="server" ErrorMessage="Please select the job for employee."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="JobDetailsCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                                    Category="JobTitle" ServiceMethod="GetJobTitlesByOrganisationalUnit" TargetControlID="JobDetailsDropDownList"
                                    PromptText="Please select" ParentControlID="OrganisationalUnitDropDownList" />
                            </li>
                            <li class="second">
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
                            <li>
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
                            <li class="second">
                                <label runat="server" for="OtherInfoTextBox" id="OtherInfoLabel">
                                    Other information:</label>
                                <asp:TextBox ID="OtherInfoTextBox" runat="server" TabIndex="6"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                    <h2>
                        <font color="#707070"><strong>Employee Contract Information: </strong></font><em>Please
                            enter employee contract information: </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double2">
                            <li>
                                <label runat="server" for="ContractTemplateTitleLabel" id="TextContractTemplateTitleLabel">
                                    Contract type:</label>
                                <b>
                                    <label runat="server" id="ContractTemplateTitleLabel">
                                    </label>
                                </b></li>
                            <li class="second">
                                <label runat="server" for="ContractNumberTextBox" id="ContractNumberLabel">
                                    Contract number:</label>
                                <asp:TextBox ID="ContractNumberTextBox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ContractNumberRequiredFieldValidator" ValidationGroup="ContractTemplate"
                                    ControlToValidate="ContractNumberTextBox" Display="None" runat="server" ErrorMessage="Please type contract number."></asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <label runat="server" for="StartDateTextBox" id="StarDateLabel">
                                    Start date:</label>
                                <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="StartDateRequiredFieldValidator" ValidationGroup="ContractTemplate"
                                    ControlToValidate="StartDateTextBox" Display="None" runat="server" ErrorMessage="Please select start date for contract."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" ControlToValidate="StartDateTextBox"
                                    Display="None" runat="server" ErrorMessage="The start date format must be {dd.MM.yyyy}."
                                    ValidationGroup="ContractTemplate" ValidationExpression="((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                                <input type="image" id="StartDateImage" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" />
                                <ajaxToolkit:CalendarExtender ID="StartDateCalendarExtender" runat="server" TargetControlID="StartDateTextBox"
                                    CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="StartDateImage" />
                            </li>
                            <li class="second">
                                <label runat="server" for="EndDateTextBox" id="EndDateLabel">
                                    End date:</label>
                                <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                                <input type="image" id="EndDateImageButton" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" />
                                <ajaxToolkit:CalendarExtender ID="EndDateCalendarExtender" runat="server" TargetControlID="EndDateTextBox"
                                    CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="EndDateImageButton" />
                            </li>
                        </ul>
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
