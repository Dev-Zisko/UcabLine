<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewTD.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.User.ViewTD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <h1>Trasbordos Dobles:</h1>
        <div id="Scroll3">
        <asp:Panel ID="Panel3" runat="server" ScrollBars = "Auto" Height="200px">
            <asp:GridView ID="GridView3" runat="server">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
            </asp:GridView>
        </asp:Panel>
        </div>
</asp:Content>
