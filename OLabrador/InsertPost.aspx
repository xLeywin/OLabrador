<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertPost.aspx.cs" Inherits="OLabrador.InsertPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row margin-top-60">
    <div class="col-8">
        <div class="border box-shadow padding-14">
            <h2>Criar Postagem</h2>
            <br />
            <asp:Label ID="Alerta" ForeColor="Red" Font-Size="16px" runat="server"></asp:Label>
            <br />
            <br />
            <label>Título</label>
            <asp:TextBox ID="Titulo" TextMode="MultiLine" Height="120px" runat="server"></asp:TextBox>
            
            <label>Subtítulo</label>
            <asp:TextBox ID="Subtitulo" TextMode="MultiLine" Height="120px" runat="server"></asp:TextBox>
            
            <label>Lide</label>
            <asp:TextBox ID="Lide" TextMode="MultiLine" Height="120px" runat="server"></asp:TextBox>
            
            <label>Corpo do Texto</label>
            <asp:TextBox ID="CorpoDoTexto" TextMode="MultiLine" Height="400px" runat="server"></asp:TextBox>
            
            <label>Autor do texto</label>
            <asp:TextBox ID="Autor" TextMode="MultiLine" Height="40px" runat="server"></asp:TextBox>
            
            <label>Categoria</label>
            <asp:DropDownList ID="Categoria" Width="150px" runat="server">
                <asp:ListItem Text="Economia" Value="1"></asp:ListItem>
                <asp:ListItem Text="Entretenimento" Value="2"></asp:ListItem>
                <asp:ListItem Text="Política" Value="3"></asp:ListItem>
                <asp:ListItem Text="Mundo" Value="4"></asp:ListItem>
            </asp:DropDownList>

            <label>Situação</label>
            <asp:DropDownList ID="Situacao" Width="150px" runat="server">
                <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
            </asp:DropDownList>

            <label>Foto</label>
            <asp:FileUpload ID="FileUpload1" runat="server"/>
            <br />
            <br />
            <asp:Button OnClick="Salvar_Click" ID="Salvar" runat="server" Text="Salvar" />
        </div>
    </div>
</div>
</asp:Content>
