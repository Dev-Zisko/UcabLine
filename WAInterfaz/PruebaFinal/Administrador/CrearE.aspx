<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeBehind="CrearE.aspx.cs" Inherits="PruebaFinal.Administrador.CrearE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
    <h1>Nombre de la estación:</h1>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;
    <br />
    <h1>A que línea pertenece la estación a crear:</h1>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
    </div>
</asp:Content>
