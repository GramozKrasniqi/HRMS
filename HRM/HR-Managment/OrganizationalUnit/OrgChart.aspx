<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OrgChart.aspx.cs" Inherits="HRM.HR_Managment.OrganizationalUnit.OrgChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type='text/javascript'>
        google.load('visualization', '1', { packages: ['orgchart'] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Name');
            data.addColumn('string', 'Manager');
            data.addColumn('string', 'ToolTip');
            data.addRows([
          [{ v: 'Mike', f: 'Mike<div style="color:red; font-style:italic">President</div>' }, '', 'The President'],
          [{ v: 'Jim', f: 'Jim<div style="color:red; font-style:italic">Vice President</div>' }, 'Mike', 'VP'],
          ['Alice', 'Mike', ''],
          ['Bob', 'Jim', 'Bob Sponge'],
          ['Carol', 'Bob', '']
        ]);
            var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
            chart.draw(data, { allowHtml: true });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id='chart_div'></div>
</asp:Content>
