<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="OLabrador.EditPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-60">
        <div class="col-8">
            <div class="border box-shadow padding-14">
                <h2>Editar Postagem</h2>
                <br />
                <asp:Label ID="Alerta" ForeColor="Red" Font-Size="16px" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Codigo" Font-Size="30px" runat="server"></asp:Label>
                <br />
                <label>Título da Postagem</label>
                <asp:TextBox ID="Titulo" TextMode="MultiLine" Height="120px" runat="server"></asp:TextBox>
                <label>Subtítulo</label>
                <asp:TextBox ID="Subtitulo" TextMode="MultiLine" Height="120px" runat="server" MaxLength="200"></asp:TextBox>
                <label>Lide</label>
                <asp:TextBox ID="Lide" TextMode="MultiLine" Height="120px" runat="server"></asp:TextBox>
                <label>Corpo do Texto</label>
                <asp:TextBox ID="Conteudo" TextMode="MultiLine" Height="400px" runat="server"></asp:TextBox>
                <label>Categoria</label>
                <asp:DropDownList ID="Categoria" Width="150px" runat="server">
                    <asp:ListItem Text="Selecionar" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Economia" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Política" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Cultura" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Esporte" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Tecnologia" Value="5"></asp:ListItem>
                </asp:DropDownList>
                <label>Situação</label>
                <asp:DropDownList ID="Situacao" Width="120px" runat="server">
                    <asp:ListItem Text="Ativo" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <label>Foto da Postagem</label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <br />
                <asp:Button OnClick="Gravar_Click" ID="Gravar" runat="server" Text="GRAVAR" CssClass="botao-confirmar" />
                <asp:Button OnClick="Excluir_Click" ID="Excluir" runat="server" Text="EXCLUIR" CssClass="botao-confirmar" />

            </div>
        </div>
        <div class="col-4">
            <div class="border box-shadow">
                <asp:Image ID="Imagem" Width="100%" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
