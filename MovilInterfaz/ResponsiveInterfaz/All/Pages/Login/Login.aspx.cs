using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Login
{
    public partial class Login : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Loguearse_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool Autenticado = false;
            Autenticado = clienteLogica.ValidarUsuario(Loguearse.UserName, Loguearse.Password);
            e.Authenticated = Autenticado; if (Autenticado)
            {
                Response.Redirect("~/All/Pages/Admin/MainAdmin.aspx");
            }
        }

    }
}