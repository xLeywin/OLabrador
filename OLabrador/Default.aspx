<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OLabrador.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60; margin-bottom-60">
        <asp:Button ID="CatEconomia" runat="server" Text="Economia" OnClick="CatEconomia_Click" />
        <asp:Button ID="CatPolitica" runat="server" Text="Política" OnClick="CatPolitica_Click" />
        <asp:Button ID="CatCultura" runat="server" Text="Cultura" OnClick="CatCultura_Click" />
        <asp:Button ID="CatEsporte" runat="server" Text="Esporte" OnClick="CatEsporte_Click" />
        <asp:Button ID="CatTecnologia" runat="server" Text="Tecnologia" Visible="true" OnClick="CatTecnologia_Click" />
        <asp:Button ID="Cancel" runat="server" Text="X" Visible="false" OnClick="Cancel_Click" BackColor="Red" />
    </div>
    <div class="margin-top-60">
        <asp:Repeater OnItemDataBound="GridViewGaleria_ItemDataBound" ID="GridViewGaleria" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="PostLink" runat="server" CssClass="no-decoration" Target="_blank">
                    <div class="col-12 box border padding-14">
                        <div class="row">
                            <div class="col-4">
                                <asp:Image Width="100%" ID="Image" runat="server" />
                            </div>
                            <div class="col-8">
                                <asp:Label ID="Title" Font-Size="30px" runat="server" Font-Bold="true"></asp:Label>
                                <br />
                                <asp:Label ID="Subtitle" Font-Size="25px" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="PostDate" Font-Size="25px" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
