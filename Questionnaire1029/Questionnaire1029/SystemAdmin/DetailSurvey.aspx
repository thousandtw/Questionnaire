<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DetailSurvey.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <asp:CheckBox ID="CheckBox1" runat="server" />已啟用
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCel" runat="server" Text="取消" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSed" runat="server" Text="送出" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
