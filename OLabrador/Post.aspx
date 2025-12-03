<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="OLabrador.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <asp:Button ID="BackTo" runat="server" Text="Voltar" CssClass="botao-confirmar" OnClick="BackTo_Click" />
        <br />
        <br />
        <div class="col-12 box border padding-50">
            <asp:Label ID="Error" Font-Size="30px" runat="server" Font-Bold="true" Visible="false" ForeColor="Red" CssClass="alinhar-centro"></asp:Label>
            <asp:Label ID="TitlePost" Font-Size="40px" runat="server" Font-Bold="true" CssClass="alinhar-centro body-titulo"></asp:Label>
            <br />
            <br />
            <asp:Image Width="70%" ID="Image" runat="server" CssClass="alinhar-centro borda-imagem" />
            <br />
            <div class="centro">
                <asp:Label ID="PostDate" Font-Size="20px" runat="server" CssClass="centro"></asp:Label>
                <asp:Label ID="Category" Font-Size="20px" runat="server" CssClass="centro"></asp:Label>
            </div>
            <br />
            <asp:Label ID="Author" Font-Size="23px" runat="server" CssClass="conteudo"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Subtitle" Font-Size="25px" runat="server" CssClass="conteudo"></asp:Label>
            <br />
            <asp:Label ID="Content" Font-Size="25px" runat="server" CssClass="conteudo"></asp:Label>
        </div>
    </div>
</asp:Content>
