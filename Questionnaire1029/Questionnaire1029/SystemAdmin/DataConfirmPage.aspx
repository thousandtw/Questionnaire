<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataConfirmPage.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DataConfirmPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <a>姓名</a>
                        <asp:TextBox ID="txbName" runat="server"></asp:TextBox><br />
                        <a>信箱</a>
                        <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <a>手機</a>
                        <asp:TextBox ID="txbMobilePhone" runat="server"></asp:TextBox><br />
                        <a>年齡</a>
                        <asp:TextBox ID="txbAge" runat="server"></asp:TextBox><br />
                    </td>
                    <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Literal ID="ltlTime" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>問卷名稱</p>
                        <asp:TextBox ID="txbSurvey" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>問題</p>
                        <asp:TextBox ID="txbQt" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>選項</p>
                        <asp:TextBox ID="txbOptions" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>回答</p>
                        <asp:TextBox ID="txbAnswer" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
