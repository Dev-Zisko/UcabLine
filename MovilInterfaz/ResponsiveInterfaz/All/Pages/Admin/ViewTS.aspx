<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewTS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.ViewTS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
    <h2>Trasbordos simples:</h2>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="Button3" runat="server" Height="22px" OnClick="Button3_Click" Text="Seleccionar"  BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
        <br />
        <h2>Líneas pertenecientes al trasbordo:</h2>
        <asp:ListBox ID="ListBox1" runat="server" Enabled="False" Height="68px" Visible="False" Width="142px" BackColor="#132D8E" ForeColor="White" ></asp:ListBox>
        </div>
</asp:Content>