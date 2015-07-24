<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="BatchContractChange.aspx.cs" Inherits="HRM.HR_Managment.BatchOperations.BatchContractChange" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/HRM/Scripts/jsTree/jquery.jstree.js" language="javascript" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#demo").jstree({
                "json_data": {
                    "ajax": {
                        "type": "POST",
                        "dataType": "json",
                        "contentType": "application/json;",
                        "url": "BatchContractChange.aspx/GetAllNodes",
                        "data": function (node) {
                            if (node == -1) {
                                if ($("#ctl00_ContentPlaceHolder1_ContractTemplateDropDownList").children("option:selected").val() == "") {
                                    return '{ "operation" : "get_children", "id" : 0, "isOrganizationUnit" : 0, "contractTemplateId" : 0 }'
                                }
                                return '{ "operation" : "get_children", "id" : 0, "isOrganizationUnit" : 0, "contractTemplateId" : ' + $("#ctl00_ContentPlaceHolder1_ContractTemplateDropDownList").children("option:selected").val() + ' }'
                            }
                            else {
                                if ($("#ctl00_ContentPlaceHolder1_ContractTemplateDropDownList").children("option:selected").val() == "") {
                                    return '{ "operation" : "get_children", "id" : ' + node.attr('id') + ', "isOrganizationUnit" : ' + node.attr('isOrganizationUnit') + ', "contractTemplateId" : 0 }'
                                }
                                return '{ "operation" : "get_children", "id" : ' + node.attr('id') + ', "isOrganizationUnit" : ' + node.attr('isOrganizationUnit') + ', "contractTemplateId" : ' + $("#ctl00_ContentPlaceHolder1_ContractTemplateDropDownList").children("option:selected").val() + ' }'
                            }
                        },
                        "success": function (retval) {
                            return retval.d;
                        }
                    }
                },
                "plugins": ["themes", "json_data", 'checkbox', "types"]
            }).bind('check_node.jstree', function (e, data) {
                data.inst.open_all(data.rslt.obj, true);
                submit();
            }).bind('uncheck_node.jstree', function (e, data) {
                data.inst.close_all(data.rslt.obj, true);
                submit();
            }).bind("open_node.jstree close_node.jstree", function (e) {
                submit();
            });


            $('#ctl00_ContentPlaceHolder1_EmployeeChangeJobDetailsHyperLink').click(function () {
                $("#demo").jstree("check_all").bind('check_node.jstree', function (e, data) {
                });
                $("#demo").jstree('open_all');
            });

            $('#ctl00_ContentPlaceHolder1_EmployeeDismissHyperLink').click(function () {
                $("#demo").jstree("uncheck_all").bind('uncheck_node.jstree', function (e, data) {
                });
                $("#demo").jstree('close_all');
            });

        });

        function submit() {
            var checked_ids = [];
            $("#demo").jstree("get_checked", null, true).each(function () {
                checked_ids.push(this.id);
                return true
            });
            //setting to hidden field
            document.getElementById('ctl00_ContentPlaceHolder1_jsfields').value = checked_ids.join(",");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2 style="border-top: 1px dotted #CCC; padding-top: 10px; border-bottom: none;">
                <font color="#707070"><strong>New contract or amandment (Step 1): </strong></font>
                <em>Select the method type to commit the changes: </em>
            </h2>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow" AutoPostBack="True">
                <asp:ListItem Value="1" Selected="True">New contract</asp:ListItem>
                <asp:ListItem Value="2">Amandment</asp:ListItem>
            </asp:RadioButtonList>
            <h2 style="border-top: 1px dotted #CCC; padding-top: 10px; margin-top: 10px; border-bottom: none;">
                <font color="#707070"><strong>Mappings of new contract or amandment (Step 2): </strong>
                </font><em>Map the current templates with new templates: </em>
            </h2>
            <ul id="doubleTemplate" runat="server" class="double">
                <li>
                    <label runat="server" for="ContractTemplateDropDownList" id="ContractTemplateLabel">
                        Contract template:</label>
                    <asp:DropDownList ID="ContractTemplateDropDownList" runat="server" TabIndex="7">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ContractTemplateRequiredFieldValidator" ControlToValidate="ContractTemplateDropDownList"
                        Display="None" runat="server" ErrorMessage="Please select a contract template."
                        InitialValue=""></asp:RequiredFieldValidator>
                    <ajaxToolkit:CascadingDropDown ID="ContractTemplateCascadingDropDown" runat="server"
                        ServicePath="" Category="" ServiceMethod="" TargetControlID="ContractTemplateDropDownList"
                        ContextKey="" PromptText="Please select" />
                </li>
            </ul>
            <input type="hidden" name="jsfields" id="jsfields" value="" runat="server" />
            <h2 style="border-top: 1px dotted #CCC; padding-top: 10px; margin-top: 10px; border-bottom: none;">
                <font color="#707070"><strong>Select employees (Step 3): </strong></font><em>Please
                    select the employees to commit the changes. </em>
                <asp:HyperLink ID="EmployeeChangeJobDetailsHyperLink" runat="server" CssClass="fltlft employeeLink">Check all</asp:HyperLink>
                <asp:HyperLink ID="EmployeeDismissHyperLink" runat="server" CssClass="fltlft employeeLink employeeLinkLast">Uncheck all</asp:HyperLink>
            </h2>
            <div id="demo" style="float: left; clear: both; margin-top: 15px;">
            </div>
            <ul class="clearfix">
                <li>
                    <%-- <input type="submit" id="ctl00_ContentPlaceHolder1_ProceedButton" class="right login_btn"
                        value="Next »" onclick="this.disabled = true; submit(); __doPostBack('ProceedButton_Click','')" />--%>
                    <asp:Button ID="ProceedButton" CssClass="right login_btn" runat="server" Text="Next »"
                        OnClick="ProceedButton_Click" TabIndex="19"></asp:Button>
                    <asp:Button ID="BackButton" CssClass="right login_btn" runat="server" Text="Back">
                    </asp:Button>
                    <asp:Button ID="CancelButton" CssClass="right login_btn" runat="server" Text="Cancel">
                    </asp:Button>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
