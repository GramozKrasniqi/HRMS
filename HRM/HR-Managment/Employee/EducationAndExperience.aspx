<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EducationAndExperience.aspx.cs" Inherits="HRM.HR_Managment.Employee.EducationAndExperience"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <script type="text/javascript" src="/HRM/Scripts/jquery.tagsinput.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/jquery.tagsinput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        function getQueryString(queryStringParam) {
            var spageURL = window.location.search.substring(1);
            var sURLVariables = spageURL.split('&');
            for (var i = 0; i < sURLVariables.length; i++) {
                var sParameterName = sURLVariables[i].split('=');
                if (sParameterName[0] == queryStringParam) {
                    return sParameterName[1];
                }
            }
        }

        function baseUrl() {
            var href = window.location.href.split('/');
            return href[0] + '//' + href[2];
        };

        function skillManagment(value, action) {
            PageMethods.skillManagment(getQueryString('EmployeeId'), value, action,
            OnSucceeded, OnFailed);
        };

        function OnSucceeded() {
            // Dispaly "thank you."
        }

        function OnFailed(error) {
            // Alert user to the error.
            alert(error.get_message());
        }


        $(function () {
            $.ajax({
                url: "EducationAndExperience.aspx/GetSkills",   // Current Page, Method  
                data: JSON.stringify({ EmployeeId: getQueryString('EmployeeId') }), // parameter map as JSON  
                type: "POST", // data has to be POSTed  
                contentType: "application/json", // posting JSON content      
                dataType: "JSON",  // type of data is JSON (must be upper case!)  
                timeout: 10000,    // AJAX timeout  
                success: function (result) {
                    result.d
                    var n = result.d.split(',');

                    for (i = 0; i < n.length; i++) {
                        $('#skillsTag').addTag(n[i]);
                    }

                    $('#skillsTag').tagsInput({
                        'height': 'auto',
                        'width': 'auto',
                        'defaultText': 'add a skill',
                        'removeWithBackspace': false,
                        'onAddTag': function (value) {
                            skillManagment(value, 'insert');
                        },
                        'onRemoveTag': function (value) {
                            skillManagment(value, 'remove');
                        }
                    });
                },
                error: function (xhr, status) {
                    alert(status + " - " + xhr.responseText);
                }
            });



            $("#dialog-form").dialog({
                autoOpen: false,
                resizable: false,
                show: "fade",
                height: 300,
                width: 450,
                modal: true,
                close: function (event, ui) { window.location.reload(true); }
            });

            $("#NewEducationTrainingButton")
            .click(function () {
                var dlg = $("#dialog-form").dialog("open");
                $("#dialog-form").load(baseUrl() + '/HR-Managment/Employee/Container.aspx?page=' + window.location.pathname);
                dlg.parent().appendTo($("form:first"));
            });

        });
    </script>
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>
            <div id="wizard" style="margin: 0px; width: auto; height: auto;">
                <div class="page" style="width: 93%;">
                    <h2>
                        <font color="#707070"><strong>Employee Education and Trainings Information: </strong>
                        </font><em>Please enter employee education & training information: </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double">
                            <li>
                                <label runat="server" for="EducationDateFromTextBox" id="EducationDateFromLabel">
                                    Date from:</label>
                                <asp:TextBox ID="EducationDateFromTextBox" runat="server" CssClass="inputCalendar defaultText"
                                    ToolTip="" TabIndex=1></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EducationDateFromRequiredFieldValidator" ValidationGroup="Education"
                                    ControlToValidate="EducationDateFromTextBox" Display="None" runat="server" ErrorMessage="Please select 'education date from' from calendar."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="EducationDateFromRegularExpressionValidator"
                                    ControlToValidate="EducationDateFromTextBox" Display="None" runat="server" ErrorMessage=""
                                    ValidationGroup="Education" ValidationExpression=""></asp:RegularExpressionValidator>
                                <input type="image" id="EducationDateFromImageButton" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" tabindex="1" />
                                <ajaxToolkit:CalendarExtender ID="EducationDateFromCalendarExtender" runat="server"
                                    TargetControlID="EducationDateFromTextBox" CssClass="cal_Theme1" Format=""
                                    PopupButtonID="EducationDateFromImageButton" />
                            </li>
                            <li class="second">
                                <label runat="server" for="EducationDateToTextBox" id="EducationDateToLabel">
                                    Date to:</label>
                                <asp:TextBox ID="EducationDateToTextBox" runat="server" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy" TabIndex=2></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="EducationDateToRegularExpressionValidator" ControlToValidate="EducationDateToTextBox"
                                    ValidationGroup="Education" Display="None" runat="server" ErrorMessage="The 'education date to' format must be {dd.MM.yyyy}."
                                    ValidationExpression="((((0?[1-9]|[12]\d|3[01])[.](0?[13578]|1[02])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[.](0?[13456789]|1[012])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[.]0?2[.]((1[6-9]|[2-9]\d)?\d{2}))|(29[.]0?2[.]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>--%>
                                <input type="image" id="EducationDateToImageButton" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" tabindex="2" />
                                <ajaxToolkit:CalendarExtender ID="EducationDateToCalendarExtender" runat="server"
                                    TargetControlID="EducationDateToTextBox" CssClass="cal_Theme1" Format="dd.MM.yyyy"
                                    PopupButtonID="EducationDateToImageButton" />
                            </li>
                            <li>
                                <label runat="server" for="OrganisationNameTextBox" id="OrganisationNameLabel">
                                    Organisation name:</label>
                                <asp:TextBox ID="OrganisationNameTextBox" runat="server" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="OrganisationNameRequiredFieldValidator" ControlToValidate="OrganisationNameTextBox"
                                    ValidationGroup="Education" Display="None" runat="server" ErrorMessage="Please enter organisation name."></asp:RequiredFieldValidator>
                            </li>
                            <li class="second">
                                <label runat="server" for="EducationTrainingLevelDropDownList" id="EducationTrainingLevelLabel">
                                    Edu./Train. level:</label>
                                <asp:DropDownList ID="EducationTrainingLevelDropDownList" runat="server" TabIndex="4">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="EducationTrainingLevelRequiredFieldValidator" ControlToValidate="EducationTrainingLevelDropDownList"
                                    ValidationGroup="Education" Display="None" runat="server" ErrorMessage="Please select a level."
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <ajaxToolkit:CascadingDropDown ID="EducationTrainingLevelCascadingDropDown" runat="server"
                                    ServicePath="~/HRMWebServices.asmx" Category="EducationTrainingLevel" ServiceMethod="GetEducationTrainingLevels"
                                    TargetControlID="EducationTrainingLevelDropDownList" ContextKey="" PromptText="Please select" />
                            </li>
                            <li>
                                <label runat="server" for="QualificationAwardedTextBox" id="QualificationAwardedLabel">
                                    Qualification:</label>
                                <asp:TextBox ID="QualificationAwardedTextBox" runat="server" TabIndex="5"></asp:TextBox>
                            </li>
                            <li class="second">
                                <label runat="server" for="OrganisationContactTextBox" id="OrganisationContactNumberLabel">
                                    Organisation contact:</label>
                                <asp:TextBox ID="OrganisationContactTextBox" runat="server" TabIndex="6"></asp:TextBox>
                            </li>
                            <li>
                                <li class="second">
                                    <label runat="server" id="empty">
                                        &nbsp
                                    </label>
                                    <asp:Button ID="Button1" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                        runat="server" Text="Clear" TabIndex="6"></asp:Button>
                                    <asp:Button ID="newEducationButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Education"
                                        runat="server" Text="Save" OnClick="newEducationButton_Click" TabIndex="7"></asp:Button>
                                </li>
                            </li>
                        </ul>
                    </div>
                    <div style="width: 100%;">
                        <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="EducationTrainingObjectDataSource" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="DateFrom" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date from"
                                    SortExpression="DateFrom" />
                                <asp:BoundField DataField="DateTo" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date to"
                                    SortExpression="DateTo" NullDisplayText="On Going" />
                                <asp:BoundField DataField="OrganizationName" HeaderText="Organization name" SortExpression="OrganizationName" />
                                <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                                <asp:BoundField DataField="OrganizationContact" HeaderText="Organization contact"
                                    SortExpression="OrganizationContact" />
                                <asp:BoundField DataField="QualificationAwarded" HeaderText="Qualification awarded"
                                    SortExpression="QualificationAwarded" />
                                <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EducationAndExperience.aspx?delete=education&educationId={0}" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                        No educations or trainings found! Insert and it will be shown here.</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="EducationTrainingObjectDataSource" runat="server" SelectMethod="ListByEmployeeId"
                            TypeName="DAL.Mapper.EducationTrainingMapper">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <br />
                    <br />
                    <h2>
                        <font color="#707070"><strong>Employee Experience Information: </strong></font><em>Please
                            enter employee experience information: </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <ul id="double2">
                            <li>
                                <label runat="server" for="ExperienceDateFromTextBox" id="ExperienceDateFromLabel">
                                    Date from:</label>
                                <asp:TextBox ID="ExperienceDateFromTextBox" runat="server" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy" TabIndex=7></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ExperienceDateFromRequiredFieldValidator" ControlToValidate="ExperienceDateFromTextBox"
                                    Display="None" runat="server" ErrorMessage="Please select 'experienece date from' from calendar."
                                    ValidationGroup="Experience"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="ExperienceDateFromRegularExpressionValidator"
                                    ControlToValidate="ExperienceDateFromTextBox" Display="None" runat="server" ErrorMessage="The 'experience date from' format must be {dd.MM.yyyy}."
                                    ValidationGroup="Experience" ValidationExpression="((((0?[1-9]|[12]\d|3[01])[.](0?[13578]|1[02])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[.](0?[13456789]|1[012])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[.]0?2[.]((1[6-9]|[2-9]\d)?\d{2}))|(29[.]0?2[.]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                                <input type="image" id="ExperienceDateFromImage" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" tabindex="8" />
                                <ajaxToolkit:CalendarExtender ID="ExperienceDateFromCalendarExtender" runat="server"
                                    TargetControlID="ExperienceDateFromTextBox" CssClass="cal_Theme1" Format="dd.MM.yyyy"
                                    PopupButtonID="ExperienceDateFromImage" />
                            </li>
                            <li class="second">
                                <label runat="server" for="ExperienceDateToTextBox" id="ExperienceDateToLabel">
                                    Date to:</label>
                                <asp:TextBox ID="ExperienceDateToTextBox" runat="server" TabIndex="9" CssClass="inputCalendar defaultText"
                                    ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="ExperienceDateToRegularExpressionValidator" ControlToValidate="ExperienceDateToTextBox"
                                    Display="None" runat="server" ErrorMessage="The 'experience date to' format must be {dd.MM.yyyy}."
                                    ValidationGroup="Experience" ValidationExpression="((((0?[1-9]|[12]\d|3[01])[.](0?[13578]|1[02])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[.](0?[13456789]|1[012])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[.]0?2[.]((1[6-9]|[2-9]\d)?\d{2}))|(29[.]0?2[.]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>--%>
                                <input type="image" id="ExperienceDateToImageButton" src="../../images/Calendar_scheduleHS.png"
                                    style="margin-left: 5px;" tabindex="9" />
                                <ajaxToolkit:CalendarExtender ID="ExperienceDateToCalendarExtender" runat="server"
                                    TargetControlID="ExperienceDateToTextBox" CssClass="cal_Theme1" Format="dd.MM.yyyy"
                                    PopupButtonID="ExperienceDateToImageButton" />
                            </li>
                            <li>
                                <label runat="server" for="EmployeeNameTextBox" id="EmployeeNameLabel">
                                    Employee name:</label>
                                <asp:TextBox ID="EmployeeNameTextBox" runat="server" TabIndex="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmployeeNameRequiredFieldValidator" ControlToValidate="EmployeeNameTextBox"
                                    Display="None" runat="server" ErrorMessage="Please enter employee name." ValidationGroup="Experience"></asp:RequiredFieldValidator>
                            </li>
                            <li class="second">
                                <label runat="server" for="EmployeeContactTextBox" id="EmployeeContactLabel">
                                    Employee contact:</label>
                                <asp:TextBox ID="EmployeeContactTextBox" runat="server" TabIndex="11"></asp:TextBox>
                            </li>
                            <li>
                                <label runat="server" for="PositionHeldTextBox" id="PositionHeldLabel">
                                    Position held:</label>
                                <asp:TextBox ID="PositionHeldTextBox" runat="server" TabIndex="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PositionHeldRequiredFieldValidator" ControlToValidate="PositionHeldTextBox"
                                    Display="None" runat="server" ErrorMessage="Please enter the position." ValidationGroup="Experience"></asp:RequiredFieldValidator>
                            </li>
                            <li class="second">
                                <label runat="server" for="BusinessTypeTextBox" id="BusinessTypeLabel">
                                    Business type:</label>
                                <asp:TextBox ID="BusinessTypeTextBox" runat="server" TabIndex="13"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="BusinessTypeRequiredFieldValidator" ControlToValidate="BusinessTypeTextBox"
                                    Display="None" runat="server" ErrorMessage="Please enter the business type."
                                    ValidationGroup="Experience"></asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <li class="second">
                                    <label runat="server" id="Label5">
                                        &nbsp
                                    </label>
                                    <asp:Button ID="Button" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                        runat="server" Text="Clear" TabIndex="14"></asp:Button>
                                    <asp:Button ID="newExperienceButton" ToolTip="Save" CssClass="secondaryButton" runat="server"
                                        Text="Save" ValidationGroup="Experience" TabIndex="15" OnClick="newExperience_Click">
                                    </asp:Button>
                                </li>
                            </li>
                            <li></li>
                        </ul>
                    </div>
                    <div style="width: 100%;">
                        <asp:GridView ID="ExperienceGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="ExperienceObjectDataSource" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="DateFrom" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date from"
                                    SortExpression="DateFrom" />
                                <asp:BoundField DataField="DateTo" DataFormatString="{0:dd.MM.yyyy}" HeaderText="Date to"
                                    SortExpression="DateTo" NullDisplayText="On Going" />
                                <asp:BoundField DataField="EmployeeName" HeaderText="Employee name" SortExpression="EmployeeName" />
                                <asp:BoundField DataField="EmployeeContact" HeaderText="Employee contact" SortExpression="EmployeeContact" />
                                <asp:BoundField DataField="PositionHeld" HeaderText="Position held" SortExpression="PositionHeld" />
                                <asp:BoundField DataField="BusinessType" HeaderText="Business type" SortExpression="BusinessType" />
                                <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EducationAndExperience.aspx?delete=education&experienceId={0}" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="ExperienceNoDataLabel" style="font-size: 15px;">
                                        No experiences found! Insert and it will be shown here.</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ExperienceObjectDataSource" runat="server" SelectMethod="ListByEmployeeId"
                            TypeName="DAL.Mapper.ExperienceMapper">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="employeeId" QueryStringField="EmployeeId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <br />
                    <br />
                    <h2>
                        <font color="#707070"><strong>Employee Skills: </strong></font><em>Please enter employee
                            skills: </em>
                    </h2>
                    <div style="margin-bottom: 15px;">
                        <input id="skillsTag" />
                    </div>
                    <ul class="clearfix">
                        <li>
                            <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                                TabIndex="19" OnClick="ProceedButton_Click" CausesValidation="False"></asp:Button>
                            <asp:Button ID="FinishNewButton" CssClass="right login_btn" runat="server" Text="Finish/New"
                                TabIndex="18" CausesValidation="False" OnClick="FinishNewButton_Click"></asp:Button>
                            <asp:Button ID="BackButton" CssClass="right login_btn" runat="server" Text="Back"
                                TabIndex="17" OnClick="BackButton_Click"></asp:Button>
                            <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                                TabIndex="16" OnClick="CancelButton_Click"></asp:Button>
                        </li>
                    </ul>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
