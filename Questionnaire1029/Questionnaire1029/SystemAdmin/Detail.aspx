<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Questionnaire1029.SystemAdmin.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
    <asp:Button ID="btnSurvey" Style="z-index: 101; position: absolute; top: 150px; left: 460px; width: 125px; right: 1683px;" runat="server"
        Text="問卷" CssClass="aaa" OnClick="btnSurvey_Click"></asp:Button>
    <asp:Button ID="btnQa" Style="z-index: 102; position: absolute; top: 150px; left: 580px; width: 125px;" runat="server"
        Text="問題" CssClass="bbb" OnClick="btnQa_Click"></asp:Button>
    <asp:Button ID="btnData" Style="z-index: 102; position: absolute; top: 150px; left: 700px; width: 125px;" runat="server"
        Text="填寫資料" CssClass="aaa" OnClick="btnData_Click"></asp:Button>
    <asp:Button ID="btnCount" Style="z-index: 101; position: absolute; top: 150px; left: 820px; width: 125px;" runat="server"
        Text="統計" CssClass="bbb" OnClick="btnCount_Click"></asp:Button>
    <iframe id="IFRAME1" style="border-right: 0px solid; border-top: 0px solid; z-index: 103; left: 461px; border-left: 0px solid; width: 540px; border-bottom: 0px solid; position: absolute; top: 175px; height: 555px"
        runat="server"></iframe>
        </div>
</asp:Content>
