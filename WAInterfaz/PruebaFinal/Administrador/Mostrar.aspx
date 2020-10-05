<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeBehind="Mostrar.aspx.cs" Inherits="PruebaFinal.Administrador.Mostrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="IzCentrar"> 
    <div id="Tabla1">
    <h1>Elija la línea que desea ver:</h1>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="83px">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="Button1" runat="server" Text="Seleccionar" OnClick="Button1_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
        <br />
        <br />
        <h1>Estaciones de la línea seleccionada:</h1>
        <div id="Scroll">
        <asp:Panel ID="Panel1" runat="server" ScrollBars = "Auto" Height="150px"  Width="252px">
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" Width="234px">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>  
        </asp:Panel>
        </div>    
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="Button2" runat="server" Text="Cambiar estado de estación" OnClick="Button2_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="200px" Visible="False" />
    </div>
    </div>
    <div id="DerCentrar"> 
    <div id="Tabla2">
    <h1>Trasbordos:</h1>
    <h2>Trasbordos simples:</h2>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="Button3" runat="server" Height="22px" OnClick="Button3_Click" Text="Seleccionar"  BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
        <br />
        <h2>Líneas pertenecientes al trasbordo:</h2>
        <asp:ListBox ID="ListBox1" runat="server" Enabled="False" Height="68px" Visible="False" Width="142px" BackColor="#132D8E" ForeColor="White" ></asp:ListBox>
        <br />
        <br />
        <h2>Trasbordos dobles:</h2>
        <div id="Scroll2">
        <asp:Panel ID="Panel2" runat="server" ScrollBars = "Auto"  Height="120px"  Width="418px">
        <asp:GridView ID="GridView2" runat="server"  Width="400px">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
        </asp:Panel>
        </div>
    </div>
    </div>
</asp:Content>
