<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeReports.aspx.cs" Inherits="HRM.HR_Managment.Reports.EmployeeReports" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/basic.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../Styles/GridView.css" />
    <script type="text/javascript" src="../../Scripts/enhance.js"></script>
    <script type="text/javascript" src="../../Scripts/printThis/printThis.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            // Run capabilities test
            enhance({
                loadScripts: [
				            '../../Scripts/excanvas.js',
				            '../../Scripts/visualize.jQuery.js'
			            ],
                loadStyles: [
				            '../../Styles/visualize.css',
				            '../../Styles/visualize-light.css'
			            ]
            });

            $('#ctl00_ContentPlaceHolder1_ReportEmployeeByCountryPrintHyperLink').click(function () {
                $("#contPage").printThis({
                    debug: false,
                    printContainer: true,
                    importCSS: true
                });
            });

            $('#ctl00_ContentPlaceHolder1_ReportEmployeeByCountryShowHideHyperLink').click(function () {
                if ($('#ctl00_ContentPlaceHolder1_ReportEmployeeByCountryShowHideHyperLink').text() == 'Hide') {
                    $('#ReportEmployeeByCountryDiv').fadeOut('slow');
                    $('#ctl00_ContentPlaceHolder1_ReportEmployeeByCountryShowHideHyperLink').text('Show');
                }
                else {

                    $('#ReportEmployeeByCountryDiv').fadeIn('slow');
                    $('#ctl00_ContentPlaceHolder1_ReportEmployeeByCountryShowHideHyperLink').text('Hide');
                    $('html,body').animate({
                        scrollTop: $('#EmployeesCountryReportTitle').offset().top
                    },
                    'slow');

                    $('#TableEmployeeByCountry').visualize({ type: 'pie', height: '300px', width: '800px' });
                }
            });

            $('#ctl00_ContentPlaceHolder1_ReportEmployeeByNationalitiesShowHideHyperLink').click(function () {
                if ($('#ctl00_ContentPlaceHolder1_ReportEmployeeByNationalitiesShowHideHyperLink').text() == 'Hide') {
                    $('#ReportEmployeeByNationalitiesDiv').fadeOut('slow');
                    $('#ctl00_ContentPlaceHolder1_ReportEmployeeByNationalitiesShowHideHyperLink').text('Show');
                }
                else {
                    $('#ReportEmployeeByNationalitiesDiv').fadeIn('slow');
                    $('#ctl00_ContentPlaceHolder1_ReportEmployeeByNationalitiesShowHideHyperLink').text('Hide');
                    $('html,body').animate({
                        scrollTop: $('#EmployeesNationalityReportTitle').offset().top
                    },
                    'slow');

                    $('#TableEmployeeByNationality').visualize({ type: 'pie', height: '300px', width: '800px' });
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" id="contPage" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2 id="EmployeesCountryReportTitle">
                <font color="#707070"><strong>Employees countries report </strong></font>
                <asp:HyperLink ID="ReportEmployeeByCountryShowHideHyperLink" NavigateUrl="#" runat="server"
                    CssClass="fltrht employeeLink employeeLinkLast">Show</asp:HyperLink>
                <asp:HyperLink ID="ReportEmployeeByCountryPrintHyperLink" runat="server" CssClass="fltrht employeeLink">Print</asp:HyperLink>
                <em>This report shows the percentage of the countries our employees belong </em>
            </h2>
            <div class="report" id="ReportEmployeeByCountryDiv" style="display: none;">
                <table id="TableEmployeeByCountry" style="display: none;">
                    <thead>
                        <tr>
                            <td>
                            </td>
                            <th scope="col">
                                Employee number
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="firstrow">
                            <th scope="row" class="firstcolumn">
                                Albania
                            </th>
                            <td>
                                10
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Afganistan
                            </th>
                            <td>
                                2
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Belgium
                            </th>
                            <td>
                                5
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Germany
                            </th>
                            <td>
                                8
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Hungary
                            </th>
                            <td>
                                9
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Kosovo
                            </th>
                            <td>
                                13
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Serbia
                            </th>
                            <td>
                                5
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <h2 id="EmployeesNationalityReportTitle">
                <font color="#707070"><strong>Employees nationalities report </strong></font>
                <asp:HyperLink ID="ReportEmployeeByNationalitiesShowHideHyperLink" NavigateUrl="#"
                    runat="server" CssClass="fltrht employeeLink employeeLinkLast">Show</asp:HyperLink>
                <asp:HyperLink ID="ReportEmployeeByNationalitiesPrintHyperLink" runat="server" CssClass="fltrht employeeLink">Print</asp:HyperLink>
                <em>This report shows the percentage of the nationalities our employees belong </em>
            </h2>
            <div class="report" id="ReportEmployeeByNationalitiesDiv">
                <table id="TableEmployeeByNationality" style="display: none;">
                    <thead>
                        <tr>
                            <td>
                            </td>
                            <th scope="col">
                                Employee number
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="firstrow">
                            <th scope="row" class="firstcolumn">
                                Albanian
                            </th>
                            <td>
                                10
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Serbian
                            </th>
                            <td>
                                2
                            </td>
                        </tr>
                        <tr>
                            <th scope="row" class="firstcolumn">
                                Other
                            </th>
                            <td>
                                5
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <asp:PieChart ID="pieChart1" runat="server" ChartHeight="300" ChartWidth="450" ChartTitle="Widget Production in the world"
                ChartTitleColor="#0E426C">
                <PieChartValues>
                    <ajaxToolkit:PieChartValue Category="United States" Data="45" PieChartValueColor="#6C1E83"
                        PieChartValueStrokeColor="black" />
                    <ajaxToolkit:PieChartValue Category="Europe" Data="25" PieChartValueColor="#D08AD9"
                        PieChartValueStrokeColor="black" />
                    <ajaxToolkit:PieChartValue Category="Asia" Data="17" PieChartValueColor="#6586A7"
                        PieChartValueStrokeColor="black" />
                    <ajaxToolkit:PieChartValue Category="Australia" Data="13" PieChartValueColor="#0E426C"
                        PieChartValueStrokeColor="black" />
                </PieChartValues>
                </asp:PieChart>
        </div>
    </div>
</asp:Content>
