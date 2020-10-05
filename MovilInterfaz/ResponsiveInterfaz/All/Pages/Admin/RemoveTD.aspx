<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="RemoveTD.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.RemoveTD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar">
    <h1>Trasbordo doble:</h1>
        <span>Elija el trasbordo a eliminar:</span>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br/>
        <asp:Button ID="Button2" runat="server" Text="Eliminar trasbordo doble" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="200px" OnClick="Button2_Click" />
    </div>
</asp:Content>