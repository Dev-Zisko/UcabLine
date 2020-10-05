<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewL.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.User.ViewL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <h1>Líneas disponibles:</h1>
        <div id="Scroll2">
        <asp:Panel ID="Panel2" runat="server" ScrollBars = "Auto" Height="120px" Width="400">
        <asp:GridView ID="GridView2" runat="server">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
        </asp:Panel>
        </div>
</asp:Content>
