<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaFinal._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoMenu" runat="server">  
                    <h1>Elija la línea que desea ver:</h1>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>            
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Seleccionar" OnClick="Button1_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="100px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="IzCentrar"> 
    <div id="Tabla1">
        <h1>Líneas disponibles:</h1>
        <div id="Scroll2">
        <asp:Panel ID="Panel2" runat="server" ScrollBars = "Auto" Height="120px" Width="400">
        <asp:GridView ID="GridView2" runat="server">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
        </asp:Panel>
        </div>
        <h1>Estaciones disponibles en la línea seleccionada:</h1>
        <div id="Scroll">
        <asp:Panel ID="Panel1" runat="server" ScrollBars = "Auto" Height="160px" Width="252px">
        <asp:GridView ID="GridView1" runat="server" Width="234px">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white"  />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
        </asp:Panel>
        </div>
    </div>
    </div> 
    <div id="DerCentrar"> 
    <div id="Tabla2">
                    <h1>Trasbordo Simples:</h1>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Seleccionar" OnClick="Button2_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
                    <br />
                    <br />
                    <asp:ListBox ID="ListBox1" runat="server" Visible="False" BackColor="#132D8E" ForeColor="White"></asp:ListBox>
                    <br />
                    <br />
                    <h1>Trasbordos Dobles:</h1>
        <div id="Scroll3">
        <asp:Panel ID="Panel3" runat="server" ScrollBars = "Auto" Height="200px">
            <asp:GridView ID="GridView3" runat="server">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
            </asp:GridView>
        </asp:Panel>
        </div>
    </div>
    </div>
</asp:Content>
