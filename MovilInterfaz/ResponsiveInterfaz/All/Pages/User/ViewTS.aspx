<%@ Page Title="" Language="C#" MasterPageFile="~/All/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewTS.aspx.cs" Inherits="ResponsiveInterfaz.All.Pages.User.ViewTS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
                   <h1>Trasbordo Simples:</h1>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Seleccionar" OnClick="Button2_Click" BackColor="#303A52" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
                    <br />
                    <br />
                    <asp:ListBox ID="ListBox1" runat="server" Visible="False" BackColor="#132D8E" ForeColor="White"></asp:ListBox>
</asp:Content>
