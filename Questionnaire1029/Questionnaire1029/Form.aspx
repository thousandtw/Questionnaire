<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Questionnaire1029.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: right; text-align: right">
        <asp:Label ID="lblVote" runat="server" Text="投票中"></asp:Label>
        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
    </div>
    <br />
    <div>
        <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblDetail" runat="server" Text="Label"></asp:Label>
    </div>

    <div>
        <table>
            <tr>
                <th>姓名</th>
                <td>
                    <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>手機</th>
                <td>
                    <asp:TextBox ID="txbMobilePhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Email</th>
                <td>
                    <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>年齡</th>
                <td>
                    <asp:TextBox ID="txbAge" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gdvVote" runat="server"></asp:GridView>
    </div>
</asp:Content>
