<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="LinkToUser.aspx.cs" Inherits="HRM.HR_Managment.Administration.User.LinkToUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/HR.Employee.Details.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/autocomplete.css" />
    <script type="text/javascript">

        $(document).ready(function () {
            bindLinks();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>
                    <asp:Label ID="EmployeeNameLabel" runat="server" Text="Gramoz Krasniqi"></asp:Label>
                </strong></font>
                <asp:HyperLink ID="EducationTrainingShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast employeeLink">Show</asp:HyperLink>
                <em>
                    <asp:Label ID="JobTitleAndUnitLabel" runat="server" Text="Senior Assistant Programmer at Software Development"></asp:Label></em>
            </h2>
            <div id="EducationTrainingDiv" class="fltlft" style="margin-bottom: 30px; width: 100%;
                display: none;">
                <asp:Image ID="empployeeImage" runat="server" ImageUrl="~/images/no-pic.jpg" CssClass="employeeImage employeeImageDetails fltlft" />
                <div class="fltlft" style="max-width: 700px;">
                    <ul id="triple">
                        <li><b>
                            <label runat="server" id="TextEmployeeNoLabel">
                                Employee no:</label>
                        </b><i>
                            <label runat="server" id="EmployeeNoLabel">
                                KPA662012</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextPersonalNoLabel">
                                Personal No:</label>
                        </b><i>
                            <label runat="server" id="PersonalNoLabel">
                                23434341221</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextDateOfBirthLabel">
                                Date of birth:</label>
                        </b><i>
                            <label runat="server" id="DateOfBirthLabel">
                                02.08.2012</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextNationalityNoLabel">
                                Nationality:</label></b> <i>
                                    <label runat="server" id="NationalityNoLabel">
                                        Albanian</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextGenderLabel">
                                Gender:</label>
                        </b><i>
                            <label runat="server" id="GenderLabel">
                                Male</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextCountryLabel">
                                Country:</label>
                        </b><i>
                            <label runat="server" id="CountryLabel">
                                Kosovo</label></i></li>
                        <li><b>
                            <label runat="server" id="TextCityLabel">
                                City:</label>
                        </b><i>
                            <label runat="server" id="CityLabel">
                                Mitrovica</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextMobilePhoneLabel">
                                Mobile phone:</label>
                        </b><i>
                            <label runat="server" id="tMobilePhoneLabel">
                                045323323</label></i></li>
                        <li><b>
                            <label runat="server" id="TextWorkEmailLabel">
                                Work email:</label>
                        </b><i>
                            <label runat="server" id="WorkEmailLabel">
                                email@email.com</label></i></li>
                        <li><b>
                            <label runat="server" id="TextBankLabel">
                                Bank:</label>
                        </b><i>
                            <label runat="server" id="BankLabel">
                                TEB Bank</label></i></li>
                        <li><b>
                            <label runat="server" id="TextAccountNumberLabel">
                                Account number:</label>
                        </b><i>
                            <label runat="server" id="AccountNumberLabel">
                                0012547865454</label></i></li>
                    </ul>
                </div>
            </div>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="userTextBox" id="userLabel">
                            User name:</label>
                        <asp:TextBox ID="userTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" ControlToValidate="userTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter user name to select from list."></asp:RequiredFieldValidator>
                        <ajaxToolkit:AutoCompleteExtender runat="server" ID="autoComplete1" EnableCaching="true"
                            BehaviorID="AutoCompleteEx" MinimumPrefixLength="2" TargetControlID="userTextBox"
                            ServicePath="~/HRMWebServices.asmx" ServiceMethod="GetUsersList" CompletionInterval="1000"
                            CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                            DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">
                            <Animations>
                              <OnShow>
                              <Sequence>
                              <%-- Make the completion list transparent and then show it --%>
                              <OpacityAction Opacity="0" />
                              <HideAction Visible="true" />

                              <%--Cache the original size of the completion list the first time
                                the animation is played and then set it to zero --%>
                              <ScriptAction Script="
                                                            var behavior = $find('AutoCompleteEx');
                                                            if (!behavior._height) {
                                                                var target = behavior.get_completionList();
                                                                behavior._height = target.offsetHeight - 2;
                                                                target.style.height = '0px';
                                                            }" />
                              <%-- Expand from 0px to the appropriate size while fading in --%>
                              <Parallel Duration=".4">
                              <FadeIn />
                              <Length PropertyKey="height" StartValue="0" 
	                            EndValueScript="$find('AutoCompleteEx')._height" />
                              </Parallel>
                              </Sequence>
                              </OnShow>
                              <OnHide>
                              <%-- Collapse down to 0px and fade out --%>
                              <Parallel Duration=".4">
                              <FadeOut />
                              <Length PropertyKey="height" StartValueScript=
	                            "$find('AutoCompleteEx')._height" EndValue="0" />
                              </Parallel>
                              </OnHide>
                            </Animations>
                        </ajaxToolkit:AutoCompleteExtender>
                        <input type="image" id="EducationDateFromImageButton" src="../../../images/lookup.jpg"
                            style="margin-left: 5px;" tabindex="1" />
                    </li>
                    <li class="second">
                        <label runat="server" for="EmailAddressTextBox" id="EmailAddressLabel">
                            Email address:</label>
                        <asp:TextBox ID="EmailAddressTextBox" runat="server" TabIndex="2" Enabled="false"></asp:TextBox>
                    </li>
                    <li>
                        <label runat="server" for="RoleDropDownList" id="RoleLabel">
                            Role:</label>
                        <asp:DropDownList ID="RoleDropDownList" runat="server" TabIndex="7">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RoleRequiredFieldValidator" ControlToValidate="RoleDropDownList"
                            Display="None" runat="server" ErrorMessage="Please select a role." InitialValue=""></asp:RequiredFieldValidator>
                        <ajaxToolkit:CascadingDropDown ID="RoleCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                            Category="Role" ServiceMethod="GetRoles" TargetControlID="RoleDropDownList"
                            ContextKey="" PromptText="Please select" />
                    </li>
                </ul>
                <ul class="clearfix">
                    <li>
                        <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                            OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                        <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                            TabIndex="18"></asp:Button></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
