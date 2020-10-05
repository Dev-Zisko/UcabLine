<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="RemoveTS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.RemoveTS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
    <h1>Trasbordo simple:</h1>
        <span>Elija el trasbordo a eliminar:</span>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="120px" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Visible="False" BackColor="#132D8E" ForeColor="White" ></asp:ListBox>
        <br />
        <br/>
        <asp:Button ID="Button1" runat="server" Text="Eliminar trasbordo simple" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="200px" OnClick="Button1_Click" />
    </div>
</asp:Content>