<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowPost.aspx.cs" Inherits="OLabrador.ShowPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-60">
        <div class="col-10">
            <div class="border box-shadow padding-14">
                <asp:TextBox ID="BuscarPostagem" Width="120px" runat="server"></asp:TextBox>

                <asp:Button ID="Buscar" runat="server" Text="BUSCAR" OnClick="Buscar_Click" CssClass="botao-confirmar"/>

                <asp:Button ID="Cancelar" Visible="false" runat="server" OnClick="Cancelar_Click" Text="X" />
                <br />
                <br />
                <asp:GridView ID="Postagens" Width="100%" CellPadding="8" OnSelectedIndexChanged="Postagens_SelectedIndexChanged" AutoGenerateSelectButton="true" BorderColor="#c0c0c0" runat="server"></asp:GridView>
                <br />
                <asp:Button ID="Inserir" runat="server" Text="INSERIR" onclick="Inserir_Click" CssClass="botao-confirmar"/>

            </div>
        </div>
    </div>

</asp:Content>

