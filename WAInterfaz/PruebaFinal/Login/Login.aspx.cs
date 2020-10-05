using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaFinal.Login
{
    public partial class Login1 : System.Web.UI.Page
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
                Response.Redirect("~/Administrador/CrearL.aspx");
            }
        }
     
    }
}