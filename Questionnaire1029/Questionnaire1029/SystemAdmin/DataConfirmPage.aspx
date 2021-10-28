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
                        <asp:Literal ID="ltlTime" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>1.測試文字方塊(必填)</p>
                        <asp:TextBox ID="txbMust" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>2.測試文字方塊</p>
                        <asp:TextBox ID="txbnormal" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>3.測試複選(必填)</p>
                        <asp:CheckBoxList ID="Cblplural" runat="server"></asp:CheckBoxList>
                    </td>
                    <%--<td>
                        <p>3.測試單選(必填)</p>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                    </td>--%>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
