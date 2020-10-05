<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewTD.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.ViewTD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <div id="Centrar"> 
        <h2>Trasbordos dobles:</h2>
        <div id="Scroll2">
        <asp:Panel ID="Panel2" runat="server" ScrollBars = "Auto"  Height="120px"  Width="418px">
        <asp:GridView ID="GridView2" runat="server"  Width="400px">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
        </asp:Panel>
        </div>
        </div>
        
</asp:Content>