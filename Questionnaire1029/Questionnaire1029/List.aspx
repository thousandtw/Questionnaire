<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Questionnaire1029.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <th>問卷標題</th>
                <td>
                    <asp:TextBox ID="txbHeader" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>開始/結束</th>
                <td>
                    <asp:TextBox ID="txbStr" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txbEnd" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSer" runat="server" Text="搜尋" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gv_list" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
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
    </div>
</asp:Content>
