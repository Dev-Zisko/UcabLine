<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeBehind="ModL.aspx.cs" Inherits="PruebaFinal.Administrador.ModL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
    <h1>Elija la línea a modificar:</h1>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    &nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
    <h1>Nombre de la línea:</h1>
    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <h1>Número de trenes:</h1>
    <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <br />
   <h1>Seleccione tipo de línea:</h1>
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Lineal</asp:ListItem>
            <asp:ListItem>Circular</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    <asp:Button ID="Button1" runat="server" Text="Editar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button1_Click1" />
    </div>
</asp:Content>
