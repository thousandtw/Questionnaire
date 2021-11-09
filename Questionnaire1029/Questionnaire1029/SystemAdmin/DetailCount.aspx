<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailCount.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailCount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>選項統計</h2>
        </div>
        <div>
            <table>
                <tr>
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                </tr>
                <tr><td>&nbsp;&nbsp;</td></tr>
                 <tr>
                     <asp:Panel ID="Panel2" runat="server"></asp:Panel>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
