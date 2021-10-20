<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DetailData.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSend" runat="server" Text="匯出" />
            </td>
        </tr>
        <tr>
           
                <asp:GridView ID="gv_Data" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
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
    </table>
</asp:Content>
