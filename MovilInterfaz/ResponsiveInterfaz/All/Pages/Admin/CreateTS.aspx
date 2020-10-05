<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="CreateTS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.CreateTS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <div id="Centrar"> 
        <h1>Trasbordo simple:</h1>
        <span>Seleccione la línea:</span>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button1_Click" />
        <br />
        <br />
        <span>Seleccione la estación:</span>
        <asp:DropDownList ID="DropDownList6" runat="server" Enabled="False">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Seleccionar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button2_Click" />
        <br />
        <br />
        <span>Para seleccionar varias líneas use "ctrl + click"</span>
        <br />
        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Visible="False" BackColor="#132D8E" ForeColor="White" ></asp:ListBox>
        <br />
        <br/>
        <asp:Button ID="Button3" runat="server" Text="Guardar" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" OnClick="Button3_Click" />
        </div>
</asp:Content>
