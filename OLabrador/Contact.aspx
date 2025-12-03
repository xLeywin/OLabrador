<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OLabrador.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-120">
    <!-- Form -->
    <div class="col-6">
      <div class="border padding-14 margin-right-20">
        <h1>Contato</h1>
        <br />
        <asp:Label ID="Alert" Font-Bold="true" Font-Size="16px" ForeColor="red" runat="server"></asp:Label>
        <br />
        <br />
        <label>Nome</label>
        <asp:TextBox ID="Name" MaxLength="100" runat="server"></asp:TextBox>
        <label>E-mail</label>
        <asp:TextBox ID="Email" MaxLength="100" runat="server"></asp:TextBox>
        <label>Mensagem</label>
        <asp:TextBox ID="Message" MaxLength="255" TextMode="MultiLine"  Rows="6" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="Send" OnClick="Send_Click" runat="server" Text="Enviar" />
        <br />
        <br />
      </div>
    </div>
  </div>
</asp:Content>
