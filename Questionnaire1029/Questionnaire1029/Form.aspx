<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Questionnaire1029.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: right; text-align: right">
        <asp:Label ID="lblState" runat="server" Text="Label"></asp:Label><br />
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
        <asp:Label ID="lblHeader" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label><br />
    </div>
    <br />
    <div style="text-align: center">
        <asp:Label ID="lblMemo" runat="server" Text="Label"></asp:Label>
    </div>
    <br />
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
                    <asp:TextBox ID="txbMobilePhone" runat="server" TextMode="Phone" pattern="[0-9]{3}[0-9]{3}[0-9]{4}"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Email</th>
                <td>
                    <asp:TextBox ID="txbEmail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>年齡</th>
                <td>
                    <asp:TextBox ID="txbAge" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal><br />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:Label ID="lblQT" runat="server" Text="Label"></asp:Label>
        <asp:CheckBoxList ID="CblVote" runat="server"></asp:CheckBoxList>
    </div>
    <br />
    <div>
        &nbsp;
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnCel" runat="server" Text="取消" OnClick="btnCel_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="送出" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
