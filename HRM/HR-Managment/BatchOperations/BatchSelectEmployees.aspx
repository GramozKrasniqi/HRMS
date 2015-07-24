<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BatchSelectEmployees.aspx.cs" Inherits="HRM.HR_Managment.BatchOperations.BatchSelectEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../../Scripts/json2.min.js" type="text/javascript"></script>--%>
    <%--<script src="../../Scripts/jsTree//_lib/jquery.js" type="text/javascript"></script>--%>
    <script src="../../Scripts/jsTree/jquery.jstree.js" language="javascript" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#demo").jstree({
                "json_data": {
                    "ajax": {
                        "type": "POST",
                        "dataType": "json",
                        "contentType": "application/json;",
                        "url": "BatchSelectEmployees.aspx/GetAllNodes",
                        "data": function (node) {
                            if (node == -1) {
                                return '{ "operation" : "get_children", "id" : 0, "isOrganizationUnit" : 0}'
                            }
                            else {
                                return '{ "operation" : "get_children", "id" : ' + node.attr('id') + ', "isOrganizationUnit" : ' + node.attr('isOrganizationUnit') + '}'
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
            }).bind('uncheck_node.jstree', function (e, data) {
                data.inst.close_all(data.rslt.obj, true);
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

            $('#ctl00_ContentPlaceHolder1_HyperLink1').click(function () {
                submit();
            });

        });

        function submit() {
            var checked_ids = [];
            $("#demo").jstree("get_checked", null, true).each(function () {
                checked_ids.push(this.id);
            });
            //setting to hidden field
            document.getElementById('jsfields').value = checked_ids.join(",");
        }  

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>
            <input type="hidden" name="jsfields" id="jsfields" value="" />
            <div id="wizard" style="margin: 0px; height: auto; width: auto;">
                <div class="page" style="width: 93%;">
                    <div id="dialog-form">
                    </div>
                    <h2>
                        <font color="#707070"><strong>Select employees: </strong></font><em>Please select the
                            employees to commit the changes. </em>
                        <asp:HyperLink ID="EmployeeChangeJobDetailsHyperLink" runat="server" CssClass="fltlft employeeLink">Check all</asp:HyperLink>
                        <asp:HyperLink ID="EmployeeDismissHyperLink" runat="server" CssClass="fltlft employeeLink employeeLinkLast">Uncheck all</asp:HyperLink>
                    </h2>
                    <div id="demo" style="float: left; clear: both; margin-top: 20px;">
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function WebForm_OnSubmit() {
            submit();
        }
    </script>
</asp:Content>
