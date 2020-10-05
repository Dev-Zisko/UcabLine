<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ModifySS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.Admin.ModifySS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Centrar"> 
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
</asp:Content>