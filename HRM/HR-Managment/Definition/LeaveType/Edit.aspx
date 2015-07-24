<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="HRM.HR_Managment.Definition.LeaveType.Edit" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/HRM/Scripts/defaultText.js"></script>
    <script type="text/javascript" src="/HRM/Scripts/QueryString.js"></script>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
    <script type="text/javascript" src="/HRM/Scripts/ConfirmNeeded.js"></script>
    <style type="text/css">

        .modalBackground
        {
            width: 100%;
            height: 100%;
            background-color: #EBEBEB;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .ModalWindow
        {
            border: solid 1px #c0c0c0;
            background: #f0f0f0;
            padding: 0px;
            position: absolute;
            top: -1000px;
            text-align: center;
            vertical-align: middle;
        }
        .confirm
        {
            background-color: White;
            padding: 10px;
            width: 370px;
        }
        
        .confirmTextContainer
        {
            margin-bottom: 15px;
        }
        
        .confirm ul li
        {
            float: none !important;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Leave Types: </strong></font><em>Please
                    enter leave type information: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <ul id="double">
                    <li>
                        <label runat="server" for="TitleTextBox" id="TitleLabel">
                            Title:</label>
                        <asp:TextBox ID="TitleTextBox" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" ControlToValidate="TitleTextBox"
                            Display="None" ValidationGroup="Form1" runat="server" ErrorMessage="Please enter title."></asp:RequiredFieldValidator>
                    </li>

                    <li class="second">
                        <label runat="server" for="DescriptionTextBox" id="DescriptionLabel">
                            Description:</label>
                        <asp:TextBox ID="DescriptionTextBox" TextMode="MultiLine" runat="server" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator" ControlToValidate="DescriptionTextBox"
                            Display="None" ValidationGroup="Form1" runat="server" ErrorMessage="Please enter the personal number."></asp:RequiredFieldValidator>
                    </li>
                    <li />
                    <li class="second">
                            <label runat="server" id="Label1">
                                &nbsp
                            </label>
                            <asp:Button ID="ClearFirstFormButton" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear"></asp:Button>
                            <asp:Button ID="SaveLeaveType" ToolTip="Save" CssClass="secondaryButton" ValidationGroup="Form1"
                                runat="server" Text="Save" OnClick="SaveLeaveType_Click"></asp:Button>
               
                    </li>
                    <li style="width:100%">
                        <h2>&nbsp;</h2>
                    </li>
                    <li>
                        <label runat="server" for="TypeDropDownList" id="TypeLabel">
                            Type:</label>
                        <asp:DropDownList ID="TypeDropDownList" runat="server" TabIndex="7">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="TypeRequiredFieldValidator" ControlToValidate="TypeDropDownList"
                            Display="None" runat="server" ValidationGroup="Form2" ErrorMessage="Please select a Type." InitialValue=""></asp:RequiredFieldValidator></li>
                    <ajaxToolkit:CascadingDropDown ID="TypeCascadingDropDown" runat="server" ServicePath="~/HRMWebServices.asmx"
                        Category="Type" ServiceMethod="GetPaymentTypes" TargetControlID="TypeDropDownList"
                        ContextKey="" PromptText="Please select" />
                    <li class="second">
                        <label runat="server" for="NoDaysTextBox" id="NoDaysLabel">
                            Number of days:</label>
                        <asp:TextBox ID="NoDaysTextBox" runat="server" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NoDaysRequiredFieldValidator" ValidationGroup="Form2" ControlToValidate="NoDaysTextBox"
                            Display="None" runat="server" ErrorMessage="Please enter the number of days."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationExpression="\d+" ID="NoDaysRegularExpressionValidator" ValidationGroup="Form2" ControlToValidate="NoDaysTextBox"
                            Display="None" runat="server"  ErrorMessage="Please enter a valid percentage." ></asp:RegularExpressionValidator>
                         
                    </li>
                    <li>
                        <label runat="server" for="PaymentPercentageTextBox" id="PaymentPercentageLabel">
                            Payment percentage:</label>
                        <asp:TextBox ID="PaymentPercentageTextBox" runat="server" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PaymentPercentageRequiredFieldValidator" ControlToValidate="PaymentPercentageTextBox"
                            Display="None" runat="server" ValidationGroup="Form2" ErrorMessage="Please enter the payment percentage."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationExpression="[-+]?[0-9]*\.?[0-9]+" ID="RegularExpressionValidator1" ValidationGroup="Form2" ControlToValidate="PaymentPercentageTextBox"
                            Display="None" runat="server"  ErrorMessage="Please enter a valid number of days." ></asp:RegularExpressionValidator>
                    </li>
                    <li class="second">
                            <label runat="server" id="empty">
                                &nbsp
                            </label>
                            <asp:Button ID="ClearButton" CssClass="secondaryButton firstsecondaryButton" ToolTip="Clear"
                                runat="server" Text="Clear"></asp:Button>
                            <asp:Button ID="AddPaymentTypeButton" ToolTip="Add" CssClass="secondaryButton" ValidationGroup="Form2"
                                runat="server" Text="Add" OnClick="AddPaymentTypeButton_Click"></asp:Button>
                    </li>
                </ul>
            </div>
            <div style="width: 100%">
                <asp:GridView ID="LeaveTypeGridView" runat="server" AutoGenerateColumns="False"
                    DataSourceID="LeaveTypeObjectDataSource" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="NoOfDays" HeaderText="No Of days" SortExpression="NoOfDays" />
                        <asp:BoundField DataField="PaymentPercentage" HeaderText="Payment Percetage" SortExpression="PaymentPercentage" />
                        <asp:TemplateField HeaderText="Gender">
                          <ItemTemplate><%#(Entities.LeaveNameType)Eval("LeaveNameType")%></ItemTemplate>
                        </asp:TemplateField>
                         <asp:HyperLinkField  Text="Delete" ControlStyle-CssClass="confirmNeeded" DataNavigateUrlFields="Id, LeaveTypeId"
                             DataNavigateUrlFormatString="Edit.aspx?LeaveTypeNameId={0}&action=delete&LeaveTypeId={1}">
                            <HeaderStyle Width="50px" />
                        </asp:HyperLinkField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <label runat="server" id="NoLeaveTypeLabel" style="font-size: 15px;">
                                No payment types found! Insert and it will be shown here.</label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
            <asp:ObjectDataSource ID="LeaveTypeObjectDataSource" runat="server" SelectMethod="List"
                    TypeName="DAL.Mapper.LeaveTypeLevelMapper" DeleteMethod="DeleteLeaveType">
                    <DeleteParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="Id" QueryStringField="LeaveTypeId" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="LeaveTypeId" QueryStringField="LeaveTypeId" />
                    </SelectParameters>
                </asp:ObjectDataSource>
        </div>
         <asp:Panel ID="popup" runat="server" CssClass="ModalWindow" Style="display: none;">
            <div class="confirm">
                <div class="confirmTextContainer">
                    <b>
                        <asp:Label Text="Are you sure you want to make the data inactive?" ID="popupMessage" runat="server"
                            CssClass="confirmHeader"></asp:Label></b>
                    <br />
                    <i>
                        <asp:Label Text="If you make this record inactive this will not be shown on other forms."
                            ID="Label2" runat="server" CssClass="confirmBody"></asp:Label></i>
                </div>
                <ul>
                    <li>
                        <asp:Button ID="OkButton" ToolTip="Save" CssClass="secondaryButton" runat="server"
                            Text="Proceed"></asp:Button>
                    </li>
                    <li>
                        <asp:Button ID="CancelButton" CssClass="secondaryButton" ToolTip="Cancel" runat="server"
                            Text="Cancel"></asp:Button>
                    </li>
                </ul>
            </div>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server" BackgroundCssClass="modalBackground"
            OkControlID="OkButton" OnOkScript="okClick();" PopupControlID="popup" 
            CancelControlID="CancelButton" OnCancelScript="cancelClick();" 
            TargetControlID="dummy">
        </asp:ModalPopupExtender>
        <asp:Button ID="dummy" style="display:none;" runat="server" />

        <script type="text/javascript">
            $('.confirmNeeded').attr('onclick', 'showConfirm(this);return false;');
        </script>
    </div>
</asp:Content>
