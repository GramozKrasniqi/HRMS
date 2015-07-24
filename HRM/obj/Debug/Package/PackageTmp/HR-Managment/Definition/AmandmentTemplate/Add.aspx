<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="HRM.HR_Managment.Definition.AmandmentTemplate.Add" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <style type="text/css">
        .cpHeader
        {
            background: url(/HRM/images/hdr_bg.png) repeat-x;
            color: white;
            background-color: #719DDB;
            font: bold 11px auto "Trebuchet MS" , Verdana;
            font-size: 12px;
            cursor: pointer;
            width: 97%;
            height: 18px;
            padding: 4px;
        }
        .cpBody
        {
            background-color: white;
            font: normal 11px auto Verdana, Arial;
            border: 1px gray;
            width: 95%;
            padding: 4px;
            padding-top: 7px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function string(param) {
            CKEDITOR.instances.ctl00_ContentPlaceHolder1_CKEditor1.insertHtml(' ' + param + ' ');
            CKEDITOR.instances.ctl00_ContentPlaceHolder1_CKEditor1.scrollIntoView();
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Amandament information - language /
                    <asp:Label ID="LanguageLabel" runat="server">Shqip</asp:Label> </strong></font><em>Please enter
                    amandament template information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double2">
                    <li>
                        <label runat="server" for="AmandamentTemplateTitleTextBox" id="AmandamentTemplateTitleLabel">
                            Template title:</label>
                        <asp:TextBox ID="AmandamentTemplateTitleBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AmandamentTemplateTitleRequiredFieldValidator" ControlToValidate="AmandamentTemplateTitleBox"
                            Display="None" runat="server" ErrorMessage="Please enter amandament template title."></asp:RequiredFieldValidator>
                    </li>
                </ul>
                <ul id="double">
                    <li>
                        <asp:Panel ID="employeeHeader" runat="server" CssClass="cpHeader">
                            <asp:Label ID="employeeText" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="employeeBody" runat="server" CssClass="cpBody">
                            <ul id="triple">
                                <li><a href="#" id="EmployeeNoHref" onclick="string('{#EmployeeNo}')">Employee number</a>
                                </li>
                                <li><a href="#" id="PersonalNoHref" onclick="string('{#PersonalNo}')">Personal number</a>
                                </li>
                                <li><a href="#" id="FirstNameHref" onclick="string('{#EmployeeName}')">Employee name</a>
                                </li>
                                <li><a href="#" id="DateBirthHref" onclick="string('{#DateOfBirth}')">Date of birth</a>
                                </li>
                                <li><a href="#" id="GenderHref" onclick="string('{#Gender}')">Gender</a> </li>
                                <li><a href="#" id="CountryHref" onclick="string('{#Country}')">Country</a> </li>
                                <li><a href="#" id="AddressHref" onclick="string('{#Address}')">Address</a> </li>
                                <li><a href="#" id="MobilePhoneHref" onclick="string('{#MobilePhone}')">MobilePhone</a>
                                </li>
                                <li><a href="#" id="WorkEmailHref" onclick="string('{#WorkEmail}')">Work email</a>
                                </li>
                            </ul>
                        </asp:Panel>
                        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="employeeBody"
                            CollapseControlID="employeeHeader" ExpandControlID="employeeHeader" Collapsed="true"
                            TextLabelID="employeeText" CollapsedText="Employee (Click to Show Content..)"
                            ExpandedText="Employee (Click to Hide Content..)" CollapsedSize="0">
                        </asp:CollapsiblePanelExtender>
                    </li>
                    <li class="second">
                        <asp:Panel ID="jobHeader" runat="server" CssClass="cpHeader">
                            <asp:Label ID="jobText" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="jobBody" runat="server" CssClass="cpBody">
                            <ul id="triple1">
                                <li><a href="#" id="JobCodeHref" onclick="string('{#JobCode}')">Job code</a> </li>
                                <li><a href="#" id="JobTitleHref" onclick="string('{#JobTitle}')">Job title</a>
                                </li>
                                <li><a href="#" id="OrganizationalUnitHref" onclick="string('{#OrganisationalUnit}')">
                                    Organisational unit</a> </li>
                                <li><a href="#" id="ParentOrganizationalUnitHref" onclick="string('{#ParentOrganisationalUnit}')">
                                    Parent organisational unit</a> </li>
                                <li><a href="#" id="ReportsToHref" onclick="string('{#ReportsTo}')">Reports to</a>
                                </li>
                                <li><a href="#" id="GradeIdHref" onclick="string('{#Grade}')">Grade</a> </li>
                                <li><a href="#" id="GradeKCBHref" onclick="string('{#GradeKCB}')">Grade KCB</a>
                                </li>
                                <li><a href="#" id="GradeKCBEntryHref" onclick="string('{#GradeKCB}')">Grade KCB entry</a>
                                </li>
                                <li><a href="#" id="GradeTotalEntryHref" onclick="string('{#GradeEntry}')">Grade total
                                    entry</a> </li>
                                <li><a href="#" id="StepIdHref" onclick="string('{#Step}')">Step</a> </li>
                                <li><a href="#" id="StepEntryHref" onclick="string('{#StepEntry}')">Step entry</a>
                                </li>
                                <li><a href="#" id="JobDescriptionHref" onclick="string('{#JobDescription}')">Step entry</a>
                                </li>
                            </ul>
                        </asp:Panel>
                        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="jobBody"
                            CollapseControlID="jobHeader" ExpandControlID="jobHeader" Collapsed="true" TextLabelID="jobText"
                            CollapsedText="Job title (Click to Show Content..)" ExpandedText="Job title (Click to Hide Content..)"
                            CollapsedSize="0">
                        </asp:CollapsiblePanelExtender>
                    </li>
                    <li>
                        <asp:Panel ID="contractHeader" runat="server" CssClass="cpHeader">
                            <asp:Label ID="contractText" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="contractBody" runat="server" CssClass="cpBody">
                            <ul id="triple2">
                                <li><a href="#" id="ContractNumberHref" onclick="string('{#ContractNumber}')">Contract
                                    number</a> </li>
                                <li><a href="#" id="OfficiallyApprovedDate" onclick="string('{#OfficiallyApprovedDate}')">
                                    Officially approved date</a> </li>
                                <li><a href="#" id="StartDateHref" onclick="string('{#StartDate}')">Start date</a>
                                </li>
                                <li><a href="#" id="EndDateHref" onclick="string('{#EndDate}')">End date</a> </li>
                                <li><a href="#" id="GrossValueHref" onclick="string('{#GrossValue}')">Gross value</a>
                                </li>
                            </ul>
                        </asp:Panel>
                        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" TargetControlID="contractBody"
                            CollapseControlID="contractHeader" ExpandControlID="contractHeader" Collapsed="true"
                            TextLabelID="contractText" CollapsedText="Contract (Click to Show Content..)"
                            ExpandedText="Contract (Click to Hide Content..)" CollapsedSize="0">
                        </asp:CollapsiblePanelExtender>
                    </li>
                    <li>
                        <asp:Panel ID="generalHeader" runat="server" CssClass="cpHeader">
                            <asp:Label ID="generalText" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="generalBody" runat="server" CssClass="cpBody">
                            <ul id="triple3">
                                <li><a href="#" id="TodayDateHref" onclick="string('{#TodayDate}')">Today date</a>
                                </li>
                                <li><a href="#" id="Time" onclick="string('{#Time}')">Time</a> </li>
                            </ul>
                        </asp:Panel>
                        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender4" runat="server" TargetControlID="generalBody"
                            CollapseControlID="generalHeader" ExpandControlID="generalHeader" Collapsed="true"
                            TextLabelID="generalText" CollapsedText="General (Click to Show Content..)" ExpandedText="General (Click to Hide Content..)"
                            CollapsedSize="0">
                        </asp:CollapsiblePanelExtender>
                    </li>
                </ul>
            </div>
            <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="500" BasePath="~/ckeditor"
                FilebrowserBrowseUrl="/HRM/ckfinder/ckfinder.html" FilebrowserImageBrowseUrl="/HRM/ckfinder/ckfinder.html?type=Images"
                FilebrowserImageUploadUrl="/HRM/ckfinder/core/connector/aspx/connector.aBspx?command=QuickUpload&type=Images"
                TabIndex="6">
            </CKEditor:CKEditorControl>
            <ul class="clearfix" style="width: auto; margin-top: 12px !important;">
                <li>
                    <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                        OnClick="ProceedButton_Click" TabIndex="9"></asp:Button>
                    <asp:Button ID="BackButton" CssClass="right login_btn" runat="server" Text="Back"
                        OnClick="BackButton_Click" TabIndex="8" CausesValidation="false"></asp:Button>
                    <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel"
                        TabIndex="7" onclick="CancelButton_Click"></asp:Button></li>
            </ul>
        </div>
    </div>
</asp:Content>
