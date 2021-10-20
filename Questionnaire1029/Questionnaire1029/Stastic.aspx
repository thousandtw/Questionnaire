<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Stastic.aspx.cs" Inherits="Questionnaire1029.Stastic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="gdvVote" runat="server"></asp:GridView>
</asp:Content>
