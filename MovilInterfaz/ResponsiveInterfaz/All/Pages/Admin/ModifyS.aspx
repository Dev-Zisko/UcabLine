<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ModifyS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.ModifyS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
    <h1>Elija la línea de la estación:</h1>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    &nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
    <h1>Elija la estación a modificar:</h1>
        <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False">
        </asp:DropDownList>
    &nbsp;
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
    <h1>Nuevo nombre de la estación:</h1>
    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Editar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button1_Click" />
    </div>
</asp:Content>