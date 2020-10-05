<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="RemoveL.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.RemoveL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar">
    <h1>Elija la línea a eliminar:</h1>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>    
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Eliminar línea" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button1_Click" />
    </div>
</asp:Content>