<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Details.aspx.cs" Inherits="HRM.HR_Managment.Definition.AmandmentTemplate.Details" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/GridView.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;" id="contractVersion" runat="server">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Amandment template details </strong></font><em>This shows
                    the details of amandment template: </em>
            </h2>
            <div style="margin-bottom: 30px;">
                <ul id="double2">
                    <li><b>
                        <label runat="server" id="TextAmandamentTemplateTitleLabel">
                            Template title:</label></b> <i>
                                <label runat="server" id="AmandamentTemplateTitleLabel">
                                    Template title:</label></i> </li>
                </ul>
            </div>
             
        </div>
    </div>
</asp:Content>
