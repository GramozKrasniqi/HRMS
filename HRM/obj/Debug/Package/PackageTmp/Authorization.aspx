<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs"
    Inherits="HRM.Authorization1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/HRM/Styles/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/Form.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <div class="clear">
            </div>
            <div id="portlets">
                <div id="left" class="column">
                    <div class="portlet-header fixed">
                    </div>
                    <div class="portlet-content nopadding">
                        <h3>
                            <asp:Label Text="Unauthorized access: " runat="server" ID="UserLabel"></asp:Label></h3>
                        <asp:Label Text="You are not allowed to access this page. Please contact IT departament for more information."
                            runat="server" ID="Label4"></asp:Label>
                        <asp:HyperLink ID="UserHyperLink" NavigateUrl="#" runat="server">Click here to go back to HR dashboard</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
