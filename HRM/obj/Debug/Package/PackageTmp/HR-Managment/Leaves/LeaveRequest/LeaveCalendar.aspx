<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LeaveCalendar.aspx.cs" Inherits="HRM.HR_Managment.Leaves.LeaveRequest.LeaveCalendar" %>

<%@ Register TagPrefix="ECalendar" Namespace="HRM" Assembly="HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/HRM/Scripts/dhtmlxscheduler.js" type="text/javascript"></script>
    <link href="/HRM/Scripts/dhtmlxscheduler.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {
            height: 100% !important;
            padding: 0px !important;
            margin: 0px !important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            scheduler.init("scheduler_here", new Date(2010, 6, 1), "month");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="scheduler_here" class="dhx_cal_container" style='width: 100%; height: 100%;'>
        <div class="dhx_cal_navline">
            <div class="dhx_cal_prev_button">
                &nbsp;</div>
            <div class="dhx_cal_next_button">
                &nbsp;</div>
            <div class="dhx_cal_today_button">
            </div>
            <div class="dhx_cal_date">
            </div>
            <div class="dhx_cal_tab" name="day_tab" style="right: 204px;">
            </div>
            <div class="dhx_cal_tab" name="week_tab" style="right: 140px;">
            </div>
            <div class="dhx_cal_tab" name="month_tab" style="right: 76px;">
            </div>
        </div>
        <div class="dhx_cal_header">
        </div>
        <div class="dhx_cal_data">
        </div>
    </div>
</asp:Content>
