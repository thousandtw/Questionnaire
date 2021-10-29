<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailData.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailData" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSend" runat="server" Text="匯出" />
                </td>
            </tr>
            <tr>

                <asp:GridView ID="gv_Data" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="T_id" HeaderText="#" />
                        <asp:BoundField DataField="A_name" HeaderText="姓名" />
                        <asp:BoundField DataField="CreateDate" HeaderText="填寫時間" DataFormatString="{0:yyyy/MM/dd HH:mm}" />
                        <asp:TemplateField HeaderText="觀看細節">
                            <ItemTemplate>
                                <a href="DataConfirmPage.aspx?ID=<%# Eval("A_id")%>">前往</a>
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
            </tr>
        </table>
        <asp:Literal runat="server" ID="ltPager"></asp:Literal>
        <uc1:ucPager runat="server" ID="ucPager" PageSize="10" CurrentPage="1" TotalSize="10" Url="DetailData.aspx" />
        <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
            <p style="color: red; background-color: cornflowerblue">
                沒有紀錄...
            </p>
        </asp:PlaceHolder>
    </form>
</body>
</html>
