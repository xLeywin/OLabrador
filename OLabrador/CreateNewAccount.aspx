<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewAccount.aspx.cs" Inherits="OLabrador.CreateNewAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-60">
        <div class="col-8">
            <div class="border box-shadow padding-14">
                <h2>Cadastrar uma nova conta</h2>
                <br />
                <asp:Label ID="Alerta" ForeColor="Red" Font-Size="16px" runat="server"></asp:Label>
                <br />
                <br />
                <label>Nome</label>
                <asp:TextBox ID="Nome" runat="server"></asp:TextBox>
                <label>E-mail</label>
                <asp:TextBox ID="Email" TextMode="Email" runat="server"></asp:TextBox>
                <label>Senha</label>
                <asp:TextBox ID="Senha" TextMode="Password" runat="server"></asp:TextBox>
                <label>Confirme sua senha</label>
                <asp:TextBox ID="SenhaConfirmar" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button OnClick="Confirmar_Click" ID="Confirmar" runat="server" Text="Confirmar" />
            </div>
        </div>
    </div>
</asp:Content>
