<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ContractDetails.aspx.cs" Inherits="HRM.HR_Managment.Employee.ContractDetails" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Styles/CalendarExtenderStyle.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/GridView.css" />
    <script type="text/javascript">
        $(document).ready(function () {

            $('#ctl00_ContentPlaceHolder1_ContractContentShowHyperLink').click(function () {
                if ($('#ctl00_ContentPlaceHolder1_ContractContentShowHyperLink').text() == 'Hide') {
                    $('#ctl00_ContentPlaceHolder1_generateContract').fadeOut('slow');
                    $('#ctl00_ContentPlaceHolder1_ContractContentShowHyperLink').text('Show');
                }
                else {
                    $('#ctl00_ContentPlaceHolder1_generateContract').fadeIn('slow');
                    $('#ctl00_ContentPlaceHolder1_ContractContentShowHyperLink').text('Hide');
                    $('html,body').animate({
                        scrollTop: $('#ContractContentTitle').offset().top
                    },
                    'slow');
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wizard" style="margin: 0px; width: auto; height: auto;">
        <div class="page" style="width: 93%;">
            <h2>
                <font color="#707070"><strong>Contract information details: </strong></font>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="fltrht linkWithouSubText employeeLinkLast">Cancel extend</asp:HyperLink>
                <asp:HyperLink ID="ContractExtendHyperLink" runat="server" CssClass="fltrht linkWithouSubText">Extend</asp:HyperLink>
            </h2>
            <div class="fltlft" style="margin-bottom: 20px; width: 100%;">
                <div class="fltlft">
                    <ul id="quad">
                        <li><b>
                            <label runat="server" id="TextContractNumberLabel">
                                Contract number:</label>
                        </b><i>
                            <label runat="server" id="ContractNumberLabel">
                                1 / KPA / 23012014</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextContractTypeLabel">
                                Contract type:</label>
                        </b><i>
                            <label runat="server" id="ContractTypeLabel">
                                KPA Contract</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextOrganizationaUnitLabel">
                                Organizational unit:</label>
                        </b><i>
                            <label runat="server" id="OrganizationaUnitLabel">
                                FORCA</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextJobCodeLabel">
                                Job code:</label></b> <i>
                                    <label runat="server" id="JobCodeLabel">
                                        EX-1</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextJobTitleLabel">
                                Job title:</label>
                        </b><i>
                            <label runat="server" id="JobTitleLabel">
                                Executive</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextGradeIdLabel">
                                Grade:</label>
                        </b><i>
                            <label runat="server" id="GradeIdLabel">
                                A1</label></i></li>
                        <li><b>
                            <label runat="server" id="TextGradeKCBLabel">
                                Grade KCB:</label>
                        </b><i>
                            <label runat="server" id="GradeKCBLabel">
                                5.5</label></i> </li>
                        <li><b>
                            <label runat="server" id="TextGradeEntryLabel">
                                Grade entry:</label>
                        </b><i>
                            <label runat="server" id="GradeEntryLabel">
                                555.00</label></i></li>
                        <li><b>
                            <label runat="server" id="TextStepIdLabel">
                                Step:</label>
                        </b><i>
                            <label runat="server" id="StepLabel">
                                S3</label></i></li>
                        <li><b>
                            <label runat="server" id="TextStepEntryLabel">
                                Step entry:</label>
                        </b><i>
                            <label runat="server" id="StepEntryLabel">
                                55.00</label></i></li>
                        <li><b>
                            <label runat="server" id="TextGrossValueLabel">
                                Gross value:</label>
                        </b><i>
                            <label runat="server" id="GrossValueLabel">
                                605.00</label></i></li>
                        <li><b>
                            <label runat="server" id="TextOfficiallyApprovedDateLabel">
                                Officially approved:</label>
                        </b><i>
                            <label runat="server" id="OfficiallyApprovedDateLabel">
                                02.01.2010</label></i></li>
                        <li><b>
                            <label runat="server" id="TextStartDateLabel">
                                Start date:</label>
                        </b><i>
                            <label runat="server" id="StartDateLabel">
                                02.01.2010</label></i></li>
                        <li><b>
                            <label runat="server" id="TextEndDateLabel">
                                End date:</label>
                        </b><i>
                            <label runat="server" id="EndDateLabel">
                                -</label></i></li>
                        <li><b>
                            <label runat="server" id="TextContractStatusLabel">
                                Contract status:</label>
                        </b><i>
                            <label runat="server" id="ContractStatusLabel">
                                Active</label></i></li>
                    </ul>
                </div>
            </div>
            <div style="width: 100%; clear: both;">
                <h2 id="ContractContentTitle">
                    <font color="#707070"><strong>Contract content</strong></font>
                    <asp:HyperLink ID="ContractContentShowHyperLink" runat="server" CssClass="fltrht employeeLinkLast linkWithouSubText">Hide</asp:HyperLink>
                </h2>
                <div runat="server" id="generateContract">
                    <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="500" BasePath="~/ckeditor"
                        ReadOnly="true">
                    </CKEditor:CKEditorControl>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
