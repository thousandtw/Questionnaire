<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.FAQ" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h3>常用問題管理</h3>
        </div>
      <table>
            <tr>
                <th>問卷標題</th>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txbSer" runat="server"></asp:TextBox> &nbsp;&nbsp;<asp:Button ID="btnSer" runat="server" Text="搜尋" OnClick="btnSer_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <br />
   <%-- <div>
        <asp:Button ID="btnCrt" runat="server" Text="新增" OnClick="btnCrt_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDel" runat="server" Text="刪除" OnClick="btnDel_Click" />
    </div>--%>
    <div>
        <asp:GridView ID="gv_list" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2" >
            <Columns>
                <asp:BoundField DataField="QC_id" HeaderText="編號" />
                <asp:BoundField DataField="QC_title" HeaderText="問題" />
                <asp:BoundField DataField="ANSR_1" HeaderText="回答"/>
                <asp:BoundField DataField="QC_type" HeaderText="種類"/>
                <asp:BoundField DataField="QC_mustKeyin" HeaderText="必填"/>
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
        <asp:Literal runat="server" ID="ltPager"></asp:Literal>
        <uc1:ucPager runat="server" ID="ucPager" PageSize="10" CurrentPage="1" TotalSize="10" Url="FAQ.aspx" />
        <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
            <p style="color: red; background-color: cornflowerblue">
                沒有紀錄...
            </p>
        </asp:PlaceHolder>
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </div>
</asp:Content>
