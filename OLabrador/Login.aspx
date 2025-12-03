<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OLabrador.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-120">
        <div class="col-5">
            <div class="border box-shadow padding-14">
                <h2>Acesso a sua conta</h2>
                <br />
                <asp:Label ID="Alerta" runat="server" ForeColor="Red" Font-Size="16px"></asp:Label>
                <br />
                <label>Email</label>
                <asp:TextBox ID="Email" MaxLength="100" runat="server"></asp:TextBox>
                <label>Senha</label>
                <asp:TextBox ID="Senha" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Entrar" OnClick="Entrar_Click" runat="server" Text="Entrar" />
            </div>
        </div>
    </div>
</asp:Content>
