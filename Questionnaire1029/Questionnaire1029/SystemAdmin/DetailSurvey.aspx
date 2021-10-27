<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailSurvey.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailSurvey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table>
            <tr>
                <th>問卷名稱</th>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>描述內容</th>
                <td>
                    <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>開始時間</th>
                <td>
                    <asp:TextBox ID="txbStr" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>結束時間</th>
                <td>
                    <asp:TextBox ID="txbEnd" runat="server" TextMode="Date"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CkbUse" runat="server" />已啟用  <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCel" runat="server" Text="取消" OnClick="btnCel_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSed" runat="server" Text="送出" OnClick="btnSed_Click"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
