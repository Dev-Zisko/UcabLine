<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeBehind="EliT.aspx.cs" Inherits="PruebaFinal.Administrador.EliT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="IzCentrar"> 
    <div id="Tabla1">
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
    </div>
    <div id="DerCentrar">
    <div id="Tabla2">
    <h1>Trasbordo doble:</h1>
        <span>Elija el trasbordo a eliminar:</span>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br/>
        <asp:Button ID="Button2" runat="server" Text="Eliminar trasbordo doble" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="200px" OnClick="Button2_Click" />
    </div>
    </div>
</asp:Content>
