<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeBehind="ModEstado.aspx.cs" Inherits="PruebaFinal.Administrador.ModEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
    <div id="Centrar1"> 
    <h1>Seleccione el estado de las líneas:</h1>
        <div id="Scroll">            
        <asp:Panel ID="Panel1" runat="server" ScrollBars = "Auto" Height="200px"  Width="400px">            
        <asp:GridView ID="GridView1" runat="server">
            <HeaderStyle BackColor="#132D8E" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" ForeColor="white" />
            <RowStyle BackColor="#95A0A0" BorderColor="#132D8E" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>               
        </asp:Panel>               
        </div>
        <br />
        <br />
    <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
    </asp:DropDownList>
        <br />
        <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cambiar estados de las líneas."  BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="220px" Visible="False" />
    </div>
    </div>
</asp:Content>
