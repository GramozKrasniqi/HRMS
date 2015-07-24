<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoCompleteTest.aspx.cs"
    Inherits="HRM.AutoCompleteTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/HRM/Styles/autocomplete.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:TextBox runat="server" ID="userTextBox"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender runat="server" ID="autoComplete1" EnableCaching="true"
            BehaviorID="AutoCompleteEx" MinimumPrefixLength="2" TargetControlID="userTextBox"
            ServicePath="HRMWebServices.asmx" ServiceMethod="GetUsersList" CompletionInterval="1000"
            CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
            DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">
            <Animations>
              <OnShow>
              <Sequence>
              <%-- Make the completion list transparent and then show it --%>
              <OpacityAction Opacity="0" />
              <HideAction Visible="true" />

              <%--Cache the original size of the completion list the first time
                the animation is played and then set it to zero --%>
              <ScriptAction Script="
                                            var behavior = $find('AutoCompleteEx');
                                            if (!behavior._height) {
                                                var target = behavior.get_completionList();
                                                behavior._height = target.offsetHeight - 2;
                                                target.style.height = '0px';
                                            }" />
              <%-- Expand from 0px to the appropriate size while fading in --%>
              <Parallel Duration=".4">
              <FadeIn />
              <Length PropertyKey="height" StartValue="0" 
	            EndValueScript="$find('AutoCompleteEx')._height" />
              </Parallel>
              </Sequence>
              </OnShow>
              <OnHide>
              <%-- Collapse down to 0px and fade out --%>
              <Parallel Duration=".4">
              <FadeOut />
              <Length PropertyKey="height" StartValueScript=
	            "$find('AutoCompleteEx')._height" EndValue="0" />
              </Parallel>
              </OnHide>
            </Animations>
        </ajaxToolkit:AutoCompleteExtender>
    </div>
    </form>
</body>
</html>
