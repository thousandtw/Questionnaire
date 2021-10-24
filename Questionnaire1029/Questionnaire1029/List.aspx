<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Questionnaire1029.List" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <th>問卷標題</th>
                <td>
                    <asp:TextBox ID="txbHeader" runat="server" OnTextChanged="txbHeader_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>開始/結束</th>
                <td>
                    <asp:TextBox ID="txbStr" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txbEnd" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSer" runat="server" Text="搜尋" OnClick="btnSer_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gv_list" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
            <Columns>
                <asp:BoundField DataField="T_id" HeaderText="#" />
                <asp:TemplateField HeaderText="問卷名稱">
                    <ItemTemplate>
                        <a href="Form.aspx?ID=<%# Eval("T_id")%>"><%# Eval("T_title")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="狀態">
                    <ItemTemplate>
                        <a>投票中</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="T_start" HeaderText="開始日期" DataFormatString="{0:d}" />
                <asp:BoundField DataField="T_end" HeaderText="結束日期" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="觀看統計">
                    <ItemTemplate>
                        <a href="Stastic.aspx">前往</a>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <uc1:ucPager runat="server" ID="ucPager" PageSize="10" CurrentPage="1" TotalSize="10" Url="List.aspx" />
        <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
            <p style="color: red; background-color: cornflowerblue">
                沒有紀錄...
            </p>
        </asp:PlaceHolder>
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </div>
</asp:Content>
