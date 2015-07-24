<%@ Page Title="Personal Information" Language="C#" MasterPageFile="~/Site.Master"
    EnableEventValidation="false" AutoEventWireup="true" CodeBehind="PersonalInformation.aspx.cs"
    Inherits="HRM.HR_Managment.Employee.PersonalInformation" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script type="text/javascript">
        //Functions to be used by the file uploader ajax plugin
        function onClientUploadComplete(sender, e, imgDisplayerId) {
            var id = e.get_fileId();
            onImageValidated("TRUE", e);
        }
        function onImageValidated(arg, context) {

            if (arg == "TRUE") {
                var url = context.get_postedUrl();
                url = url.replace('&amp;', '&');
                url = baseUrl() + url;
                createThumbnail(context, url);
            }
        }
        function createThumbnail(e, url) {
            var img = document.getElementById('ctl00_ContentPlaceHolder1_empployeeImage');
            img.setAttribute("src", url);
        }
        //End of functions for the file uploader ajax plugin
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Personal information: </strong></font><em>Please enter
                    employee personal information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="EmployeeNoTextBox" id="EmployeeNoLabel">
                            Employee no:</label>
                        <asp:TextBox ID="EmployeeNoTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmployeeNoRequiredFieldValidator" ControlToValidate="EmployeeNoTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter employee number."></asp:RequiredFieldValidator>
                    </li>
                    <li class="second">
                        <label runat="server" for="FirstnameTextBox" id="FirstnameLabel">
                            Firstname:</label>
                        <asp:TextBox ID="FirstnameTextBox" runat="server" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" ControlToValidate="FirstnameTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter firstname."></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label runat="server" for="MiddlenameTextBox" id="MiddlenameLabel">
                            Middlename:</label>
                        <asp:TextBox ID="MiddlenameTextBox" runat="server" TabIndex="3"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="LastnameTextBox" id="LastnameLabel">
                            Lastname:</label>
                        <asp:TextBox ID="LastnameTextBox" runat="server" TabIndex="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="LastnameRequiredFieldValidator" ControlToValidate="LastnameTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter lastname."></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label runat="server" for="PersonalNumberTextBox" id="PersonalNumberLabel">
                            Personal number:</label>
                        <asp:TextBox ID="PersonalNumberTextBox" runat="server" TabIndex="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PersonalNumberRequiredFieldValidator" ControlToValidate="PersonalNumberTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter the personal number."></asp:RequiredFieldValidator>
                    </li>
                    <li class="second">
                        <label runat="server" for="DateOfBirthTextBox" id="DateOfBirthLabel">
                            Date of birth:</label>
                        <asp:TextBox ID="DateOfBirthTextBox" runat="server" TabIndex="999" CssClass="inputCalendar defaultText"
                            ToolTip="Format: dd.MM.yyyy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="DateOfBirthRequiredFieldValidator" ControlToValidate="DateOfBirthTextBox"
                            Display="None" runat="server" ErrorMessage="Please select birth date from calendar."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="DateOfBirthRegularExpressionValidator" ControlToValidate="DateOfBirthTextBox"
                            Display="None" runat="server" ErrorMessage="The birth date format must be {dd.MM.yyyy}."
                            ValidationExpression="((((0?[1-9]|[12]\d|3[01])[.](0?[13578]|1[02])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[.](0?[13456789]|1[012])[.]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[.]0?2[.]((1[6-9]|[2-9]\d)?\d{2}))|(29[.]0?2[.]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$"></asp:RegularExpressionValidator>
                       <%-- <asp:RangeValidator ID="valDateRange" runat="server" ControlToValidate="DateOfBirthTextBox"
                            Type="Date" Display="None" />--%>
                        <input type="image" id="DateOfBirthImageButton" src="../../images/Calendar_scheduleHS.png"
                            style="margin-left: 5px;" tabindex="6" />
                        <ajaxToolkit:CalendarExtender ID="DateOfBirthCalendarExtender" runat="server" TargetControlID="DateOfBirthTextBox"
                            CssClass="cal_Theme1" Format="dd.MM.yyyy" PopupButtonID="DateOfBirthImageButton" />
                    </li>
                    <li>
                        <label runat="server" for="MaritalStatusDropDownList" id="MaritalStatusLabel">
                            Marital status:</label>
                        <asp:DropDownList ID="MaritalStatusDropDownList" runat="server" TabIndex="7">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="MaritalStatusRequiredFieldValidator" ControlToValidate="MaritalStatusDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select marital status." InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="MaritalStatusCascadingDropDown" runat="server"
                            ServicePath="~/HRMWebServices.asmx" Category="MaritalStatus" ServiceMethod="GetMaritalStatus"
                            TargetControlID="MaritalStatusDropDownList" ContextKey="" PromptText="Please select" />
                    </li>
                    <li class="second">
                        <label runat="server" for="GenderDropDownList" id="GenderLabel">
                            Gender:</label>
                        <asp:DropDownList ID="GenderDropDownList" runat="server" TabIndex="8">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="GenderRequiredFieldValidator" ControlToValidate="GenderDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select a gender." InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="GenderCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="Gender" ServiceMethod="GetGenders" TargetControlID="GenderDropDownList"
                            ContextKey="" PromptText="Please select" />
                    </li>
                    <li>
                        <label runat="server" for="NationalityDropDownList" id="NationalityLabel">
                            Nationality:</label>
                        <asp:DropDownList ID="NationalityDropDownList" runat="server" TabIndex="9">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="NationalityRequiredFieldValidator" ControlToValidate="NationalityDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select a nationality."></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="NationalityCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="Nationality" ServiceMethod="GetNationalities" TargetControlID="NationalityDropDownList"
                            ContextKey="" PromptText="Please select" />
                    </li>
                    <li class="second">
                        <label runat="server" for="CountryDropDownList" id="CountryLabel">
                            Country:</label>
                        <asp:DropDownList ID="CountryDropDownList" runat="server" TabIndex="10">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="CountryRequiredFieldValidator" ControlToValidate="CountryDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select a country."></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="CountryCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="Country" ServiceMethod="GetCountrie" TargetControlID="CountryDropDownList"
                            ContextKey="" PromptText="Please select" />
                    </li>
                    <li>
                        <label runat="server" for="CityTextBox" id="CityLabel">
                            City:</label>
                        <asp:TextBox ID="CityTextBox" runat="server" TabIndex="11"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="AddressTextBox" id="AddressLabel">
                            Address:</label>
                        <asp:TextBox ID="AddressTextBox" runat="server" TabIndex="12"></asp:TextBox>
                    </li>
                    <li>
                        <label runat="server" for="MobilePhoneTextBox" id="MobilePhoneLabel">
                            Mobile phone:</label>
                        <asp:TextBox ID="MobilePhoneTextBox" runat="server" TabIndex="13"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="Mobile2TextBox" id="Mobile2Label">
                            Mobile phone 2:</label>
                        <asp:TextBox ID="Mobile2TextBox" runat="server" TabIndex="13"></asp:TextBox>
                    </li>
                    <li>
                        <label runat="server" for="WorkEmailTextBox" id="WorkEmailLabel">
                            Work email:</label>
                        <asp:TextBox ID="WorkEmailTextBox" runat="server" TabIndex="14" CssClass="defaultText"
                            ToolTip="Format: somone@example.com"></asp:TextBox>
                    </li>
                    <li class="second">
                        <label runat="server" for="OtherEmailTextBox" id="OtherEmailLabel">
                            Other email:</label>
                        <asp:TextBox ID="OtherEmailTextBox" runat="server" TabIndex="15" CssClass="defaultText"
                            ToolTip="Format: somone@example.com"></asp:TextBox>
                    </li>
                    <li>
                        <label runat="server" for="BankDropDownList" id="BankLabel">
                            Bank:</label>
                        <asp:DropDownList ID="BankDropDownList" runat="server" TabIndex="16">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="BankRequiredFieldValidator" ControlToValidate="BankDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select a bank."></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="BankCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="Banks" ServiceMethod="GetBanks" TargetControlID="BankDropDownList"
                            ContextKey="" PromptText="Please select" />
                    </li>
                    <li class="second">
                        <label runat="server" for="AccountNumberTextBox" id="AccountNumberLabel">
                            Account number:</label>
                        <asp:TextBox ID="AccountNumberTextBox" runat="server" TabIndex="17"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AccountNumberRequiredFieldValidator" ControlToValidate="AccountNumberTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter the account number."></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <label runat="server" id="SelectImageLabel">
                            Select image:</label>
                        <asp:AjaxFileUpload ID="AjaxFileUpload1" ThrobberID="myThrobber" ContextKeys="fred"
                            TabIndex="18" AllowedFileTypes="jpg,jpeg,png" MaximumNumberOfFiles="1" runat="server"
                            OnClientUploadComplete="onClientUploadComplete" OnUploadComplete="saveImage" />
                    </li>
                    <li class="second">
                        <label runat="server" id="PictureLabel">
                            Picture:</label>
                        <asp:Image ID="empployeeImage" runat="server" ImageUrl="~/images/no-pic.jpg" CssClass="employeeImage fltrht" />
                    </li>
                </ul>
            </div>
            <div>
                <ul class="clearfix">
                    <li>
                        <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                            OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                        <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                            TabIndex="18" OnClick="CancelButton_Click"></asp:Button></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
