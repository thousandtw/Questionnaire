<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConfirmPage.aspx.cs" Inherits="Questionnaire1029.ConfirmPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: right; text-align: right">
        <asp:Label ID="lblVote" runat="server" Text="投票中"></asp:Label><br />
        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <th>姓名</th>
                <td>
                    <asp:Label ID="lblaName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>手機</th>
                <td>
                    <asp:Label ID="lblMobilePhone" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Email</th>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>年齡</th>
                <td>
                    <asp:Label ID="lblAge" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gdvVote" runat="server"></asp:GridView>
    </div>
</asp:Content>
