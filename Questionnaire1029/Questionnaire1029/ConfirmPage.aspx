<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConfirmPage.aspx.cs" Inherits="Questionnaire1029.ConfirmPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: right; text-align: right">
        <asp:Label ID="lblVote" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
    </div>
     <br />
    <div>
        &nbsp;
    </div>
    <div>
        &nbsp;
    </div>
    <br />
    <div style="text-align: center">
        <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
    </div>
    <div>
        &nbsp;
    </div>
    <br />
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
        <p>1.已投票</p>
        <asp:ListBox ID="ltbVote" runat="server"></asp:ListBox>
    </div>
    <br />
    <div>
        &nbsp;
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="取消" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
