<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="CreateTD.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.CreateTD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar">
    <h1>Trasbordo doble:</h1>
        <span>Seleccione la línea de origen:</span>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button4_Click" />
        <span>
        <br />
        <br />
        Seleccione la estación de origen:</span>
        <asp:DropDownList ID="DropDownList4" runat="server" Enabled="False">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <br/>
        <span>Seleccione la línea de destino:</span>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button5_Click" />
        <span>
        <br />
        <br />
        Seleccione la estación de destino:</span>
        <asp:DropDownList ID="DropDownList5" runat="server" Enabled="False">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Text="Crear Trasbordo Doble" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="180px" OnClick="Button6_Click" />
        <br/>
    </div>
</asp:Content>
