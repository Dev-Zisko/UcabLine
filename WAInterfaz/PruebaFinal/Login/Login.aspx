<%@ Page Title="" Language="C#" MasterPageFile="~/Login/Login.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PruebaFinal.Login.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div id="Logearse">                          
    <asp:Login ID="Loguearse" runat="server" BackColor="#0F6683" BorderColor="Black" BorderPadding="3" BorderStyle="Double" BorderWidth="5px" FailureText="Error. Reintente nuevamente." Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" LoginButtonText="Entrar" PasswordLabelText="Contraseña:" PasswordRequiredErrorMessage="Contraseña es requerida." RememberMeText="Recordar la próxima vez." TitleText="Login" UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Usuario es requerido." OnAuthenticate="Loguearse_Authenticate" Font-Bold="True" Font-Italic="False" Font-Strikeout="False" Height="200px" Width="400px" DisplayRememberMe="False">
        <CheckBoxStyle Wrap="True" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LoginButtonStyle BackColor="#132D8E" BorderStyle="Solid" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" Font-Bold="True" Width="150px" />
        <TextBoxStyle Font-Size="Smaller" />
        <TitleTextStyle BackColor="#132D8E" Font-Bold="True" Font-Size="Medium" ForeColor="White" BorderColor="White" BorderStyle="None" BorderWidth="3px" Font-Names="Times New Roman" />
     </asp:Login>
     </div>  
</asp:Content>
