<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DetailQa.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailQa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <th>種類</th>
                <td>
                    <asp:DropDownList ID="ddl_Type" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>問題</th>
                <td>
                    <asp:TextBox ID="txtQa" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CkbMust" runat="server" />必填
                </td>
            </tr>
            <tr>
                <th>回答</th>
                <td>
                    <asp:TextBox ID="txbAns" runat="server"></asp:TextBox>(多個答案以 , 分隔)&nbsp;&nbsp;&nbsp;<asp:Button ID="btnJoin" runat="server" Text="加入" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDel" runat="server" Text="刪除" />
                </td>

            </tr>
            <tr>

                <asp:GridView ID="gv_Qa" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="#" />
                        <asp:BoundField DataField="OrderID" HeaderText="問卷名稱" />
                        <asp:BoundField DataField="Name" HeaderText="狀態" />
                        <asp:BoundField DataField="CreateDate" HeaderText="開始日期" DataFormatString="{0:yyyy/MM/dd HH:mm}" />
                        <asp:BoundField DataField="Total" HeaderText="結束日期" DataFormatString="{0:yyyy/MM/dd HH:mm}" />
                        <asp:BoundField DataField="Quantity" HeaderText="觀看統計" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCel" runat="server" Text="取消" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSed" runat="server" Text="送出" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
