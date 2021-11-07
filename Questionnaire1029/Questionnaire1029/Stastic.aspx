<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stastic.aspx.cs" Inherits="Questionnaire1029.Stastic" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>動態問卷系統</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>動態問卷系統</h1>
        </div>
        <div>
            <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="Larger"></asp:Label>
        </div>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <asp:Panel ID="Panel2" runat="server"></asp:Panel>
        <asp:Panel ID="Panel3" runat="server"></asp:Panel>
    </form>
</body>
</html>
