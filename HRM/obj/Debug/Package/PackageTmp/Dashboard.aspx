<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="HRM.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <div class="fltlft">
                <div class="cont_hdr fltlft">
                    <div class="cont_hdr_mdl fltlft">
                        My personal information
                    </div>
                    <div class="clear">
                    </div>
                    <div class="latest">
                        <div class="mrgn_lft">
                            <p>
                                Name & Surname: <u><i>
                                    <asp:Label ID="NameSurnameLabel" runat="server"></asp:Label></i></u>
                            </p>
                            <p>
                                Personal No: <u><i>
                                    <asp:Label ID="PersonalNoLabel" runat="server"></asp:Label></i></u>
                            </p>
                            <p>
                                Employee No: <u><i>
                                    <asp:Label ID="EmployeeNoLabel" runat="server"></asp:Label></i></u>
                            </p>
                            <p>
                                Username: <u><i>
                                    <asp:Label ID="UsernameLabel" runat="server"></asp:Label></i></u>
                            </p>
                            <p>
                                Job: <u><i>
                                    <asp:Label ID="JobLabel" runat="server"></asp:Label></i></u>
                            </p>
                            <p>
                                Organization Unit: <u><i>
                                    <asp:Label ID="OrganizationUnitLabel" runat="server"></asp:Label></i></u>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="cont_hdr fltlft">
                    <div class="cont_hdr_mdl fltlft">
                        Reminders
                    </div>
                    <div class="clear">
                    </div>
                    <div class="latest">
                        <div class="mrgn_lft">
                            <p>
                                <a runat="server" id="ContractExpireUrl">(<asp:Label ID="ContractExpireCountLabel"
                                    runat="server"></asp:Label>) Contract will expire soon !</a>
                            </p>
                            <p>
                                <a runat="server" id="EmployeesWithoutContractUrl">(<asp:Label ID="EmployeeWithoutContractCountLabel"
                                    runat="server"></asp:Label>) Employees are without contracts !</a>
                            </p>
                            <p>
                                <a runat="server" id="LeaveRequestsUrl">(<asp:Label ID="LeaveRequestsCountLabel"
                                    runat="server"></asp:Label>) Leave requests are waiting for your approval !</a>
                            </p>
                            <%--<p>
                                 <a runat="server" id="A1">(<asp:Label ID="Label1"
                                    runat="server">) Leave requests are waiting for your approval !</asp:Label></a>
                            </p> Complaint needs your attention!--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
