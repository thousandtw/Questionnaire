<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Questionnaire1029.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>帳號:<asp:TextBox ID="txbAccount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>密碼:<asp:TextBox ID="txbPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            </td>
        </tr>
    </table>
    <br />
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    <br />
    <div>
        <span>
            <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click"/>
        </span>
    </div>
</asp:Content>
