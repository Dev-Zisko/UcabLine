<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeBehind="CrearT.aspx.cs" Inherits="PruebaFinal.Administrador.CrearT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="IzCentrar"> 
    <div id="Tabla1">
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
    </div>
    <div id="DerCentrar"> 
    <div id="Tabla2">
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
        </div>
</asp:Content>
