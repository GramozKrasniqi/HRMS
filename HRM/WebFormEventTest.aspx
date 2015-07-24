<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEventTest.aspx.cs"
    Inherits="HRM.WebFormEventTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/HRM/Scripts/jquery-1.8.3.js"></script>
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


        //This locale can also be set in js file and used for mulitlanguage
            scheduler.locale = {
                date: {
                    month_full: ["Janar", "Shkurt", "Mars", "Prill", "Maj", "Qershor", "July", "August", "September", "October", "November", "December"],
                    month_short: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                    day_full: ["E diel", "E hanë", "E martë", "E mërkurë", "E enjte", "E premte", "E shtunë"],
                    day_short: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"]
                },
                labels: {
                    dhx_cal_today_button: "Sot",
                    day_tab: "Dita",
                    week_tab: "Java",
                    month_tab: "Muaji",
                    new_event: "New event",
                    icon_save: "Save",
                    icon_cancel: "Cancel",
                    icon_details: "Details",
                    icon_edit: "Edit",
                    icon_delete: "Delete",
                    confirm_closing: "", //Your changes will be lost, are your sure?
                    confirm_deleting: "Event will be deleted permanently, are you sure?",
                    section_description: "Description",
                    section_time: "Time period"
                }
            }


            scheduler.config.multi_day = true;
            scheduler.config.xml_date = "%Y-%m-%d %H:%i";
            scheduler.config.dblclick_create = false;
            scheduler.config.drag_move = false;
            scheduler.init("scheduler_here", new Date(), "month");
            scheduler.load("/HRM/events.xml");

            scheduler.showLightbox = function (id) {
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    </form>
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
           <%-- <div class="dhx_cal_tab" name="day_tab" style="right: 204px;">
            </div>
            <div class="dhx_cal_tab" name="week_tab" style="right: 140px;">
            </div>--%>
            <div class="dhx_cal_tab" name="month_tab" style="right: 76px;">
            </div>
        </div>
        <div class="dhx_cal_header">
        </div>
        <div class="dhx_cal_data">
        </div>
    </div>
</body>
</html>
