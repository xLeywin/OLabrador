<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OLabrador.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <div>
            <asp:Repeater OnItemDataBound="GridViewGaleria_ItemDataBound" ID="GridViewGaleria" runat="server">
                <ItemTemplate>
                    <div class="col-12 box border padding-14">
                        <div class="row">
                            <div class="col-4">
                                <asp:HyperLink ID="LinkImagem" Target="_blank" runat="server">
                                    <asp:Image Width="100%" ID="Image" runat="server" />
                                </asp:HyperLink>
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
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
