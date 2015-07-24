<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="HRM.HR_Managment.Administration.Role.Edit" %>

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
                        "url": "Edit.aspx/GetAllNodes",
                        "data": function (node) {
                            if (node == -1) {
                                return '{ "operation" : "get_children", "id" : 0, "isOrganizationUnit" : 0 , "roleId" : ' + $("#ctl00_ContentPlaceHolder1_roleId")[0].value + ' }'
                            }
                            else {
                                return '{ "operation" : "get_children", "id" : ' + node.attr('id') + ', "isOrganizationUnit" : ' + node.attr('isOrganizationUnit') + ', "roleId" : ' + $("#ctl00_ContentPlaceHolder1_roleId")[0].value + ' }'
                            }
                        },
                        "success": function (retval) {
                            $("li[selected='selected']").removeClass("jstree-unchecked").addClass("jstree-undetermined");
                            submit();
                            return retval.d;
                        }
                    }
                },
                "plugins": ["themes", "json_data", 'checkbox', "types"]
            }).bind('check_node.jstree', function (e, data) {
                //                data.inst.open_all(data.rslt.obj, true);
                submit();
            }).bind('uncheck_node.jstree', function (e, data) {
                //                data.inst.close_all(data.rslt.obj, true);
                submit();
            }).bind('loaded.jstree', function (e, data) {
                // invoked after jstree has loaded
                $("#demo").jstree('open_all');
            });

            $('#ctl00_ContentPlaceHolder1_EmployeeChangeJobDetailsHyperLink').click(function () {
                $("#demo").jstree("check_all").bind('check_node.jstree', function (e, data) {
                });
            });

            $('#ctl00_ContentPlaceHolder1_EmployeeDismissHyperLink').click(function () {
                $("#demo").jstree("uncheck_all").bind('uncheck_node.jstree', function (e, data) {
                });
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
            <input type="hidden" name="jsfields" id="jsfields" value="" runat="server" />
            <input type="hidden" name="roleId" id="roleId" value="" runat="server" />
            <h2 style="border-top: 1px dotted #CCC; padding-top: 10px; margin-top: 10px; border-bottom: none;">
                <font color="#707070"><strong>Edit role: </strong></font><em></em>
            </h2>
            <ul id="doubleTemplate" runat="server" class="double">
                <li>
                    <label runat="server" for="RoleNameTextBox" id="RoleNameLabel">
                        Role name:</label>
                    <asp:TextBox ID="RoleNameTextBox" runat="server" TabIndex="7">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RoleNameRequiredFieldValidator" ControlToValidate="RoleNameTextBox"
                        Display="None" runat="server" ErrorMessage="Please type the role name." InitialValue=""></asp:RequiredFieldValidator>
                </li>
            </ul>
            <asp:HyperLink ID="EmployeeChangeJobDetailsHyperLink" runat="server" CssClass="fltlft employeeLink">Check all</asp:HyperLink>
            <asp:HyperLink ID="EmployeeDismissHyperLink" runat="server" CssClass="fltlft employeeLink employeeLinkLast">Uncheck all</asp:HyperLink>
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
