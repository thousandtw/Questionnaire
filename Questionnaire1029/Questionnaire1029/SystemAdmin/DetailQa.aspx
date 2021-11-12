<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailQa.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.DetailQa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>種類</th>
                    <td>
                        <asp:DropDownList ID="ddl_Type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="自訂問題"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>問題</th>
                    <td>
                        <asp:TextBox ID="txtQT" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_QT" runat="server">
                            <asp:ListItem Value="1" Text="複選方塊"></asp:ListItem>
                            <asp:ListItem Value="2" Text="單選方塊"></asp:ListItem>
                            <asp:ListItem Value="3" Text="文字方塊"></asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="CkbMust" runat="server" />必填
                    </td>
                </tr>
                <tr>
                    <th>回答</th>
                    <td>
                        <asp:TextBox ID="txbAns" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;(多個答案以 , 分隔)&nbsp;&nbsp;&nbsp;<asp:Button ID="btnJoin" runat="server" Text="加入" OnClick="btnJoin_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDel" runat="server" Text="刪除" OnClick="btnDel_Click"  OnClientClick="return confirm('確定刪除?')" /><asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>

                    <asp:GridView ID="gv_Qa" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2" OnRowDataBound="gv_Qa_RowDataBound" OnRowCommand="gv_Qa_RowCommand1" OnRowCreated="gv_Qa_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Ckbchoose" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Qd" HeaderText="#" />

                            <asp:BoundField DataField="qt" HeaderText="問題" />

                            <asp:BoundField DataField="ans" HeaderText="回答" />

                            <asp:BoundField DataField="type" HeaderText="種類" />

                            <asp:BoundField DataField="must" HeaderText="必填" />

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LkB1" runat="server"  Text='編輯'  CommandName="LkB"></asp:LinkButton>
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
                <tr>
                    <td>
                        <asp:Button ID="btnCel" runat="server" Text="取消" OnClick="btnCel_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSed" runat="server" Text="送出" OnClick="btnSed_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
