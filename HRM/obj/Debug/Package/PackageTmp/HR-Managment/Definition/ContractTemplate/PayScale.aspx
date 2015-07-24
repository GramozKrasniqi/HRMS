<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PayScale.aspx.cs" Inherits="HRM.HR_Managment.Definition.ContractTemplate.PayScale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/HierarchyGridView.css" />
    <style type="text/css">
        #mask, #mask2
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 1;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        function ShowPopup2() {
            $('#mask2').show();
            $('#<%=pnlpopup2.ClientID %>').show();
        }
        function HidePopup2() {
            $('#mask2').hide();
            $('#<%=pnlpopup2.ClientID %>').hide();
        }
        $(".btnClose").live('click', function () {
            HidePopup();
        });
        $(".btnClose").live('click', function () {
            HidePopup2();
        });
    </script>
    <div id="mask">
    </div>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="175px" Width="300px"
        Style="z-index: 111; background-color: White; position: absolute; left: 35%;
        top: 12%; border: outset 2px gray; padding: 5px; display: none">
        <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
            <tr style="background-color: #0924BC">
                <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                    align="center">
                    Define grade entry and KCB <a id="closebtn" style="color: white; float: right; text-decoration: none"
                        class="btnClose" href="#">X</a>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 45%; text-align: center;">
                    <asp:Label ID="LabelValidate" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Grade:
                </td>
                <td>
                    <asp:Label ID="GradeLabel" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Entry value:
                </td>
                <td>
                    <asp:TextBox ID="GradeEntryTextBox" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    KCB value:
                </td>
                <td>
                    <asp:TextBox ID="GradeKCBTextBox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <input type="button" class="btnClose" value="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div id="mask2">
    </div>
    <asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="175px" Width="300px"
        Style="z-index: 111; background-color: White; position: absolute; left: 35%;
        top: 12%; border: outset 2px gray; padding: 5px; display: none">
        <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
            <tr style="background-color: #0924BC">
                <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                    align="center">
                    Define step entry for grade <a id="closebtn2" style="color: white; float: right; text-decoration: none"
                        class="btnClose" href="#">X</a>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 45%; text-align: center;">
                    <asp:Label ID="LabelValidate2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Step:
                </td>
                <td>
                    <asp:Label ID="StepLabel" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Entry value:
                </td>
                <td>
                    <asp:TextBox ID="StepEntryTextBox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnUpdate2" CommandName="Update2" runat="server" Text="Update" OnClick="btnUpdate2_Click" />
                    <input type="button" class="btnClose" value="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div id="wizard" style="margin: 0px; height: auto; width: auto;">
        <div class="page" style="width: 93%;">
            <div id="dialog-form">
            </div>
            <h2>
                <font color="#707070"><strong>Pay scale for contract </strong></font><em>Please insert
                    the details of contract template pay scale: </em>
            </h2>
            <div style="margin-bottom: 15px;">
                <%--  <asp:UpdatePanel runat="server" UpdateMode="Always" ID="ParentPanel">
                    <ContentTemplate>--%>
                <asp:GridView ID="grdOrders" DataKeyNames="Code" GridLines="None" AutoGenerateColumns="False"
                    runat="server" DataSourceID="objOrders" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" AllowPaging="True" OnRowCommand="grdOrders_RowCommand"
                    OnRowDataBound="grdOrders_RowDataBound" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="9">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtn" ImageUrl="/HRM/images/gridplus.gif" CommandName="Expand"
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Code" HeaderText="Job code" SortExpression="Code" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="OrganisationalUnit" HeaderText="OrganisationalUnit" SortExpression="OrganisationalUnit" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:PlaceHolder ID="objPHOrderDetails" runat="server" Visible="true">
                                    <tr>
                                        <td width="9">
                                        </td>
                                        <td colspan="6">
                                            <%--  <asp:UpdatePanel runat="server" ID="ChildControl">
                                                        <ContentTemplate>--%>
                                            <asp:GridView ID="grdOrderDetails" GridLines="None" AutoGenerateColumns="false" runat="server"
                                                DataSourceID="objOrderDetails" CssClass="mGrid" OnRowCommand="grdOrderDetails_RowCommand" OnRowDataBound="grdOrdersDetails_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="9">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtn2" ImageUrl="/HRM/images/gridplus.gif" CommandName="Expand"
                                                                runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="GradeId" HeaderText="Grade" SortExpression="GradeId" />
                                                    <asp:BoundField DataField="GradeEntry" HeaderText="Entry" SortExpression="GradeEntry" />
                                                    <asp:BoundField DataField="GradeKCB" HeaderText="KCB" SortExpression="GradeKCB" />
                                                    <asp:TemplateField HeaderText="" SortExpression="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="ShowPopup" CommandArgument='<%#Eval("GradeId") %>'>Edit</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- STEP --%>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:PlaceHolder ID="objPHOrderDetailsDetails" runat="server" Visible="true">
                                                                <tr>
                                                                    <td width="9">
                                                                    </td>
                                                                    <td colspan="6">
                                                                        <%--  <asp:UpdatePanel runat="server" ID="ChildControl">
                                                                        <ContentTemplate>--%>
                                                                        <asp:GridView ID="grdOrderDetailsDetails" GridLines="None" AutoGenerateColumns="false" runat="server"
                                                                            DataSourceID="objOrderDetailsDetails" CssClass="mGrid" OnRowCommand="grdOrderDetailsDetails_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="StepId" HeaderText="Step" SortExpression="StepId" />
                                                                                <asp:BoundField DataField="StepEntry" HeaderText="Entry" SortExpression="StepEntry" />
                                                                                <asp:TemplateField HeaderText="" SortExpression="">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButtonEdit2" runat="server" CommandName="ShowPopup2" CommandArgument='<%#Eval("StepId") %>'>Edit</asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                                            <%--                                                        </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                                        <asp:ObjectDataSource ID="objOrderDetailsDetails" runat="server" SelectMethod="ListStepsFromPayScale"
                                                                            TypeName="DAL.Mapper.PayScaleMapper">
                                                                            <SelectParameters>
                                                                                <asp:QueryStringParameter Name="contractTemplateId" QueryStringField="ContractTemplateId" Type="Int32" ConvertEmptyStringToNull="false" />
                                                                                <asp:Parameter Name="jobCode" DefaultValue="" Type="String" ConvertEmptyStringToNull="false" />
                                                                                <asp:Parameter Name="gradeId" DefaultValue="A1" Type="String" ConvertEmptyStringToNull="false" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                            </asp:PlaceHolder>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- END OF STEP--%>

                                                </Columns>
                                            </asp:GridView>
                                            <%--                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                            <asp:ObjectDataSource ID="objOrderDetails" runat="server" SelectMethod="ListGradesFromPayScale"
                                                TypeName="DAL.Mapper.PayScaleMapper">
                                                <SelectParameters>
                                                    <asp:QueryStringParameter Name="contractTemplateId" QueryStringField="ContractTemplateId" Type="Int32" ConvertEmptyStringToNull="false" />
                                                    <asp:Parameter Name="jobCode" DefaultValue="" Type="String" ConvertEmptyStringToNull="false" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                </asp:PlaceHolder>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:ObjectDataSource ID="objOrders" runat="server" SelectMethod="ListByOrganisationalUnitId"
                    TypeName="DAL.Mapper.JobTitleMapper">
                    <SelectParameters>
                        <asp:Parameter ConvertEmptyStringToNull="False" Name="organisationalUnitId" Type="Int32" />
                        <asp:Parameter ConvertEmptyStringToNull="False" Name="search" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="status" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
