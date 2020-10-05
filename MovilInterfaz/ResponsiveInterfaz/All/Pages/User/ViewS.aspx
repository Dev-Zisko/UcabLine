<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.User.ViewS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <h1>Elija la línea que desea ver:</h1>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>            
        &nbsp;
        <asp:Button ID="Button1" runat="server" Text="Seleccionar" OnClick="Button1_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="100px" />
        <h1>Estaciones disponibles:</h1>
        <div id="Scroll">
        <asp:Panel ID="Panel1" runat="server" ScrollBars = "Auto" Height="160px" Width="252px">
        <asp:GridView ID="GridView1" runat="server" Width="234px">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white"  />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
        </asp:Panel>
        </div>
</asp:Content>
