<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DefineGrade.aspx.cs" Inherits="HRM.HR_Managment.JobTitle.DefineGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <style type="text/css">
        #EducationTrainingDiv
        {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>
                    <asp:Label ID="EmployeeNameLabel" runat="server" Text="Step 2 - Define grades and steps"></asp:Label>
                </strong></font><em>
                    <asp:Label ID="JobTitleAndUnitLabel" runat="server" Text="Define grades and steps for current job title."></asp:Label></em>
            </h2>
            <div style="width: 100%; clear: both;">
                <h2 id="EducationTrainingTitle">
                    <font color="#707070"><strong>Define grades</strong></font>
                </h2>
                <div id="EducationTrainingDiv">
                    <ul id="double">
                        <li>
                            <label runat="server" for="GradeTextBox" id="GradeLabel">
                                Grade:</label>
                            <asp:TextBox ID="GradeTextBox" runat="server" TabIndex="15"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="GradeRequiredFieldValidator" ControlToValidate="GradeTextBox"
                                Display="None" runat="server" ErrorMessage="Please provide a name for grade."
                                ValidationGroup="Grade"></asp:RequiredFieldValidator>
                        </li>
                        <li class="second">
                            <label runat="server" id="empty">
                                &nbsp
                            </label>
                            <asp:Button ID="Button1" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear" TabIndex="7"></asp:Button>
                            <asp:Button ID="newEducationButton" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Grade"
                                runat="server" Text="Save" TabIndex="8" OnClick="newEducationButton_Click"></asp:Button>
                        </li>
                    </ul>
                    <div style="margin-top: 20px;">
                        <asp:GridView ID="EducationTrainingGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="EducationTrainingObjectDataSource" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Grade" SortExpression="Id" />
                                <asp:HyperLinkField Text="Delete" ControlStyle-CssClass="confirmNeeded" DataNavigateUrlFields="Id"
                                    DataNavigateUrlFormatString="DefineGrade.aspx?GradeId={0}&action=delete">
                                    <HeaderStyle Width="50px" />
                                </asp:HyperLinkField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="EducationNoDataLabel" style="font-size: 15px;">
                                        There are no grades for current job!</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="EducationTrainingObjectDataSource" runat="server" SelectMethod="ListByJobeCode"
                            TypeName="DAL.Mapper.GradeMapper">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="jobCode" QueryStringField="jobCode" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
            <div style="width: 100%; margin-top: 20px;">
                <h2 id="ExperienceTitle">
                    <font color="#707070"><strong>Define steps for grades</strong></font>
                </h2>
                <div id="ExperienceDiv">
                    <ul id="double2">
                        <li>
                            <label runat="server" for="GradeStepDropDownList" id="GradeStepLabel">
                                Grade:</label>
                            <asp:DropDownList ID="GradeStepDropDownList" runat="server" TabIndex="4" DataSourceID="GradeStepDataSource"
                                DataTextField="Id" DataValueField="Id" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="GradeStepDataSource" runat="server" SelectMethod="ListByJobeCode"
                                TypeName="DAL.Mapper.GradeMapper">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="jobCode" QueryStringField="jobCode" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:RequiredFieldValidator ID="GradeStepRequiredFieldValidator" ControlToValidate="GradeStepDropDownList"
                                Display="None" runat="server" ErrorMessage="Please select a grade." InitialValue=""
                                ValidationGroup="Step"></asp:RequiredFieldValidator>
                        </li>
                        <li class="second">
                            <label runat="server" for="StepTextBox" id="StepLabel">
                                Step:</label>
                            <asp:TextBox ID="StepTextBox" runat="server" TabIndex="15"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="StepRequiredFieldValidator" ControlToValidate="StepTextBox"
                                Display="None" runat="server" ErrorMessage="Please provide a name for step."
                                ValidationGroup="Step"></asp:RequiredFieldValidator>
                        </li>
                        <li>
                            <label runat="server" id="Label1">
                                &nbsp
                            </label>
                            <label runat="server" id="Label4">
                                &nbsp
                            </label>
                        </li>
                        <li class="second">
                            <label runat="server" id="Label2">
                                &nbsp
                            </label>
                            <asp:Button ID="Button2" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear" TabIndex="7"></asp:Button>
                            <asp:Button ID="Button3" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Step"
                                runat="server" Text="Save" TabIndex="8" OnClick="Button3_Click"></asp:Button>
                        </li>
                    </ul>
                    <div style="margin-top: 20px">
                        <asp:GridView ID="ExperienceGridView" runat="server" AutoGenerateColumns="False"
                            DataSourceID="ExperienceObjectDataSource" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Step" SortExpression="Id" />
                                <asp:HyperLinkField Text="Delete" ControlStyle-CssClass="confirmNeeded" DataNavigateUrlFields="Id, GradeId"
                                    DataNavigateUrlFormatString="DefineGrade.aspx?StepId={0}&GradeId={1}&action=delete">
                                    <HeaderStyle Width="50px" />
                                </asp:HyperLinkField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <label runat="server" id="ExperienceNoDataLabel" style="font-size: 15px;">
                                        You havent approved any leaves yet!</label>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ExperienceObjectDataSource" runat="server" SelectMethod="ListByGradeId"
                            TypeName="DAL.Mapper.StepMapper">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="GradeStepDropDownList" Name="gradeId" PropertyName="SelectedValue"
                                    Type="String" ConvertEmptyStringToNull="false" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
            <ul class="clearfix">
                <li>
                    <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                        OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                    <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Back"
                        TabIndex="18" OnClick="CancelButton_Click"></asp:Button></li>
            </ul>
        </div>
    </div>
</asp:Content>
