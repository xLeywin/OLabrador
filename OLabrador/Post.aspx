<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="OLabrador.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <asp:Button ID="Baack" runat="server" Text="Voltar" />
        <br />
        <br />
        <div class="col-12 box border padding-14">
            <asp:Label ID="Error" Font-Size="30px" runat="server" Font-Bold="true" Visible="false" ForeColor="Red"></asp:Label>
            <asp:Label ID="TitlePost" Font-Size="30px" runat="server" Font-Bold="true"></asp:Label>
            <br />
            <asp:Image Width="100%" ID="Image" runat="server" />
            <br />
            <asp:Label ID="Subtitle" Font-Size="25px" runat="server"></asp:Label>
            <br />
            <asp:Label ID="PostDate" Font-Size="25px" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Category" Font-Size="25px" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Author" Font-Size="25px" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Content" Font-Size="25px" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
